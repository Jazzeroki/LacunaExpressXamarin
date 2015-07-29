using LacunaExpanseAPIWrapper.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpress.Scripts
{
	public class BuildingToolsScripts
	{
		public static List<string> GetDamagedBuildingIDs(Dictionary<string, Building> buildings) 
		{
			List<string> bList = (from b in buildings
						where Convert.ToInt16(b.Value.efficiency) < 100
						select b.Key).ToList();
			return bList;			
		}

		public static int GetAvgBuildingLevel(Dictionary<string, Building> buildings)
		{
			int count = 0;
			double levelSum = 0;
			foreach (var b in buildings)
			{
				levelSum += Convert.ToInt16(b.Value.level);
				count++;
			}

			int avg = Convert.ToInt16(levelSum/count);
			return avg;
		}
		public static List<string> GetBuildingsForUpgradeByLowestLevel(Dictionary<string, Building> buildings) 
		{
			var ordered = buildings.OrderBy(x => x.Value.level);
			List<string> buildingIDs = new List<string>();
			foreach (var b in ordered)
			{
				if (!IsGlyphBuilding(b.Value)) //also need to check against level
					buildingIDs.Add(b.Key);
			}
			return buildingIDs;
		}

		public static bool IsGlyphBuilding(Building building)
		{
			if (building.url == "essentiavein")
				return true;
			if (building.url == "algaepond")
				return true;
			if (building.url == "amalgusmeadow")
				return true;
			if (building.url == "beach")
				return true;
			if (building.url == "beeldebannest")
				return true;
			if (building.url == "blackholegenerator")
				return true;
			if (building.url == "citadelofknope")
				return true;
			if (building.url == "crashedshipsite")
				return true;
			if (building.url == "crater")
				return true;
			if (building.url == "geothermalvent")
				return true;
			if (building.url == "gratchesgauntlet")
				return true;
			if (building.url == "greatballofjunk")
				return true;
			if (building.url == "grove")
				return true;
			if (building.url == "hallsofvrbansk")
				return true;
			if (building.url == "junkhengesculpture")
				return true;
			if (building.url == "kasternskeep")
				return true;
			if (building.url == "lake")
				return true;
			if (building.url == "lagoon")
				return true;
			if (building.url == "lapisforest")
				return true;
			if (building.url == "libraryofjith")
				return true;
			if (building.url == "malcudfield")
				return true;
			if (building.url == "massadshenge")
				return true;
			if (building.url == "metaljunkarches")
				return true;
			if (building.url == "naturalspring")
				return true;
			if (building.url == "oracleofanid")
				return true;
			if (building.url == "pantheonofhagness")
				return true;
			if (building.url == "pyramidjunksculpture")
				return true;
			if (building.url == "ravine")
				return true;
			if (building.url == "rockyoutcrop")
				return true;
			if (building.url == "sand")
				return true;
			if (building.url == "spacejunkpark")
				return true;
			if (building.url == "templeofthedrajilites")
				return true;
			if (building.url == "thedillonforge")
				return true;
			if (building.url == "volcano")
				return true;
			else
				return false;
		}
	}
}
