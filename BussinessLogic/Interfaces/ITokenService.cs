using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Model.DatabaseModels;

namespace WebApp.BussinessLogic.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
