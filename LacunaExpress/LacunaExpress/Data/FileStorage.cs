using LacunaExpanseAPIWrapper.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Newtonsoft.Json.JsonConvert;

namespace LacunaExpress.Data
{
    public class FileStorage
    {
        private static string StarMapFile { get; } = "stars.jazz";
        static IIsolatedStorage  Storage = DependencyService.Get<IIsolatedStorage>();

        public static async void SaveStarsAsync(List<Stars> stars) =>
            await Storage.SaveTextAsync(StarMapFile, Newtonsoft.Json.JsonConvert.SerializeObject(stars));
        public static async Task<List<Stars>> LoadStarsAsync()
        {
            if (Storage.Exists(StarMapFile))
            {
                var list = await Storage.LoadTextAsync(StarMapFile);
                return DeserializeObject<List<Stars>>(list);
            }
            else
                return null;          
        }

    }
}
