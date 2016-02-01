using BookOcean.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookOcean.Domain.Entities;
using BookOcean.Repository.Abstract;

namespace BookOcean.Repository.Concrete
{
   public class BookSetRepo:Connection,IBookSet
    {
        public IEnumerable<Book> GetBookByStandard(int classId)
        {
            try
            {
                IEnumerable<Book> data=null;//this.entities.Books.Where(x => x.ClassID == classId);

                return data;
            }
            catch { return null; }
        }
    }
}
