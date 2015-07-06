using System;
using Xamarin.Forms;
using System.IO;
using System.Threading.Tasks;
using LacunaExpress.Data;
using LacunaExpress.Droid.Data;

[assembly: Dependency(typeof(IsolatedStorageAndroid))]
namespace LacunaExpress.Droid.Data
{
	public class IsolatedStorageAndroid : IIsolatedStorage
	{
		
		public string DocsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
		public async Task SaveTextAsync(string filename, string text)
		{
			string path = Path.Combine(DocsPath, filename);
			using (StreamWriter sw = File.CreateText(path))
			{
				await sw.WriteAsync(text);
				sw.Close();
			}
		}

		public async Task<string> LoadTextAsync(string filename)
		{
			string text;
			string path = Path.Combine(DocsPath, filename);
			using (StreamReader sr = File.OpenText(path))
			{
				text = await sr.ReadToEndAsync();
				sr.Close();
			}
			return text;
		}

		public bool Exists(string filename)
		{
			string path = Path.Combine(DocsPath, filename);
			return File.Exists(path);
		}

		public Stream OpenFile(string filename)
		{
			string path = Path.Combine(DocsPath, filename);
			return File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
		}

		public void Delete(string filename)
		{
			string path = Path.Combine(DocsPath, filename);
			File.Delete(filename);
		}

		public DateTime GetModifiedDate(string filename)
		{
			string path = Path.Combine(DocsPath, filename);
			return File.GetLastWriteTime(filename);
		}
	}
}