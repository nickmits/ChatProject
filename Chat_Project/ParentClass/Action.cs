namespace Chat_Project
{
    internal class Action
    {
        internal IDataHandler DataHandler;
        public User ActiveUser;

        public Action(IDataHandler dataHandler, User activeUser)
        {
            DataHandler = dataHandler;
            ActiveUser = activeUser;
        }
    }
}
