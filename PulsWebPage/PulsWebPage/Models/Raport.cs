using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PulsWebPage.Models

{
    public class Raport : TableEntity
    {
        public string Atlet { get; set; }
        public int BPM { get; set; }
        public DateTime Data { get; set; }
    }
}