using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desencanto.Models;
namespace Desencanto.Services
{
    public interface IDsctService
    {
        List<Personagem> GetPersonagens();
        List<Tipo> GetTipos();
        Personagem GetPersonagem(int Numero);
        DesencantoDto GetDesencantoDto();
        DetailsDto GetDetailedPersonagem(int Numero);
        Tipo GetTipo(string Nome);
    }
}