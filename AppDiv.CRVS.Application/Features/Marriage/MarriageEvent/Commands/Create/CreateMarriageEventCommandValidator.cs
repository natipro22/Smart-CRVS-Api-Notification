﻿using AppDiv.CRVS.Domain.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDiv.CRVS.Application.Features.MarriageEvent.Command.Create
{
    public class CreateMarriageEventCommandValidator : AbstractValidator<CreateMarriageEventCommand>
    {
       
        public CreateMarriageEventCommandValidator()
        {
        }

    }
}