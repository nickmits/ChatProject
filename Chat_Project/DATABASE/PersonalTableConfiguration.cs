using System.Data.Entity.ModelConfiguration;

namespace Chat_Project
{
    internal class PersonalTableConfiguration : EntityTypeConfiguration<PersonalMessage>
    {
        public PersonalTableConfiguration()
        {
            HasRequired(pm => pm.Sender)
               .WithMany(usender => usender.SentMessages)
               .HasForeignKey(pm => pm.SenderID)
               .WillCascadeOnDelete(false);

             HasRequired(pm => pm.Receiver)
                .WithMany(ureceiver => ureceiver.ReceivedMessages)
                .HasForeignKey(pm => pm.ReceiverID)
                .WillCascadeOnDelete(false);
        }
    }
}
