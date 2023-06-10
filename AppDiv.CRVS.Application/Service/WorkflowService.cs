using System;
using System.Security.Cryptography.X509Certificates;

using AppDiv.CRVS.Application.Contracts.Request;
using AppDiv.CRVS.Application.Interfaces;
using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppDiv.CRVS.Application.Service
{
    public class WorkflowService : IWorkflowService
    {
        private readonly IWorkflowRepository _workflowRepository;
        private readonly IStepRepository _stepRepostory;
        private readonly IRequestRepostory _requestRepostory;
        private readonly ITransactionService _TransactionService;
        private readonly IUserResolverService _UserResolverService;
        private readonly INotificationService _NotificationService;
        private readonly ICertificateRepository _CertificateRepository;
        private readonly IEventPaymentRequestService _paymentRequestService;
        private readonly IPaymentRequestRepository _paymentRequestRepository;


        private readonly IEventRepository _EventRepository;
        public WorkflowService(IEventRepository EventRepository, IPaymentRequestRepository paymentRequestRepository, IEventPaymentRequestService paymentRequestService, ICertificateRepository CertificateRepository, INotificationService NotificationService, IUserResolverService UserResolverService, ITransactionService TransactionService, IWorkflowRepository workflowRepository, IRequestRepostory requestRepostory, IStepRepository stepRepostory)
        {
            _workflowRepository = workflowRepository;
            _stepRepostory = stepRepostory;
            _requestRepostory = requestRepostory;
            _TransactionService = TransactionService;
            _UserResolverService = UserResolverService;
            _CertificateRepository = CertificateRepository;
            _paymentRequestService = paymentRequestService;
            _EventRepository = EventRepository;
            _paymentRequestRepository = paymentRequestRepository;
        }
        public int GetLastWorkflow(string workflowType)
        {
            var lastStep = _stepRepostory.GetAll()
            .Include(x => x.workflow)
            .Where(x => x.workflow.workflowName == workflowType)
            .OrderByDescending(x => x.step).FirstOrDefault();
            return lastStep.step;
        }
        public int GetNextStep(string workflowType, int step, bool isApprove)
        {
            if (isApprove)
            {
                var nextStep = _stepRepostory.GetAll()
                            .Include(x => x.workflow)
                            .Where(x => x.workflow.workflowName == workflowType && x.step > step)
                            .OrderBy(x => x.step).FirstOrDefault();

                return nextStep.step;
            }
            else
            {
                if (step == 1 || step == 0)
                {
                    return 0;
                }
                var nextStep = _stepRepostory.GetAll()
                           .Include(x => x.workflow)
                           .Where(x => x.workflow.workflowName == workflowType && x.step < step)
                           .OrderByDescending(x => x.step).FirstOrDefault();
                return nextStep.step;
            }
        }
        public Guid GetReceiverGroupId(string workflowType, int step)
        {
            var groupId = _workflowRepository.GetAll()
            .Where(w => w.workflowName == workflowType)
            .Select(w => w.Steps.Where(s => s.step == step).Select(s => s.UserGroupId).FirstOrDefault()
            ).FirstOrDefault();
            if (groupId == null)
            {
                throw new Exception("user group not found");
            }
            return (Guid)groupId;
        }
        public async Task<(bool, Guid)> ApproveService(Guid RequestId, string workflowType, bool IsApprove, string? Remark, bool paymentAdded, CancellationToken cancellationToken)
        {
            var request = _requestRepostory.GetAll()
            .Include(x => x.AuthenticationRequest).ThenInclude(a => a.Certificate)
            .Include(x => x.CorrectionRequest)
            .Include(x => x.PaymentExamptionRequest)
            .Where(x => x.Id == RequestId).FirstOrDefault();
            Guid ReturnId = (request?.AuthenticationRequest?.Id == null || request?.AuthenticationRequest?.Id == Guid.Empty) ?
            (request?.CorrectionRequest?.EventId == null || request?.CorrectionRequest?.EventId == Guid.Empty) ?
            request.PaymentExamptionRequest.Id : request.CorrectionRequest.EventId : request.AuthenticationRequest.CertificateId;
            if (request == null)
            {
                throw new Exception("Request Does not Found");
            }
            if (request.currentStep >= 0 && request.currentStep < this.GetLastWorkflow(workflowType))
            {
                var nextStep = this.GetNextStep(workflowType, request.currentStep, IsApprove);
                if (this.WorkflowHasPayment(workflowType, nextStep, RequestId) && !paymentAdded)
                {
                    this.CreatePaymentRequest(workflowType, RequestId, cancellationToken);
                }
                else
                {
                    try
                    {
                        request.currentStep = nextStep;
                        _requestRepostory.Update(request);
                        _requestRepostory.SaveChanges();
                        // var NewTranscation = new TransactionRequestDTO
                        // {
                        //     CurrentStep = request.currentStep,
                        //     ApprovalStatus = IsApprove,
                        //     WorkflowId = RequestId,
                        //     RequestId = RequestId,
                        //     CivilRegOfficerId = "4d940006-b21f-4841-b8dd-02957c4d7487",
                        //     Remark = Remark
                        // };
                        // await _TransactionService.CreateTransaction(NewTranscation);
                        // await _NotificationService.CreateNotification(ReturnId, workflowType, workflowType,
                        //                    this.GetReceiverGroupId(workflowType, request.currentStep), RequestId,
                        //                   "4d940006-b21f-4841-b8dd-02957c4d7487");
                    }
                    catch (Exception exp)
                    {
                        throw new Exception(exp.Message);
                    }
                }
            }
            else
            {
                return (false, ReturnId);
            }
            return ((this.GetLastWorkflow(workflowType) == request.currentStep), ReturnId);

        }
        public Guid GetEventId(Guid Id)
        {
            var eventId = _CertificateRepository.GetAll().Where(x => x.Id == Id).FirstOrDefault();
            return eventId.EventId;
        }

        public bool WorkflowHasPayment(string workflow, int Step, Guid RequestId)
        {
            var selectedWorkflow = _workflowRepository.GetAll()
            .Where(wf => wf.workflowName == workflow).FirstOrDefault();
            if ((selectedWorkflow.HasPayment && selectedWorkflow.PaymentStep == Step))
            {
                // var payment = _paymentRequestRepository.GetAll()
                //         .Include(x => x.Payment)
                //         .Where(x => x.RequestId == RequestId && x.Payment.PaymentRequestId == RequestId);
                // if (payment == null)
                // {
                return true;
                // }
                // return false;
            }
            return false;
            // var requestHaspayment = _requestRepostory.GetAll()
            // .Include(x => x.Workflow)
            // .Include(x => x.PaymentRequest)
            // .ThenInclude(x => x.Payment)
            // .Where(re => ((re.Id == RequestId && re.Workflow.HasPayment) && (re.Workflow.PaymentStep == Step))
            // && (re.PaymentRequest.Payment != null)
            // ).FirstOrDefault();
        }


        public async void CreatePaymentRequest(string workflowType, Guid RequestId, CancellationToken cancellationToken)
        {
            var request = _requestRepostory
            .GetAll()
            .Include(x => x.AuthenticationRequest)
            .Include(X => X.CorrectionRequest).Where(x => x.Id == RequestId).FirstOrDefault();
            if (request == null)
            {
                throw new Exception("Request Does not Found");
            }
            if (request.RequestType == "authentication" || request.RequestType == "change")
            {
                try
                {
                    Guid? EventId = (request?.CorrectionRequest?.Id == null) ? this.GetEventId(request.AuthenticationRequest.CertificateId) : request.CorrectionRequest.EventId;
                    var selectedEvent = _EventRepository.GetAll()
                    .Include(x => x.EventOwener)
                    .Where(x => x.Id == EventId).FirstOrDefault();
                    (float? amount, string? code) response = await _paymentRequestService.CreatePaymentRequest(selectedEvent.EventType, selectedEvent, workflowType, RequestId, cancellationToken);

                }
                catch (Exception ex)
                {
                    throw new Exception("an Error occured on Creating Payment Request" + ex.Message);
                }

            }

        }
    }
}