using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Configuration
{
    public class Client
    {
        public string Id { get; set; }
        public string Secret { get; set; }
       
        // www.myapi1.com | www.mayapi2.com (auidence)
        public List<String> Auidences { get; set; }
    }
}
