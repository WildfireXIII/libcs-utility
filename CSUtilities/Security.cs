//*************************************************************
//  File: Security.cs
//  Date created: 12/15/2016
//  Date edited: 12/15/2016
//  Author: Nathan Martindale
//  Copyright © 2016 Digital Warrior Labs
//  Description: Collection of functions dealing with simple security measures
//*************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;

namespace DWL.Utility
{
	public class Security
	{
		// thanks to http://www.codeshare.co.uk/blog/sha-256-and-sha-512-hash-examples/
		public static string Sha256Hash(string sString)
		{
			SHA256 p256 = SHA256Managed.Create();
			byte[] aBytes = Encoding.UTF8.GetBytes(sString);
			byte[] aHashBytes = p256.ComputeHash(aBytes);
			string sHash = GetStringFromHash(aHashBytes);
			return sHash;
		}

		private static string GetStringFromHash(byte[] aHashBytes)
		{
			StringBuilder pResult = new StringBuilder();
			for (int i = 0; i < aHashBytes.Length; i++)
			{
				pResult.Append(aHashBytes[i].ToString("X2"));
			}
			return pResult.ToString();
		}
	}
}
