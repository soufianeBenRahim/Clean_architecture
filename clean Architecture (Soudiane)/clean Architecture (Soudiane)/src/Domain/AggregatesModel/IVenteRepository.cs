
using Clean_Architecture_Soufiane.Domain.Seedwork;
using System.Threading.Tasks;

namespace Clean_Architecture_Soufiane.Domain.AggregatesModel
{
    //This is just the RepositoryContracts or Interface defined at the Domain Layer
    //as requisite for the Order Aggregate

    public interface IVenteRepository : IRepository<Vente>
    {
        Vente Add(Vente vente);

        void Update(Vente order);

        Task<Vente> GetAsync(int orderId);
    }
}
