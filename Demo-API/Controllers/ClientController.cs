using Demo_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        public static List<Client> _clients = new List<Client>()
        {
            new Client(){ id= 1, nom="Legrain", prenom="Samuel", email="samuel.legrain@bstorm.be", pass="********", adresse = null},
            new Client(){ id = 2, nom="Chuck", prenom="Norris", email="norris.chuck@bstorm.be", pass="********", adresse = null}
        };

        private static int _nextId = 5;

        [HttpGet]
        public IEnumerable<Client> Get()
        {
            //transformer en array ca sera plus simpel pour transformer en Json
            return _clients.ToArray();
        }

        [HttpGet("{id}")]
        public Client Get(int id)
        {
            //transformer en array ca sera plus simpel pour transformer en Json
            return _clients.Find(c => c.id == id); 
        }

        [HttpPost]
        public int Post(Client entity)
        {
            entity.id = _nextId;
            _clients.Add(entity);
            _nextId++;
            return entity.id;
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            Client client = Get(id);
            if (client is null) return false;
            _clients.Remove(Get(id));
            return true;
        }

        [HttpPut("{id}")]
        public bool Put(int id, Client entity)
        {
            Client client = Get(id);
            if (client is null) return false;
            client.nom = entity.nom;
            client.prenom = entity.prenom;
            client.email = entity.email;
            client.adresse = entity.adresse;
            return true;
        }
    }
}
