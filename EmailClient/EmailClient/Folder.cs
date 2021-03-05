using System;
using System.Collections.Generic;
using System.Text;

namespace EmailClient
{
	public class Folder
	{
        public string Name;
        protected List<Message> Messages;

        public Folder(string Name)
        {
            this.Name = Name;
            this.Messages = new List<Message>();
        }

        public string GetName()
        {
            return this.Name;
        }

        public void AddMessage(Message NewMessage)
        {
            this.Messages.Add(NewMessage);
        }

        public void RemoveMessage(Message Message)
        {
            for (var i = 0; i < this.Messages.Count; i++)
            {
                if (this.Messages[i] == Message)
                {
                    this.Messages.RemoveAt(i);
                }
            }
        }

        public List<Message> GetMessages()
        {
            return this.Messages;
        }

        public void MoveToTrash(string Subject)
        {

        }

        public void EmptyFolder()
        {
            this.Messages.Clear();
        }
    }
}
