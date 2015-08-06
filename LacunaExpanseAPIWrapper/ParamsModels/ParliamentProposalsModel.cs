using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper.ParamsModels
{
    public class ParliamentProposalsModel
    {
        public int RequiredLevel { get; set; }
        public string Proposition { get; set; }
        public string Explanation { get; set; }
    }
}
