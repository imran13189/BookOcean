using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookOcean.Domain;
namespace BookOcean.Repository.Abstract
{
    public interface IBookSet
    {
        IEnumerable<Book> GetBookByStandard(int classId);

        List<BookSet> GetClass(int classId);

        







        
    }
}
