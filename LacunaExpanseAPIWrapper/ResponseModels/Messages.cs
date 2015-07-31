using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper.ResponseModels
{
	public class Messages
	{
		public string from, to, subject, date, in_reply_to, body_preview, body, has_read, has_replied, has_archived, has_trashed, id, from_id, to_id;
		public string[] tags, recipients;
		//public int has_read, has_replied, has_archived, has_trashed, id, from_id, to_id;
			
	}
}
