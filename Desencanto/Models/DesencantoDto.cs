using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desencanto.Models
{
    public class DesencantoDto
    {
        public List<Tipo> Tipos { get; set; }
        public List<Personagem> Personagens { get; set; }
    }
}