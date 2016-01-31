using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookOcean.Domain.Entities;
namespace BookOcean.Repository.Abstract
{
    public interface IUser
    {
        string Register(RegisterModel model);
        bool IsUserExist(LoginModel model);
       
    }
}
