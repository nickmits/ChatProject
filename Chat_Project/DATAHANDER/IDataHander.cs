using System.Collections.Generic;

namespace Chat_Project
{
    internal interface IDataHandler
    {
        // Create
        bool CreateForumMessageData(ForumMessage forumMessage);
        bool CreateUserData(User user);
        bool CreatePersonalMessageData(PersonalMessage personal);

        // Read
        List<User> ReadUserData();
        List<ForumMessage> ReadForumMessages();
        List<PersonalMessage> ReadPersonalMessages();

        // Update
        bool UpdateForumMessage(ForumMessage OldForumMessage, string NewForumMessageText);       
        bool UpdateUserAccess(User UpdatedUser);
        bool UpdatePersonalMessage(PersonalMessage OldPersonalMessage, string NewPersonalMessageText);

        // Delete
        bool DeleteUser(User DeletedUser);
        bool DeletePersonalMessage(PersonalMessage DeletedMessage, User sender);
        bool DeleteForumMessage(ForumMessage forumMessage, User sender);

        bool UsernameExists(string Username);
        bool IsUsertableEmpty();
    }
}
