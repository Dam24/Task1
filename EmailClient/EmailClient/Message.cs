using System;
using System.Collections.Generic;
using System.Text;

namespace EmailClient
{
	public class Message
	{
        protected string Subject;
        protected string To;
        protected string Cc;
        protected string Body;
        protected DateTime Date;
        protected string FolderOwner;

        public Message(string Subject, string FolderOwner="Outbox")
        {
            SetSubject(Subject);
            SetFolderOwner(FolderOwner);
        }

        public void SetSubject(string Subject)
        {
            this.Subject = Subject;
        }

        public void SetTo(string To)
        {
            this.To = To;
        }

        public void SetCc(string Cc)
        {
            this.Cc = Cc;
        }

        public void SetBody(string Body)
        {
            this.Body = Body;
        }

        public void SetDate(DateTime Date)
        {
            this.Date = Date;
        }

        public void SetFolderOwner(string FolderOwner = "Outbox")
        {
            this.FolderOwner = FolderOwner;
        }

        public string GetSubject()
        {
            return this.Subject;
        }
        public string GetTo()
        {
            return this.To;
        }
        public string GetCc()
        {
            return this.Cc;
        }
        public string GetBody()
        {
            return this.Body;
        }
        public string GetFolderOwner()
        {
            return this.FolderOwner;
        }

    }
}
