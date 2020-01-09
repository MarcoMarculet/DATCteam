using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PulsApiNext.Models
{
    public class Raport : TableEntity
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public int BPM { get; set; }
        public DateTime Data { get; set; }
        public RaportType Type { get; set; }
    }
}