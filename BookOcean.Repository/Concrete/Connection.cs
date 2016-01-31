using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookOcean.Domain;
namespace BookOcean.Repository.Concrete
{
    public abstract  class Connection
    {
    public POSEntities entities;
    public Connection()
    {
        this.entities = new POSEntities();
    }
    }
}
