using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Clean_Architecture_Soufiane.Services.Identity.API.Models.ManageViewModels
{
    public record ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; init; }

        public ICollection<SelectListItem> Providers { get; init; }
    }
}
