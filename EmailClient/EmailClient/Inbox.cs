using System;
using System.Collections.Generic;
using System.Text;

namespace EmailClient
{
	class Inbox: Folder
	{
		public Inbox(string Name = "Inbox"): base(Name: Name)
		{
		}
	}
}
