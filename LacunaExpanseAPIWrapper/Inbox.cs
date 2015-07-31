using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace LacunaExpanseAPIWrapper
{
	public class Inbox : CoreClass
	{
		public static string url = "inbox";

		public static string ViewInbox(string sessionID, string tag)
		{
			return "{\"id\":8,\"method\":\"view_inbox\",\"jsonrpc\":\"2.0\",\"params\":[\"" + sessionID + "\",{\"page_number\":1,\"tags\":[\"" + tag + "\"]}]}";
			//return "{\"jsonrpc\":2,\"id\":1,\"method\":\"view_inbox\",\"params\":[\"" + sessionID + "\",{\"tags\":[\"" + tag + "\"],\"page_number\":1}]}";
		}

		public static string ViewInbox(string sessionID)
		{
			return "{\"jsonrpc\":2,\"id\":1,\"method\":\"view_inbox\",\"params\":[\"" + sessionID + "\",{\"page_number\":1}]}";
		}
		public static string ViewSent(string sessionID)
		{
			return "{\"jsonrpc\":2,\"id\":1,\"method\":\"view_sent\",\"params\":[\"" + sessionID + "\",{\"page_number\":1}]}";
		}
		public static string ViewArchive(string sessionID)
		{
			return "{\"jsonrpc\":2,\"id\":1,\"method\":\"view_archive\",\"params\":[\"" + sessionID + "\",{\"page_number\":1}]}";
		}
		public static string ViewTrash(string sessionID)
		{
			return "{\"jsonrpc\":2,\"id\":1,\"method\":\"view_trashed\",\"params\":[\"" + sessionID + "\",{\"page_number\":1}]}";
		}

		public static string ViewInbox(string sessionID, string tag, int pageNumber)
		{
			return "{\"id\":8,\"method\":\"view_inbox\",\"jsonrpc\":\"2.0\",\"params\":[\"" + sessionID + "\",{\"page_number\":"+pageNumber+",\"tags\":[\""+tag+"\"]}]}";
			//return "{\"jsonrpc\":2,\"id\":1,\"method\":\"view_inbox\",\"params\":[\"" + sessionID + "\",{\"tags\":[\"" + tag + "\"],\"page_number\":" + pageNumber + "}]}";
		}

		public static string ReadMessage(string sessionID, string MessageID)
		{
			return BasicRequest(1, "read_message", sessionID, MessageID);
		}

		public static string SendMessage(int requestID, string sessionID, List<string> recipients, string subject, string body)
		{
            string r = "";
			foreach (var s in recipients)
			{
				r += s + ",";
			}
			r = r.Remove(r.Length - 2);
			return "{\"id\":" + requestID + ",\"method\":\"send_message\",\"jsonrpc\":\"2.0\",\"params\":[\"" + sessionID + "\",\"" + r + "\",\"" + subject + "\"," + body + "\",null]}";
		}
		public static string SendMessage(int requestID, string sessionID, string recipients, string subject, string body)
		{
			
			subject = CleanForJSON(subject);
			body = CleanForJSON(body);
			return "{\"id\":" + requestID + ",\"method\":\"send_message\",\"jsonrpc\":\"2.0\",\"params\":[\"" + sessionID + "\",\"" + recipients + "\",\"" + subject + "\",\"" + body + "\",null]}";
			//return i;
		}

		public static string TrashMessages(int requestID, string sessionID, List<string> messageIds)
		{
            string r = "";
			//if(messageIds.Count()>1){
			//	for(int z=0;z <messageIds.Count(); z++){
			//		if(z < (messageIds.Count()-1))
			//			r += messageIds.i.get(z)+",";
			//		else
			//			r+=messageIds.get(z);
			//	}
			//}
			//else 
			//	r = messageIds.get(0);
			return "{\"id\":" + requestID + ",\"method\":\"trash_messages\",\"jsonrpc\":\"2.0\",\"params\":[\"" + sessionID + "\",[\"" + r + "\"]]}";

		}
		public static string TrashMessages(int requestID, string sessionID, string messageId)
		{
			return "{\"id\":" + requestID + ",\"method\":\"trash_messages\",\"jsonrpc\":\"2.0\",\"params\":[\"" + sessionID + "\",[\"" + messageId + "\"]]}";
			//return Request("trash_messages", sessionID, String.valueOf(requestID), messageId);
		}
		public static string ArchiveMessages(int requestID, string sessionID, string messageId)
		{
			return BasicRequest(requestID, "archive_messages", sessionID, messageId);
		}
		public enum MessageTags { Tutorial, Correspondence, Medal, Intelligence, Alert, Attack, Colonization, Complaint, Excavator, Mission, Parliament, Probe, Spies, Trade, Fissure };
		/*enum MessageTags{  //will be leaving this as an option to use in the future, but currently just passing a string directly to the methods instead
			Tutorial, Correspondence, Medal, Intelligence, Alert, Attack, Colonization, Complaint, Excavator, Mission, Parliament, Probe, Spies, Trade, Fissure;
		} */

	}
	/*
	Inbox Methods
	view_inbox ( session_id, [ options ] )
	session_id
	options
	page_number
	tags
	view_archived ( session_id, [ options ])
	view_trashed ( session_id, [ options ])
	view_sent ( session_id, [ options ] )
	read_message ( session_id, message_id )
	session_id
	message_id
	archive_messages ( session_id, message_ids )
	session_id
	message_ids
	trash_messages ( session_id, message_ids )
	session_id
	message_ids
	send_message ( session_id, recipients, subject, body, [ options ] )
	session_id
	recipients
	subject
	body
	options
	in_reply_to
	forward
	*/
}
