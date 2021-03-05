using System;
using System.Collections.Generic;
using System.Text;

namespace EmailClient
{
	public class SMTPServer
	{
        private string HostName;
        private int Port;
        protected List<OutlookClient> Sessions;
        public SMTPServer(string HostName, int Port)
        {
            SetHostName(HostName);
            SetPort(Port);
            this.Sessions = new List<OutlookClient>();
            //this.Sessions.Add(new OutlookClient(this.HostName, this.Port));
        }

        public void SetHostName(string HostName)
        {
            this.HostName = HostName;
        }
        
        public void SetPort(int Port)
        {
            this.Port = Port;
        }

        public string GetHostName()
        {
            return this.HostName;
        }

        public int GetPort()
        {
            return this.Port;
        }

        public void NewSession(string UserName)
        {
            this.Sessions.Add(new OutlookClient(UserName));
        }

        public List<OutlookClient> GetSessions()
        {
            return this.Sessions;
        }
        public void SendMessage(Message Message)
        {
            for (var i = 0; i < this.Sessions.Count; i++)
            {
                if (this.Sessions[i].GetUserName() == Message.GetTo())
                {
                    this.Sessions[i].Folders["Inbox"].AddMessage(Message);
                }
            }

        }


    }
}
