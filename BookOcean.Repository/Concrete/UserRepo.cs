using BookOcean.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookOcean.Repository.Abstract;

namespace BookOcean.Repository.Concrete
{
   public class UserRepo:Connection, IUser
    {
        public bool Register(RegisterModel model)
        {
            return true;
        }
    }
}
