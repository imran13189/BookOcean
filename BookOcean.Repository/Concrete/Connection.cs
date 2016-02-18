using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookOcean.Domain;
using System.Data.SqlClient;
using System.Data.Entity.Core.EntityClient;
using System.Data;

namespace BookOcean.Repository.Concrete
{
    public abstract  class Connection
    {
    public POSEntities entities;
    public SqlConnection conn = null;
        public Connection()
    {
        this.entities = new POSEntities();
    }

        public SqlCommand DBConn(string ProcedureName)
        {
            
            SqlDataReader rdr = null;
           // var connn = entities.Database.Connection.;
          //  var ent = connn as EntityConnection;
            string ConnectionString = entities.Database.Connection.ConnectionString;
            conn = new SqlConnection(ConnectionString);
            conn.Open();

            // 1. create a command object identifying
            // the stored procedure
            SqlCommand cmd = new SqlCommand(ProcedureName, conn);

            // 2. set the command object so it knows
            // to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            return cmd;
        }
    }
}
