using Clean_Architecture_Soufiane.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture_Soufiane.Domain.AggregatesModel
{
    
    
    public class Vente : AuditableEntity,  IAggregateRoot 
    {
        // DDD Patterns comment
        // Using private fields, allowed since EF Core 1.1, is a much better encapsulation
        // aligned with DDD Aggregates and Domain Entities (Instead of properties and property collections)
        private DateTime _orderDate;

        public VenteStatus VenteStatus { get; private set; }
        private int _venteStatusId;

        private string _description;



        // Draft orders have this set to true. Currently we don't check anywhere the draft status of an Order, but we could do it if needed
        private bool _isDraft;

        // DDD Patterns comment
        // Using a private collection field, better for DDD Aggregate's encapsulation
        // so OrderItems cannot be added from "outside the AggregateRoot" directly to the collection,
        // but only through the method OrderAggrergateRoot.AddOrderItem() which includes behaviour.
        private readonly List<VenteItem> _venteItems;
        public IReadOnlyCollection<VenteItem> VenteItems => _venteItems;


        public static Vente NewDraft()
        {
            var order = new Vente();
            order._isDraft = true;
            return order;
        }

        protected Vente()
        {
            _venteItems = new List<VenteItem>();
            _isDraft = false;
        }

        public Vente( string userName, int cardTypeId, string cardNumber, string cardSecurityNumber,
                string cardHolderName, DateTime cardExpiration) : this()
        {

            _venteStatusId = VenteStatus.Submitted.Id;
            _orderDate = DateTime.UtcNow;

            // Add the OrderStarterDomainEvent to the domain events collection 
            // to be raised/dispatched when comitting changes into the Database [ After DbContext.SaveChanges() ]
         //   AddOrderStartedDomainEvent(userId, userName, cardTypeId, cardNumber,
           //                            cardSecurityNumber, cardHolderName, cardExpiration);
        }

        // DDD Patterns comment
        // This Order AggregateRoot's method "AddOrderitem()" should be the only way to add Items to the Order,
        // so any behavior (discounts, etc.) and validations are controlled by the AggregateRoot 
        // in order to maintain consistency between the whole Aggregate. 
        public void AddOrderItem(int productId, string productName, decimal unitPrice, decimal discount, string pictureUrl, int units = 1)
        {
            var existingOrderForProduct = _venteItems.Where(o => o.ProductId == productId)
                .SingleOrDefault();

            if (existingOrderForProduct != null)
            {
                //if previous line exist modify it with higher discount  and units..

                if (discount > existingOrderForProduct.GetCurrentDiscount())
                {
                    existingOrderForProduct.SetNewDiscount(discount);
                }

                existingOrderForProduct.AddUnits(units);
            }
            else
            {
                //add validated new order item

                var orderItem = new VenteItem(productId, productName, unitPrice, discount, pictureUrl, units);
                _venteItems.Add(orderItem);
            }
        }


        public decimal GetTotal()
        {
            return _venteItems.Sum(o => o.GetUnits() * o.GetUnitPrice());
        }

    }
}
