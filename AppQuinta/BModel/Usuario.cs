using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BModel{
    public class Usuario    {
        public int IdUser { get; set; }
        public string NomeUser { get; set; }
        public string Cargo { get; set; }
        public DateTime DataNasc { get; set; }
    }
}