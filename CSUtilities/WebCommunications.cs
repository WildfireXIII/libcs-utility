using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Web;
using System.Net;

namespace DWL.Utility
{
	public class WebCommunications
	{
		// static variables
		private static string s_sAuthKey = "";

		// static properties
		public static string AuthKey { set { s_sAuthKey = value; } }
		
		// static methods
		public static string SendGetRequest(string sURL, bool bAuthorize = false)
		{
			WebRequest pRequest = WebRequest.Create(sURL);
			pRequest.Method = "GET";
			AddAuthorization(pRequest, bAuthorize);
			return ReadResponse(pRequest);
		}

		public static string SendPostRequest(string sURL, string sBody, bool bAuthorize = false)
		{
			// create the request and set it's method
			WebRequest pRequest = WebRequest.Create(sURL);
			pRequest.Method = "POST";

			AddAuthorization(pRequest, bAuthorize);

			// add body to request
			byte[] aBodyBytes = Encoding.ASCII.GetBytes(sBody);
			pRequest.ContentLength = aBodyBytes.Length;
			Stream pStream = pRequest.GetRequestStream();
			pStream.Write(aBodyBytes, 0, aBodyBytes.Length);

			return ReadResponse(pRequest);
		}

		private static void AddAuthorization(WebRequest pRequest, bool bAuthorize = false)
		{
			// add authorization key if specified
			if (bAuthorize) { pRequest.Headers.Add("AUTH", s_sAuthKey); }
		}

		// send the specified request and return the response as a string
		private static string ReadResponse(WebRequest pRequest)
		{
			// send the request
			WebResponse pResponse = pRequest.GetResponse();

			// read the response content
			StreamReader pStreamReader = new StreamReader(pResponse.GetResponseStream());
			string sResponse = pStreamReader.ReadToEnd();
			return sResponse;
		}
	}
}