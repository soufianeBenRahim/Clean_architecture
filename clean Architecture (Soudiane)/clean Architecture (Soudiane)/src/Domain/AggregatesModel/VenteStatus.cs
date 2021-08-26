namespace Clean_Architecture_Soufiane.Domain.AggregatesModel
{
    using Clean_Architecture_Soufiane.Domain.SeedWork;
    using Ordering.Domain.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class VenteStatus
        : Enumeration
    {
        public static VenteStatus Submitted = new VenteStatus(1, nameof(Submitted).ToLowerInvariant());
        public static VenteStatus AwaitingValidation = new VenteStatus(2, nameof(AwaitingValidation).ToLowerInvariant());
        public static VenteStatus StockConfirmed = new VenteStatus(3, nameof(StockConfirmed).ToLowerInvariant());
        public static VenteStatus Paid = new VenteStatus(4, nameof(Paid).ToLowerInvariant());
        public static VenteStatus Shipped = new VenteStatus(5, nameof(Shipped).ToLowerInvariant());
        public static VenteStatus Cancelled = new VenteStatus(6, nameof(Cancelled).ToLowerInvariant());

        public VenteStatus(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<VenteStatus> List() =>
            new[] { Submitted, AwaitingValidation, StockConfirmed, Paid, Shipped, Cancelled };

        public static VenteStatus FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new ValidationDomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static VenteStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new ValidationDomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}
