using System;
using Xamarin.Forms;
using System.IO;
using System.Threading.Tasks;
using LacunaExpress.Data;
using LacunaExpress.iOS.Data;
using Foundation;

[assembly: Dependency(typeof(IsolatedStorageios))]
namespace LacunaExpress.iOS.Data
{
    class IsolatedStorageios : IIsolatedStorage
    {
        protected static string DocumentsPath
        {
            get
            {
                var documentsDirUrl = NSFileManager.DefaultManager.GetUrls(NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User).First();
                return documentsDirUrl.Path;
            }
        }

        public async Task SaveTextAsync(string filename, string text)
        {
            string path = BuildPathForDocumentsDir(filename);
            using (StreamWriter sw = File.CreateText(path))
            {
                await sw.WriteAsync(text);
            }
        }

        public async Task<string> LoadTextAsync(string filename)
        {
            string path = BuildPathForDocumentsDir(filename);
            using (StreamReader sr = File.OpenText(path))
            {
                return await sr.ReadToEndAsync();
            }
        }

        protected static string BuildPathForDocumentsDir(string fileName)
        {
            return Path.Combine(DocumentsPath, fileName);
        }

        public bool Exists(string filename)
        {
            string path = BuildPathForDocumentsDir(filename);
            return File.Exists(path);
        }

        public Stream OpenFile(string filename)
        {
            string path = BuildPathForDocumentsDir(filename);
            return File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        public void Delete(string filename)
        {
            string path = BuildPathForDocumentsDir(filename);
            File.Delete(filename);
        }

        public DateTime GetModifiedDate(string filename)
        {
            string path = BuildPathForDocumentsDir(filename);
            var attrib = NSFileManager.DefaultManager.GetAttributes(path);
            return NSDateToDateTime(attrib.ModificationDate);
        }

        public static DateTime NSDateToDateTime(NSDate date)
        {
            DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(
                new DateTime(2001, 1, 1, 0, 0, 0));
            return reference.AddSeconds(date.SecondsSinceReferenceDate);
        }
    }
}
