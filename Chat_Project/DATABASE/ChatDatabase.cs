using System.Data.Entity;

namespace Chat_Project
{
    internal class ChatDatabase : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<PersonalMessage> PersonalMessages { get; set; }
        public DbSet<ForumMessage> ForumMessages { get; set; }

        public ChatDatabase() : base() { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserTableConfiguration());

            modelBuilder.Configurations.Add(new PersonalTableConfiguration());              

        }
    }
}
