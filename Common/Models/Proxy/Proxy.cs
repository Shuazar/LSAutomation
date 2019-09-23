using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Proxy
    {
        [Key]
        public int Id { get; set; }
        public string IP { get; set; }
        public string PORT { get; set; }
        public string ANON { get; set; }
        public string COUNTRY { get; set; }   
        public string ISO { get; set; }
        
    }
}
