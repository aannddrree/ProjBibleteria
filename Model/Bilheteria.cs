using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Bilheteria
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataEvento { get; set; }
        public string Local { get; set; }
        public int QtdPessoas { get; set; }
    }
}
