using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ProjectValidator:AbstractValidator<Project>
    {
        public ProjectValidator()
        {
                RuleFor(x=>x.ProjectName).NotEmpty().WithMessage("Proje Adını Boş Geçiremezsiniz");
                RuleFor(x => x.ProjectDesc).NotEmpty().WithMessage("Proje Açıklamasını Boş Geçiremezsiniz");
                RuleFor(x => x.ProjectDesc).MinimumLength(50). WithMessage("Lütfen En Az 50 Karakterlik Bir Açıklama Giriniz.");
                RuleFor(x => x.ProjectDesc).MaximumLength(1000).WithMessage("Lütfen En Fazla 1000 Karakterlik Bir Açıklama Girebilirsiniz.");
        }
    }
}
