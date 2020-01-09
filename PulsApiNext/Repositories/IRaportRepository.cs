using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using PulsApiNext.Models;

namespace PulsApiNext.Repositories
{
    public interface IRaportRepository
    {
        public Task<IEnumerable<Raport>> GetAllRaports();
        public Task<TableResult> CreateRaport(Raport raport);
        public Task<Raport> GetRaportById(int id);
    }
}
