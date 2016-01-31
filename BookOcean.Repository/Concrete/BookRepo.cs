using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookOcean.Repository.Abstract;
using BookOcean.Domain;
using System.Data.Entity.Infrastructure;
namespace BookOcean.Repository.Concrete
{
    public class BookRepo:Connection,IBookSet
    {
        public IEnumerable<Book> GetBookByStandard(int classId)
        {
            try
            {
                IEnumerable<Book> data = this.entities.Books.Where(x => x.ClassID == classId);
               
                return data;
            }
            catch { return null; }
        }
    }
}
