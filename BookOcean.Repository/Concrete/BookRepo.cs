﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookOcean.Repository.Abstract;
using BookOcean.Domain;
using System.Data.Entity.Infrastructure;
namespace BookOcean.Repository.Concrete
{
    public class BookRepo:Connection,IBook
    {
       public bool GetBook()
        {
            return true;
        }
    }
}
