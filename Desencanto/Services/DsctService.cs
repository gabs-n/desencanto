
using.System.Text.Json;
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

        } 
    }
}