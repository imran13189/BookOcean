using BookOcean.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOcean.Repository.Abstract
{
  public  interface IBook
    {
        bool GetBook();
        string AddBook(Book model);

        List<Book> GetBookBindData();

        Book GetBook(int bookId);

        Book DelBook(int bookId);
        Book EditBook(Book model);

        List<Book> GetBooks();
            
    }
}

