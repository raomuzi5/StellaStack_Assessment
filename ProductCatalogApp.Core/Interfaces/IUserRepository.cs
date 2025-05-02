using ProductCatalogApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogApp.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByUsernameAsync(string username);
    }

}
