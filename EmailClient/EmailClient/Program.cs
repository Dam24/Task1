using System;

namespace EmailClient
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			//OutlookClient Client = new OutlookClient("damian", 7777);

			Folder f = new Inbox();
			Console.WriteLine(f.Name);




		}
	}
}
