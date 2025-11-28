using Manzili.Data;
using Manzili.Data.Models;
using Manzili.Repositories.GenericRepository;

namespace Manzili.Repositories.AdressRepository
{
    public class AddressRepo : GenericRepo<Address>, IAddressRepo
    {
        public AddressRepo(ManziliDbContext context) : base(context)
        {
        }
    }
}
