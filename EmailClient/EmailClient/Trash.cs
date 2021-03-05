using System;
using System.Collections.Generic;
using System.Text;

namespace EmailClient
{
	class Trash: Folder
	{
        public Trash(string Name = "Trash") : base(Name)
        {
        }

        public void DeleteMessage(Message Message)
        {
            for (var i = 0; i < this.Messages.Count; i++)
            {
                if (this.Messages[i] == Message)
                {
                    this.Messages.RemoveAt(i);
                }
            }
            Console.WriteLine("Message correctly Deleted");
        }
        public void RestoreMessage(Message Message)
        {


        }
    }
}
