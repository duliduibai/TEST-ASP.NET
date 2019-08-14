using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Entity;

namespace VM.IRepository
{
    public interface IClientRepository
    {
        bool Register(Client client);
        bool Login(string userName, string password);
    }
}
