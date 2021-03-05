using System;
using System.Collections.Generic;
using System.Text;

namespace EmailClient
{
	class Outbox: Folder
	{
		public Outbox(string Name = "Outbox") : base(Name)
		{
		}
	}
}
