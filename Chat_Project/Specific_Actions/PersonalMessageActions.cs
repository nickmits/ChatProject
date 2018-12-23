using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Chat_Project
{
    internal class PersonalMessageActions : Action
    {
        private const string RECEIVED = "Received", SENT = "Sent";
        public PersonalMessageActions(IDataHandler DataProvider, User ActiveUser) : base(DataProvider, ActiveUser) { }

        public bool CreateMessage()
        {
            User Receiver = MainActions.SelectUser();

            Console.WriteLine("Add a title:");
            string title = Console.ReadLine();
            Console.WriteLine("Send the message");
            string text = Console.ReadLine();

            PersonalMessage NewPersonalMessage = new PersonalMessage()
            {
                SenderID = ActiveUser.UserID,
                ReceiverID = Receiver.UserID,
                TitleText = title,
                PersonalMessageText = text
            };

            return DataHandler.CreatePersonalMessageData(NewPersonalMessage);
        }

        public bool ShowReceivedMessages()
        {
            List<PersonalMessage> ReceivedPersonalMessages = GetMessages(Sent: false);

            List<string> ReceivedPersonalTitles = PresentTitles(ReceivedPersonalMessages);

            int ChosenTitle = SelectMenu.Vertical(ReceivedPersonalTitles).IndexOfChoice;
            PersonalMessage MessageToShow = ReceivedPersonalMessages[ChosenTitle];

            Console.WriteLine($"Ο χρήστης {MessageToShow.Sender.Username} σας έστειλε μήνυμα στις " +
                $"{MessageToShow.SendDate}: {MessageToShow.PersonalMessageText}");
            Debug.Write(DataHandler.MarkMessageAsRead(MessageToShow));

            Console.ReadKey();

            return true;
        }

        public bool ShowSentMessages()
        {
            List<PersonalMessage> SentMessages = GetMessages();

            List<string> SentPersonalTitles = PresentTitles(SentMessages);
            int ChosenTitle = SelectMenu.Vertical(SentPersonalTitles).IndexOfChoice;
            PersonalMessage MessageToShow = SentMessages[ChosenTitle];

            Console.WriteLine($"{MessageToShow.TitleText}");
            Console.WriteLine($"{MessageToShow.Sender.Username} έστειλες μήνυμα στις " +
                $"{MessageToShow.SendDate}: {MessageToShow.PersonalMessageText}");

            Console.ReadKey();

            return true;
        }

        public bool IsMessageRead()
        {
            Console.WriteLine("Choose the message you want to check if its read");
            List<PersonalMessage> MessagesToChoose = GetMessages();
            List<string> Messages = MessagesToChoose.Select(Message => Message.PersonalMessageText).ToList();

            PersonalMessage MessageToCheck = MessagesToChoose[SelectMenu.Vertical(Messages).IndexOfChoice];

            if (MessageToCheck.isRead == true)
            {
                Console.WriteLine("Message was read");
                return true;
            }
            else
            {
                Console.WriteLine("Message not read yet");
            }

            Console.ReadKey();

            return false;
        }

        public List<PersonalMessage> GetMessages(bool Sent = true)
        {
            return DataHandler.ReadPersonalMessages()
                 .Where(SendMessages =>
                 (Sent ? SendMessages.SenderID : SendMessages.ReceiverID) == ActiveUser.UserID)
                 .ToList();
        }

        private List<string> PresentTitles(List<PersonalMessage> Messages)
        {
            return Messages.
                 Select(sm => (sm.isRead ? "  " : " *") + sm.TitleText).
                 ToList();
        }

        public PersonalMessage GetWantedMessage(User ActiveUser)
        {
            string ReceivedOrSent = SelectMenu.Horizontal(new List<string> { RECEIVED, SENT }).NameOfChoice;
            List<PersonalMessage> MessagesToShow = GetMessages(ReceivedOrSent == SENT);

            int SelectedMessage = SelectMenu.Vertical(MessagesToShow
                .Select(MessageObject => MessageObject.PersonalMessageText)
                .ToList())
                .IndexOfChoice;

            return MessagesToShow[SelectedMessage];
        }

        public bool UpdateMessage()
        {
            PersonalMessage WantedMessage = GetWantedMessage(ActiveUser);
            Console.Write($"Old Message: {WantedMessage.PersonalMessageText}\nNew Message:");

            return DataHandler.UpdatePersonalMessage(WantedMessage, Console.ReadLine());
        }

        public bool DeleteMessage()
        {
            PersonalMessage WantedMessage = GetWantedMessage(ActiveUser);

            return DataHandler.DeletePersonalMessage(WantedMessage, ActiveUser);
        }

        public string CountUnreadReceived()
        {
            int UnreadNumber = GetMessages(false).Count(m => !m.isRead);
            return (UnreadNumber > 0) ? $"({UnreadNumber})" : "";
        }

        public string CountUnreadSent()
        {
            int UnreadNumber = GetMessages().Count(m => !m.isRead);
            return (UnreadNumber > 0) ? $"({UnreadNumber})" : "";
        }
    }
}
