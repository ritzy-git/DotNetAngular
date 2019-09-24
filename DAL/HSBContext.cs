using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HSBank.DTO;

namespace HSBank.DAL
{
    public partial class HSBContext : DbContext
    {
        EncryptDecrypt objEncDec = new EncryptDecrypt();
        public HSBContext()
        {
        }
        public string ConnectionString {get;set;}
        public HSBContext (string _con)
        {
            ConnectionString = _con;
             
            
        }
        public HSBContext(DbContextOptions<HSBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountDetails> AccountDetails { get; set; }
        public virtual DbSet<PaymentDetails> PaymentDetails { get; set; }
        public virtual DbSet<UserMaster> UserMaster { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql(objEncDec.Decryptdata(Startup.ConnectionString));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountDetails>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PRIMARY");

                entity.Property(e => e.AccountId)
                    .HasColumnName("AccountID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MontlyCl)
                    .HasColumnName("MontlyCL")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<PaymentDetails>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.AccountId)
                    .HasName("fk_Acounid_idx");

                entity.Property(e => e.Pid)
                    .HasColumnName("PID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AccountId)
                    .HasColumnName("AccountID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TransactionAmount).HasColumnType("int(11)");

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.PaymentDetails)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Acounid");
            });

            modelBuilder.Entity<UserMaster>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
            });
        }
    }
}
