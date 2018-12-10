using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Project
{
    class ChatDatabase : DbContext
    {
        public DbSet<User> Users {get; set;}
        public DbSet<PersonalMessage> PersonalMessages {get; set;}
        public DbSet<ForumMessage> ForumMessages {get; set;}
        public ChatDatabase(): base() { }
    }
}
