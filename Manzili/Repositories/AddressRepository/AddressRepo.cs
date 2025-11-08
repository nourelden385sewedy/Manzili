using Manzili.Models;
using Manzili.Repositories.GenericRepository;

namespace Manzili.Repositories.AddressRepository
{
    public class AddressRepo : GenericRepo<Address>, IAddressRepo
    {
        public AddressRepo(ManziliDbContext context) : base(context)
        {
        }
    }
}
