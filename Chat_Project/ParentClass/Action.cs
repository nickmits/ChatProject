using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Project
{
    class Action
    {
        protected IDataHandler DataHandler;
        public User ActiveUser;

        public Action (IDataHandler dataHandler, User activeUser)
        {
            DataHandler = dataHandler;
            ActiveUser = activeUser;
        }
    }
}
