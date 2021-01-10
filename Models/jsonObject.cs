using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emailApi.Models
{
    public class jsonObject
    {
        public string fromEmail { get; set; }

        public string toAddress { get; set; }

        public string subject { get; set; }

        public string body { get; set; }
    }
}
