using System.Collections.Generic;
using System.Web.Mvc;
using CleanArchitecture.Application.CompoundEntities.Commands.CreateCompoundEntity;

namespace CleanArchitecture.Presentation.CompoundEntities.Models
{
    public class CreateCompoundEntityViewModel
    {
        public List<SelectListItem> SimpleEntities { get; set; }

        public List<SelectListItem> AnotherEntities { get; set; }

        public CreateCompoundEntityModel CompoundEntity { get; set; }
    }
}