using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapstoneProjectServer.API.Validators
{
    public class An
    {
        public int Id { get; set; }
        public String Name { get; set; }

    }
    public class AnValidator: AbstractValidator<An>
    {
        public AnValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cann't be empty");
        }
    }
}