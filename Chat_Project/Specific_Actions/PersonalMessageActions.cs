using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Chat_Project
{
    internal class PersonalMessageActions
    {
        IDataHandler dataHandler = new DataHandingOnFile();
        
        public  bool CreateMessage(User Sender,IDataHandler dataHandler)
        {
            MainActions Ma = new MainActions(dataHandler);
            User Receiver = Ma.SelectUser();
            Console.WriteLine("Send the message");
            string SentPersonalMessage = Console.ReadLine();
            PersonalMessage NewPersonalMessage = new PersonalMessage(Sender, Receiver, SentPersonalMessage);
            return true;
        }

        public bool ShowReceivedMessages(User Receiver)
        {
            List<PersonalMessage> ReceivedPersonalMessages =dataHandler.ReadPersonalMessages()
                .Where(ReceivedMessages => ReceivedMessages.Receiver.UserID == Receiver.UserID)
                .ToList();

            foreach (PersonalMessage Message in ReceivedPersonalMessages)
            {
                Console.WriteLine($"Ο χρήστης {Message.Sender.Username} σας έστειλε μήνυμα στις {Message.SendDate}: {Message.PersonalMessageText}");
                Message.isRead = true;
            }
            return true;
        }

        public bool ShowSentMessages(User Sender)
        {
            foreach (PersonalMessage Message in GetSentMessages(Sender))
            {
                Console.WriteLine($"{Message.Sender.Username} έστειλες μήνυμα στις {Message.SendDate}: {Message.PersonalMessageText}");
            }
            return true;
        }
        public  bool IsMessageRead(User Sender)
        {
            Console.WriteLine("choose the message you want to check if its read");
            List<PersonalMessage> MessagesToChoose = GetSentMessages(Sender);            
            List<string>Messages = MessagesToChoose.Select(Message=>Message.PersonalMessageText).ToList();
            string MessageChoice=SelectMenu.Vertical(Messages);
            PersonalMessage MessageToCheck = MessagesToChoose.Where(Message => Message.PersonalMessageText == MessageChoice)
                .Single();
            if (MessageToCheck.isRead == true)
            {
                Console.WriteLine("Message was read");
                return true;
            }            
            else Console.WriteLine("Message not read yet");
            return false;   
        }

        public  List<PersonalMessage> GetSentMessages(User Sender)
        {
            return dataHandler.ReadPersonalMessages()
                 .Where(SendMessages => SendMessages.Sender.UserID == Sender.UserID)
                 .ToList();
        }
        public bool DeleteMessage(PersonalMessage PersonalMessage, IDataHandler DataHandler,User ActiveUser)
        {
            Console.WriteLine("Are you sure to delete this message;");
            return DataHandler.DeletePersonalMessage(PersonalMessage,ActiveUser);
        }
        public bool UpdatePersonalMessage(PersonalMessage OldPersonalMessage, string NewPersonalMessageText,IDataHandler DataHandler)
        {
            return DataHandler.UpdatePersonalMessage(OldPersonalMessage, NewPersonalMessageText);
        }

    }
}
