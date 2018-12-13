﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Chat_Project
{
    internal class PersonalMessageActions
    {
        private IDataHandler dataHandler;
        private User ActiveUser;

        public PersonalMessageActions(IDataHandler DataProvider, User LoggedInUser)
        {
            dataHandler = DataProvider;
            ActiveUser = LoggedInUser;
        }

        public bool CreateMessage()
        {

            User Receiver = MainActions.SelectUser();
            Console.WriteLine("Send the message");
            string SentPersonalMessage = Console.ReadLine();
            PersonalMessage NewPersonalMessage = new PersonalMessage()
            {
                Sender = ActiveUser,
                Receiver = Receiver,
                PersonalMessageText = SentPersonalMessage
            };
            return true;
        }

        public bool ShowReceivedMessages()
        {
            List<PersonalMessage> ReceivedPersonalMessages = dataHandler.ReadPersonalMessages()
                .Where(ReceivedMessages => ReceivedMessages.Receiver.UserID == ActiveUser.UserID)
                .ToList();

            foreach (PersonalMessage Message in ReceivedPersonalMessages)
            {
                Console.WriteLine($"Ο χρήστης {Message.Sender.Username} σας έστειλε μήνυμα στις {Message.SendDate}: {Message.PersonalMessageText}");
                Message.isRead = true;
            }
            return true;
        }

        public bool ShowSentMessages()
        {
            foreach (PersonalMessage Message in GetSentMessages())
            {
                Console.WriteLine($"{Message.Sender.Username} έστειλες μήνυμα στις {Message.SendDate}: {Message.PersonalMessageText}");
            }
            return true;
        }
        public bool IsMessageRead()
        {
            Console.WriteLine("choose the message you want to check if its read");
            List<PersonalMessage> MessagesToChoose = GetSentMessages();
            List<string> Messages = MessagesToChoose.Select(Message => Message.PersonalMessageText).ToList();
            string MessageChoice = SelectMenu.Vertical(Messages);
            PersonalMessage MessageToCheck = MessagesToChoose.Where(Message => Message.PersonalMessageText == MessageChoice)
                .Single();
            if (MessageToCheck.isRead == true)
            {
                Console.WriteLine("Message was read");
                return true;
            }
            else
            {
                Console.WriteLine("Message not read yet");
            }

            return false;
        }

        public List<PersonalMessage> GetSentMessages()
        {
            return dataHandler.ReadPersonalMessages()
                 .Where(SendMessages => SendMessages.Sender.UserID == ActiveUser.UserID)
                 .ToList();
        }
        public List<PersonalMessage> GetRecievedMessages()
        {
            return dataHandler.ReadPersonalMessages()
                .Where(ReceivedMessages => ReceivedMessages.Receiver.UserID == ActiveUser.UserID).ToList();
        }
        public PersonalMessage GetWantedMessage(User ActiveUser)
        {
            string ReceivedOrSentMessage = SelectMenu.Horizontal(new List<string> { "Received", "Sent" });
            List<PersonalMessage> MessagesToShow = new List<PersonalMessage>();
            switch (ReceivedOrSentMessage)
            {
                case "Received":
                    MessagesToShow = GetRecievedMessages();
                    break;
                case "Sent":
                    MessagesToShow = GetSentMessages();
                    break;
            }
            string SelectedMessage = SelectMenu.Vertical(MessagesToShow.Select(MessageObject => MessageObject.PersonalMessageText).ToList());
            return MessagesToShow.Single(PMessage => PMessage.PersonalMessageText == SelectedMessage);
        }
        public bool UpdateMessage()
        {
            PersonalMessage WantedMessage = GetWantedMessage(ActiveUser);
            Console.Write($"Old Message: {WantedMessage.PersonalMessageText}\nNew Message:");
            return dataHandler.UpdatePersonalMessage(WantedMessage, Console.ReadLine());
        }
        public bool DeleteMessage()
        {
            PersonalMessage WantedMessage = GetWantedMessage(ActiveUser);
            return dataHandler.DeletePersonalMessage(WantedMessage, ActiveUser);
        }
    }
}
