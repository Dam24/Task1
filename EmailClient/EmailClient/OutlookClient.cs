using System;
using System.Collections.Generic;
using System.Text;

namespace EmailClient
{
	public class OutlookClient
	{
        private string UserName;
        private string password;
        public Dictionary<string, Folder> Folders;
        protected SMTPServer SMPTP;
        public OutlookClient(string UserName)
        {
            this.UserName = UserName;
            this.Folders = new Dictionary<string, Folder>();
            this.Folders.Add("Inbox", new Inbox("Inbox"));
            this.Folders.Add("Outbox", new Outbox("Outbox"));
            this.Folders.Add("Trash", new Trash("Trash"));
        }
        public string GetUserName()
        {
            return this.UserName;
        }

        public Dictionary<string, Folder> GetFolders()
        {
            return Folders;
        }

        public void CreateFolder(string Name)
        {
            this.Folders.Add(Name, new OtherFolder(Name));
        }

        public void DeleteFolder(Folder Folder)
        {
            this.Folders.Remove(Folder.Name);
            Console.WriteLine("Folder successfully Deleted");
        }

        public void NewMessage(string Subject, string To, string Cc, string Body)
        {
            Message NewMessage = new Message(Subject, "Outbox");
            NewMessage.SetTo(To);
            NewMessage.SetCc(Cc);
            NewMessage.SetBody(Body);
            NewMessage.SetDate(DateTime.Now);
            this.Folders["Outbox"].AddMessage(NewMessage);
        }

        public void MoveMessage(Message Message, string TargetFolderName)
        {
            this.Folders[Message.GetFolderOwner()].RemoveMessage(Message);
            this.Folders[TargetFolderName].AddMessage(Message);
        }
    }
}
