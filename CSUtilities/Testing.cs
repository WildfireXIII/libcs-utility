using System;
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
			string sResponse = WebCommunications.SendPostRequest("https://httpbin.org/post", "Hello world!");
			Console.WriteLine(sResponse);

			Console.ReadKey();
		}
	}
}
