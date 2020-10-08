using System.Collections.Generic;

namespace Billing52Group.Models.Api.V1
{
    public class TariffGroupViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<TariffPlanViewModel> Tariffplan { get; set; } = new List<TariffPlanViewModel>();
    }
}
