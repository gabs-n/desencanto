using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desencanto.Models
{
    public class Personagem
    {
        public string Numero { get; set; }
        public string Nome { get; set; }
        public string Descrição { get; set; }
        public string Especie { get; set; }
        public List<string> Tipo { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
        public string Imagem { get; set; }
        
        public Personagem()
        {
            Tipo = new List<string>();
        }
    }
}