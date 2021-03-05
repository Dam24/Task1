using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmailClient;
using System.Collections.Generic;
namespace EmailClientTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VerifySMTPCanBeInitialized()
        {
            string HostName = "Damian";
            int Port = 222;
            SMTPServer Server = new SMTPServer(HostName, Port);
            Assert.AreEqual(HostName, Server.GetHostName(), "Acount was not created correctly");
            Assert.AreEqual(Port, Server.GetPort(), "Acount was not created correctly");
        }
        [TestMethod]
        public void VerifyCanCreateOutlookCLients()
        {
            string User1 = "Damian.Villanueva";
            string User2 = "Pepe.Perez";
            string HostName = "Damian";
            int First = 0;
            int Second = 1;
            int Port = 222;
            SMTPServer Server = new SMTPServer(HostName, Port);
            Server.NewSession(User1);
            Server.NewSession(User2);
            Assert.AreEqual(User1, Server.GetSessions()[First].GetUserName(), "Acount was not created correctly");
            Assert.AreEqual(User2, Server.GetSessions()[Second].GetUserName(), "Acount was not created correctly");
        }

        [TestMethod]
        public void VerifyDefaultFolders()
        {
            string UserName = "Damian.Villanueva";
            string Inbox = "Inbox";
            string Outbox = "Outbox";
            string Trash = "Trash";

            OutlookClient Client = new OutlookClient(UserName);
            Assert.AreEqual(Inbox, Client.GetFolders()[Inbox].GetName(), "Inbox folder was not created");
            Assert.AreEqual(Outbox, Client.GetFolders()[Outbox].GetName(), "Outbox folder was not created");
            Assert.AreEqual(Trash, Client.GetFolders()[Trash].GetName(), "Trash folder was not created");            
        }

        [TestMethod]
        public void VerifyCanCreateAndDeletePersonalizedFolders()
        {
            string UserName = "Damian.Villanueva";
            string FolderName1 = "Private Damian";
            string FolderName2 = "TestedFolder";

            OutlookClient Client = new OutlookClient(UserName);
            Client.CreateFolder(FolderName1);
            Client.CreateFolder(FolderName2);
            Assert.AreEqual(FolderName1, Client.GetFolders()[FolderName1].GetName(), "Personalized folder was not created");
            Assert.AreEqual(FolderName2, Client.GetFolders()[FolderName2].GetName(), "Personalized folder was not created");
            Client.DeleteFolder(Client.GetFolders()[FolderName2]);
            
            Assert.IsFalse(Client.GetFolders().ContainsKey(FolderName2));
            Assert.AreEqual(FolderName1, Client.GetFolders()[FolderName1].GetName(), "Personalized folder was not created");
        }

        [TestMethod]
        public void VerifyCanCreateAndDeleteMessages()
        {
            string UserName = "Damian.Villanueva";
            string Subject = "First Task";
            string To = "Einar.Rocha";
            string Cc = "Pepe.Perez";
            string Body = "THis is the first task";
            string Outbox = "Outbox";
            OutlookClient Client = new OutlookClient(UserName);
            Client.NewMessage(Subject, To, Cc, Body);
            List<Message> Messages = Client.GetFolders()[Outbox].GetMessages();
            var itemCount = Messages.Count;
            Message CurrentMessage = Messages[itemCount - 1];

            Assert.AreEqual(Subject, CurrentMessage.GetSubject());
            Assert.AreEqual(To, CurrentMessage.GetTo());
            Assert.AreEqual(Cc, CurrentMessage.GetCc());
            Assert.AreEqual(Body, CurrentMessage.GetBody());
            Client.GetFolders()[Outbox].RemoveMessage(CurrentMessage);
            Assert.AreEqual(itemCount - 1, Client.GetFolders()[Outbox].GetMessages().Count);
        }

        [TestMethod]
        public void VerifyVerifyMessageCanBeMoved()
        {
            string UserName = "Damian.Villanueva";
            string Subject = "First Task";
            string To = "Einar.Rocha";
            string Cc = "Pepe.Perez";
            string Body = "THis is the first task";
            string Outbox = "Outbox";
            string FolderName = "Folder Damian";
            OutlookClient Client = new OutlookClient(UserName);
            Client.NewMessage(Subject, To, Cc, Body);
            List<Message> Messages = Client.GetFolders()[Outbox].GetMessages();
            var itemCount = Messages.Count;
            Message CurrentMessage = Messages[itemCount - 1];
            Client.CreateFolder(FolderName);
            Client.MoveMessage(CurrentMessage, FolderName);
            Message MovedMessage = Client.GetFolders()[FolderName].GetMessages()[0];

            Assert.AreEqual(itemCount - 1, Client.GetFolders()[Outbox].GetMessages().Count);            
            Assert.AreEqual(Subject, MovedMessage.GetSubject());
            Assert.AreEqual(To, MovedMessage.GetTo());
            Assert.AreEqual(Cc, MovedMessage.GetCc());
            Assert.AreEqual(Body, MovedMessage.GetBody());
            Assert.AreEqual(itemCount, Client.GetFolders()[FolderName].GetMessages().Count);
        }

    }
}
