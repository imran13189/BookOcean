using BookOcean.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookOcean.Repository.Abstract;
using BookOcean.Domain;

namespace BookOcean.Repository.Concrete
{
   public class UserRepo:Connection, IUser
    {
        public string Register(RegisterModel model)
        {
            try
            {
                User user = new User();
                user.CompanyName = model.CompanyName;
                user.Email = model.Email;
                user.Password = model.Password;
                user.CityId = model.CityId;
                this.entities.Users.Add(user);
                entities.SaveChanges();
                return "Registered Succefully";
            }
            catch { return "Not Register"; }
        }
       public bool IsUserExist(LoginModel model)
        {
            try
            {
                if (this.entities.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password) == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
