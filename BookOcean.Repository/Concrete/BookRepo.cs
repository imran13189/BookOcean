using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookOcean.Repository.Abstract;
using BookOcean.Domain;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;

namespace BookOcean.Repository.Concrete
{
    public class BookRepo:Connection,IBook
    {
       public bool GetBook()
        {
            return true;
        }

        public string AddBook(Book model)
        {
            try
            {
                Book book = new Book();
                book.BookName = model.BookName;
                book.Publication = model.Publication;
                book.Edition = model.Edition;
                this.entities.Books.Add(book);
                entities.SaveChanges();
                return "Add Succefully";
            }
            catch
            {
                return "Pleace Retry";
            }

            //return  "AddBook";
        }
        

        public List<Book> GetBookBindData()
        {
            return this.entities.Books.ToList();
        }
        

       public Book GetBook(int bookId)
        {
           return entities.Books.FirstOrDefault(x => x.BookId == bookId);
        }
        public Book EditBook(Book model)
        {
            this.entities.Entry(model).State = System.Data.Entity.EntityState.Modified;
            this .entities.SaveChanges();
            return model;
        }

        public Book DelBook(int bookId)
        {
            return entities.Books.FirstOrDefault(x => x.BookId == bookId);
        }

        public Book DelBook(Book model)
        {
            this.entities.Books.Remove(model);
            this.entities.SaveChanges();
            return model;

        }

        public List<Book> GetBooks()
        {

            SqlDataReader reader;
            SqlCommand cmd = this.DBConn("GetBooks");
            cmd.Parameters.Add(new SqlParameter("@BookId", 1));
            reader = cmd.ExecuteReader();
            List<Book> books = ((IObjectContextAdapter)entities).ObjectContext.Translate<Book>(reader).ToList();
            this.conn.Close();
            return books;
            
        }


    }
}
