using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Entity;
using VM.IRepository;

namespace VM.Repository
{
    public class ClientRepository : VmRepository<Order>, IClientRepository
    {
        public ClientRepository(VmDbContext context) : base(context)
        {

        }
        public bool Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public bool Register(Client client)
        {
            return true;
        }
    }
}
