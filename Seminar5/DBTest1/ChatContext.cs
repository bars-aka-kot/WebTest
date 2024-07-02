using Microsoft.EntityFrameworkCore;

namespace DBTest1
{
    public class ChatContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

        public ChatContext()
        {

        }
        public ChatContext(DbContextOptions dbContext): base(dbContext)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost; Database = myDataBase; Integrated Security=False;TrustServerSertificate=True;Trusted_Connection=True;")
                .UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasKey(x => x.Id).HasName("users_pkey");

                entity.HasIndex(x => x.FullName).IsUnique();

                entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("FullName")
                .IsRequired();

            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(x => x.MessageId).HasName("messages_pkey");
                entity.ToTable("messages");

                entity.Property(e => e.MessageText).HasColumnName("message_text");
                entity.Property(e => e.DateSend).HasColumnName("message_date");
                entity.Property(e => e.IsSend).HasColumnName("message_status");
                entity.Property(e => e.MessageId).HasColumnName("id");

                entity.HasOne(u => u.UserTo)
                .WithMany(m => m.MessagesTo)
                .HasForeignKey(k => k.UserToId)
                .HasConstraintName("message_to_user_fkey");
                entity.HasOne(u => u.UserFrom)
                .WithMany(m => m.MessagesFrom)
                .HasForeignKey(k=>k.UserFromId)
                .HasConstraintName("message_from_user_fkey");

            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
//1/40/30