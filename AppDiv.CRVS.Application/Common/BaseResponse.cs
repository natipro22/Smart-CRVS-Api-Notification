using System.Collections.Generic;
using FluentValidation.Results;

namespace AppDiv.CRVS.Application.Common
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Success = true;
        }

        public BaseResponse(string message = null)
        {
            Success = true;
            Message = message;
        }

        public BaseResponse(string message, bool success)
        {
            Success = success;
            Message = message;
        }

        public BaseResponse(string message, bool success, int status = 200)
        {
            Success = success;
            Message = message;
            Status = status;
        }

        public BaseResponse(string message, bool success, Guid? Id)
        {
            Success = success;
            Message = message;
        }



        public bool Success { get; set; }
        public string Message { get; set; }
        public int Status { get; set; } = 200;
        public List<string> ValidationErrors { get; set; }

        public void BadRequest(string message = null)
        {
            this.Success = false;
            this.Status = 400;
            this.Message = message;
        }
        public void BadRequest(List<ValidationFailure> errors)
        {
            this.Success = false;
            this.Status = 400;
            this.ValidationErrors = new List<string>();
                    foreach (var error in errors)
                        this.ValidationErrors.Add(error.ErrorMessage);
                    this.Message = this.ValidationErrors[0];
        }

        public void Deleted(string entityName = null)
        {
            this.Success = true;
            this.Status = 200;
            this.Message = $"{entityName} information has been deleted!";
        }
        public void Updated(string entityName = null)
        {
            this.Success = true;
            this.Status = 200;
            this.Message = $"{entityName} information has been updated!";
        }
        public void Created(string entityName = null, string message = null)
        {
            this.Success = true;
            this.Status = 200;
            this.Message = message ?? $"{entityName} created succusesfully.";
        }

    }
}