using Billing52Group.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Billing52Group.Server.Configuration
{
    public class Billing52GroupContext : DbContext
    {
        public Billing52GroupContext()
        {
        }

        public Billing52GroupContext(DbContextOptions<Billing52GroupContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contract> Contract { get; set; }

        public virtual DbSet<ContractAccount> ContractAccount { get; set; }

        public virtual DbSet<ContractBalance> ContractBalance { get; set; }

        public virtual DbSet<ContractCharge> ContractCharge { get; set; }

        public virtual DbSet<ContractGroup> ContractGroup { get; set; }

        public virtual DbSet<ContractLimit> ContractLimit { get; set; }

        public virtual DbSet<ContractModule> ContractModule { get; set; }

        public virtual DbSet<ContractParams> ContractParams { get; set; }

        public virtual DbSet<ContractPayment> ContractPayment { get; set; }

        public virtual DbSet<ContractService> ContractService { get; set; }

        public virtual DbSet<ContractStatus> ContractStatus { get; set; }

        public virtual DbSet<ContractTariff> ContractTariff { get; set; }

        public virtual DbSet<Limit> Limit { get; set; }

        public virtual DbSet<Module> Module { get; set; }

        public virtual DbSet<Parameters> Parameters { get; set; }

        public virtual DbSet<Payment> Payment { get; set; }


        public virtual DbSet<Service> Service { get; set; }

        public virtual DbSet<Status> Status { get; set; }

        public virtual DbSet<TariffGroup> TariffGroup { get; set; }

        public virtual DbSet<TariffPlan> TariffPlan { get; set; }

        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("contract");

                entity.HasIndex(e => e.Contractgroupid)
                    .HasName("FKgroup1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Contractgroupid).HasColumnName("contractgroupid");

                entity.Property(e => e.Date1)
                    .HasColumnName("date1")
                    .HasColumnType("date");

                entity.Property(e => e.Date2)
                    .HasColumnName("date2")
                    .HasColumnType("date");

                entity.Property(e => e.Fc).HasColumnName("fc");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.ContractGroup)
                    .WithMany(p => p.Contract)
                    .HasForeignKey(d => d.Contractgroupid)
                    .HasConstraintName("FKgroup1");
            });

            modelBuilder.Entity<ContractAccount>(entity =>
            {
                entity.HasKey(e => new {e.Yy, e.Mm, e.Contractid})
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] {0, 0, 0});

                entity.ToTable("contractaccount");

                entity.HasIndex(e => e.Contractid)
                    .HasName("FKcontract7_idx");

                entity.Property(e => e.Yy).HasColumnName("yy");

                entity.Property(e => e.Mm).HasColumnName("mm");

                entity.Property(e => e.Contractid).HasColumnName("contractid");

                entity.Property(e => e.Summa).HasColumnName("summa");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.ContractAccounts)
                    .HasForeignKey(d => d.Contractid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKcontract7");
            });

            modelBuilder.Entity<ContractBalance>(entity =>
            {
                entity.HasKey(e => new {e.Yy, e.Mm, e.Contractid})
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] {0, 0, 0});

                entity.ToTable("contractbalance");

                entity.HasIndex(e => e.Contractid)
                    .HasName("FKcontract3_idx");

                entity.Property(e => e.Yy).HasColumnName("yy");

                entity.Property(e => e.Mm).HasColumnName("mm");

                entity.Property(e => e.Contractid).HasColumnName("contractid");

                entity.Property(e => e.Summa).HasColumnName("summa");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.ContractBalance)
                    .HasForeignKey(d => d.Contractid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKcontract3");
            });

            modelBuilder.Entity<ContractCharge>(entity =>
            {
                entity.ToTable("contractcharge");

                entity.HasIndex(e => e.Contractid)
                    .HasName("FKcontract2_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Contractid).HasColumnName("contractid");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Summa).HasColumnName("summa");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.ContractCharge)
                    .HasForeignKey(d => d.Contractid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKcontract2");
            });

            modelBuilder.Entity<ContractGroup>(entity =>
            {
                entity.ToTable("contractgroup");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<ContractLimit>(entity =>
            {
                entity.ToTable("contractlimit");

                entity.HasIndex(e => e.Contractid)
                    .HasName("FKcontract9_idx");

                entity.HasIndex(e => e.Limitid)
                    .HasName("FKlimit1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Contractid).HasColumnName("contractid");

                entity.Property(e => e.Limitid).HasColumnName("limitid");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasColumnType("date");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.ContractLimit)
                    .HasForeignKey(d => d.Contractid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKcontract9");

                entity.HasOne(d => d.Limit)
                    .WithMany(p => p.Contractlimit)
                    .HasForeignKey(d => d.Limitid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKlimit1");
            });

            modelBuilder.Entity<ContractModule>(entity =>
            {
                entity.HasKey(e => new {e.Contractid, e.Moduleid})
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] {0, 0});

                entity.ToTable("contractmodule");

                entity.HasIndex(e => e.Moduleid)
                    .HasName("FKmodule1_idx");

                entity.Property(e => e.Contractid).HasColumnName("contractid");

                entity.Property(e => e.Moduleid).HasColumnName("moduleid");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.ContractModule)
                    .HasForeignKey(d => d.Contractid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKcontract1");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.Contractmodule)
                    .HasForeignKey(d => d.Moduleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKmodule2");
            });

            modelBuilder.Entity<ContractParams>(entity =>
            {
                entity.ToTable("contractparams");

                entity.HasIndex(e => e.ContractId)
                    .HasName("FKcontract10_idx");

                entity.HasIndex(e => e.ParamId)
                    .HasName("FKparams1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ContractId).HasColumnName("contractId");

                entity.Property(e => e.ParamId).HasColumnName("paramId");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasColumnType("varchar(125)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.ContractParams)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKcontract10");

                entity.HasOne(d => d.Param)
                    .WithMany(p => p.Contractparams)
                    .HasForeignKey(d => d.ParamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKparams1");
            });

            modelBuilder.Entity<ContractPayment>(entity =>
            {
                entity.ToTable("contractpayment");

                entity.HasIndex(e => e.Contractid)
                    .HasName("FKcontract4_idx");

                entity.HasIndex(e => e.Paymentid)
                    .HasName("FKpayment1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Contractid).HasColumnName("contractid");

                entity.Property(e => e.Paymentid).HasColumnName("paymentid");

                entity.Property(e => e.Summa).HasColumnName("summa");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.ContractPayment)
                    .HasForeignKey(d => d.Contractid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKcontract4");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Contractpayment)
                    .HasForeignKey(d => d.Paymentid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKpayment1");
            });

            modelBuilder.Entity<ContractService>(entity =>
            {
                entity.ToTable("contractservice");

                entity.HasIndex(e => e.Contractid)
                    .HasName("FKcontract6_idx");

                entity.HasIndex(e => e.Serviceid)
                    .HasName("FKservice1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Contractid).HasColumnName("contractid");

                entity.Property(e => e.Date1)
                    .HasColumnName("date1")
                    .HasColumnType("date");

                entity.Property(e => e.Date2)
                    .HasColumnName("date2")
                    .HasColumnType("date");

                entity.Property(e => e.Serviceid).HasColumnName("serviceid");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.ContractService)
                    .HasForeignKey(d => d.Contractid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKcontract6");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Contractservice)
                    .HasForeignKey(d => d.Serviceid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKservice1");
            });

            modelBuilder.Entity<ContractStatus>(entity =>
            {
                entity.ToTable("contractstatus");

                entity.HasIndex(e => e.Contractid)
                    .HasName("FKcontract8_idx");

                entity.HasIndex(e => e.Statusid)
                    .HasName("FKstatus1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Contractid).HasColumnName("contractid");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasColumnType("date");

                entity.Property(e => e.Statusid).HasColumnName("statusid");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.ContractStatus)
                    .HasForeignKey(d => d.Contractid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKcontract8");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Contractstatus)
                    .HasForeignKey(d => d.Statusid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKstatus1");
            });

            modelBuilder.Entity<ContractTariff>(entity =>
            {
                entity.ToTable("contracttariff");

                entity.HasIndex(e => e.Contractid)
                    .HasName("FKcontract5_idx");

                entity.HasIndex(e => e.Tariffplanid)
                    .HasName("FKtariff1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Contractid).HasColumnName("contractid");

                entity.Property(e => e.Date1)
                    .HasColumnName("date1")
                    .HasColumnType("date");

                entity.Property(e => e.Date2)
                    .HasColumnName("date2")
                    .HasColumnType("date");

                entity.Property(e => e.Tariffplanid).HasColumnName("tariffplanid");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.ContractTariff)
                    .HasForeignKey(d => d.Contractid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKcontract5");

                entity.HasOne(d => d.TariffPlan)
                    .WithMany(p => p.Contracttariff)
                    .HasForeignKey(d => d.Tariffplanid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKtariff1");
            });

            modelBuilder.Entity<Limit>(entity =>
            {
                entity.ToTable("limit");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Limit1)
                    .IsRequired()
                    .HasColumnName("limit")
                    .HasColumnType("varchar(45)")
                    .HasDefaultValueSql("'0'")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.ToTable("module");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Parameters>(entity =>
            {
                entity.ToTable("parameters");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("service");

                entity.HasIndex(e => e.Moduleid)
                    .HasName("FKmodule3_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Moduleid).HasColumnName("moduleid");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.Service)
                    .HasForeignKey(d => d.Moduleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKmodule3");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<TariffGroup>(entity =>
            {
                entity.ToTable("tariffgroup");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<TariffPlan>(entity =>
            {
                entity.ToTable("tariffplan");

                entity.HasIndex(e => e.Tariffgroupid)
                    .HasName("FKmodule1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Tariffgroupid)
                    .HasColumnName("tariffgroupid")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.TariffGroup)
                    .WithMany(p => p.Tariffplan)
                    .HasForeignKey(d => d.Tariffgroupid)
                    .HasConstraintName("FKmodule1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => new {e.Login, e.Password})
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] {0, 0});

                entity.ToTable("user");

                entity.Property(e => e.Login)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Password)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Admin).HasColumnName("admin");
            });
        }
    }
}
