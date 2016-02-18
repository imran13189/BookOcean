using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOcean.Domain.Common
{
   public class DataObject
    {
        public int limit { get; set; }
        public int offset { get; set; }
        public string order { get; set; }
    }
}
