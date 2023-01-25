using FluentValidation;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models.Validation
{
    public class ValidateNews : AbstractValidator<INews>
    {
        public ValidateNews() 
        {
            RuleFor(news => news.Title)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage("{PropertyName} is empty!")
                .NotEmpty()
                .WithMessage("{PropertyName} is empty!")
                .Length(3, 50)
                .WithMessage("{PropertyName} must have a length between 3 and 50. You have {TotalLength} characters!");
            RuleFor(news => news.SubTitle)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage("{PropertyName} is empty!")
                .NotEmpty()
                .WithMessage("{PropertyName} is empty!")
                .Length(3, 50)
                .WithMessage("{PropertyName} must have a length between 3 and 50. You have {TotalLength} characters!");
            RuleFor(news => news.NewsText)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage("{PropertyName} is empty!")
                .NotEmpty()
                .WithMessage("{PropertyName} is empty!")
                .Length(3, 50)
                .WithMessage("{PropertyName} must have a length between 3 and 50. You have {TotalLength} characters!");
            RuleFor(news => news.ReadingTime)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage("{PropertyName} is empty!")
                .NotEmpty()
                .WithMessage("{PropertyName} is empty!")
                .Must(BeValidTime)
                .WithMessage("{PropertyName} is empty!");
            RuleFor(news => news.Tags)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage("{PropertyName} is empty!")
                .NotEmpty()
                .WithMessage("{PropertyName} is empty!");

        }
        protected bool BeValidTime(int readingTime)
        {
            return readingTime > 0;
        }
    }
}
