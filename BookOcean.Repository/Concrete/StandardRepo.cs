using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookOcean.Domain;
using BookOcean.Repository.Abstract;

namespace BookOcean.Repository.Concrete
{
   public class StandardRepo:Connection, IStandard
    {
       public IEnumerable<Standard> GetAllStandards()
       {
           return this.entities.Standards;

       }
    }
}
