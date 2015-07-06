using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpress.Data
{
	public interface IIsolatedStorage
	{
		Task SaveTextAsync(string filename, string text);
		Task<string> LoadTextAsync(string filename);
		Stream OpenFile(string filename);
		bool Exists(string filename);
		void Delete(string filename);
	}
}
