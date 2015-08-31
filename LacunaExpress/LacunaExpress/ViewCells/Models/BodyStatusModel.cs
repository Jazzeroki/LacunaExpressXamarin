using LacunaExpanseAPIWrapper.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpress.ViewCells.Models
{
    public class BodyStatusModel
    {
        public string Status { get; set; }
        public string Name { get; set; }
        public string Star { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string Zone { get; set; }
        public Response response { get; set; }
    }
}
