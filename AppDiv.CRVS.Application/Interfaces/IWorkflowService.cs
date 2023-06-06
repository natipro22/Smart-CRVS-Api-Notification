using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDiv.CRVS.Application.Interfaces
{
    public interface IWorkflowService
    {
        public int GetLastWorkflow(string workflowType);
        public int GetNextStep(string workflowType, int step, bool isApprove);
        public Task<(bool, Guid)> ApproveService(Guid RequestId, string workflowType, bool IsApprove, CancellationToken cancellationToken);
    }
}