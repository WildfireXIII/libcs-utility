﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DWL.Utility;

namespace CSUtilities
{
	class Testing
	{
		public static void Main(string[] args)
		{
			WebCommunications.AuthKey = "54003c32a";
			//string sResponse = WebCommunications.SendPostRequest("https://httpbin.org/post", "Hello world!", true);
			//string sResponse = WebCommunications.SendGetRequest("https://httpbin.org/cache", true);
			string sResponse = WebCommunications.SendGetRequest("http://dwlapi.azurewebsites.net/api/reflection/KnowledgeBaseServer/KnowledgeBaseServer/KnowledgeServer/ConstructPage?squery=Genetic_Algorithm", true);
			//string sResponse = WebCommunications.SendGetRequest("https://httpbin.org/get?number=2", true);
			Console.WriteLine(sResponse);

			Console.ReadKey();
		}
	}
}
