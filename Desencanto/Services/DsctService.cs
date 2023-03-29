using System.Text.Json;
using Desencanto.Models;

namespace Desencanto.Services
{
    public class DsctService : IDsctService
    {
        private readonly IHttpContextAccessor _session;
        private readonly string personagemFile = @"Data\personagens.json";
        private readonly string tiposFile = @"Data\tipos.json";

        public DsctService(IHttpContextAccessor session)
        {
            _session = session;
            PopularSessao();
        }

        public List<Personagem> GetPersonagens()
        {
            PopularSessao();
            var personagens = JsonSerializer.Deserialize<List<Personagem>>
            (_session.HttpContext.Session.GetString("Personagens"));
            return personagens;
        }
        public List<Tipo> GetTipos()
        {
            PopularSessao();
            var tipos = JsonSerializer.Deserialize<List<Tipo>>
            (_session.HttpContext.Session.GetString("Tipos"));
            return tipos;
        }
        public Personagem GetPersonagem(int Numero)
        {
            var personagens = GetPersonagens();
            return personagens.Where(p => p.Numero == Numero).FirstOrDefault();
        }
        public DesencantoDto GetDesencantoDto() 
        {
            var persons = new DesencantoDto()
            {
                Personagens = GetPersonagens(),
                Tipos = GetTipos()
            };
            return persons;
        }
        public DetailsDto GetDetailedPersonagem(int Numero)
        {
            var personagens = GetPersonagens();
            var person = new DetailsDto()
            {
                Current = personagens.Where(p => p.Numero == Numero)
            .FirstOrDefault(),
                Prior = personagens.OrderByDescending(p => p.Numero)
            .FirstOrDefault(p => p.Numero < Numero),
                Next = personagens.OrderBy(p => p.Numero)
            .FirstOrDefault(p => p.Numero > Numero),
            };
            return person;
        }
        public Tipo GetTipo(string Nome)
        {
            var tipos = GetTipos();
            return tipos.Where(t => t.Nome == Nome).FirstOrDefault();
        }
        private void PopularSessao()
        {
            if (string.IsNullOrEmpty(_session.HttpContext.Session.GetString("Tipos")))
            {
                _session.HttpContext.Session
                .SetString("Personagens", LerArquivo(personagemFile));
                _session.HttpContext.Session
                .SetString("Tipos", LerArquivo(tiposFile));
            }
        }
        private string LerArquivo(string fileName)
        {
            using (StreamReader leitor = new StreamReader(fileName))
            {
                string dados = leitor.ReadToEnd();
                return dados;
            }
        }
    }

} 

