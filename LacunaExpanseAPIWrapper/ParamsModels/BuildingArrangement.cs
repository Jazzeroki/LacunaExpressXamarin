using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper.ParamsModels
{
    public class BuildingArrangement
    {
        public BuildingArrangement(string x, string y, string buildingID)
        {
            X = x;
            Y = y;
            BuildingID = buildingID;
        }
        public string X, Y, BuildingID;
    }
}
