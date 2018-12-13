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

            modelBuilder.Entity<User>()
                .HasMany(u => u.ForumMessages)
                .WithRequired(fm => fm.Sender)
                .HasForeignKey(fm => fm.SenderId);

            modelBuilder.Entity<PersonalMessage>()
                .HasRequired(pm => pm.Sender)
                .WithMany(usender => usender.SentMessages)
                .HasForeignKey(pm => pm.SenderID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PersonalMessage>()
                .HasRequired(pm => pm.Receiver)
                .WithMany(ureceiver => ureceiver.ReceivedMessages)
                .HasForeignKey(pm => pm.ReceiverID)
                .WillCascadeOnDelete(false);

        }
    }
}
