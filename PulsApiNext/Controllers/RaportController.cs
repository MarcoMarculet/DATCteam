using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PulsApiNext.Repositories;
using PulsApiNext.Models;

namespace PulsApiNext.Controllers
{
    [Route("api/[con" +
        "troller]")]
    [ApiController]
    public class RaportController : ControllerBase
    {
        private readonly IRaportRepository _raportRepo;
        public RaportController(IRaportRepository raportRepo)
        {
            _raportRepo = raportRepo;
        }

        [HttpGet]
        public Task<IEnumerable<Raport>> Get()
        {
            return _raportRepo.GetAllRaports();
        }

        public Task<Raport> GetById(int id)
        {
            return _raportRepo.GetRaportById(id);
        }

        [HttpPost]
        public void PostArduino([FromBody] Raport value)
        {

        }

        [HttpPost]
        public void Post([FromBody] Raport value)
        {
            value.PartitionKey = Convert.ToString(value.Type);
            value.RowKey = Convert.ToString(value.Id);
            if (value == null)
            {
                return;
            }
            try
            {
                _raportRepo.CreateRaport(value);
            }
            catch (Exception)
            {
                Console.WriteLine("Not a valid response received.");
            }
        }

    }
}