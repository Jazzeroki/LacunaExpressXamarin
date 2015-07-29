using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper.ResponseModels
{
	public class Response
	{
		public int id;
		public String jsonrpc;
		public Result result;
		public Error error;
	}
}
