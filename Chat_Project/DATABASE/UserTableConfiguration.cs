using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Chat_Project
{
    internal class UserTableConfiguration : EntityTypeConfiguration<User>
    {
        public UserTableConfiguration()
        {

            Property(user => user.Username)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(
                    new IndexAttribute()
                    {
                        IsUnique = true
                    }));

            HasMany(u => u.ForumMessages)
                .WithRequired(fm => fm.Sender)
                .HasForeignKey(fm => fm.SenderId);
        }
       
    }
}
