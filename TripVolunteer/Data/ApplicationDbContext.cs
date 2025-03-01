using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TripVolunteer.API.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bank> Banks { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<DbtoolsExecutionHistory> DbtoolsExecutionHistories { get; set; } = null!;
        public virtual DbSet<Gallery> Galleries { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Staticabout> Staticabouts { get; set; } = null!;
        public virtual DbSet<Staticheaderandfooter> Staticheaderandfooters { get; set; } = null!;
        public virtual DbSet<Statichome> Statichomes { get; set; } = null!;
        public virtual DbSet<Testimonial> Testimonials { get; set; } = null!;
        public virtual DbSet<Trip> Trips { get; set; } = null!;
        public virtual DbSet<Triprequest> Triprequests { get; set; } = null!;
        public virtual DbSet<Userr> Userrs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("User Id=ADMIN;Password=Alomari0797101452***;Data Source=finalproject_high;TNS_ADMIN=C:\\oracle\\wallet");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ADMIN")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.ToTable("BANK");

                entity.Property(e => e.Bankid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BANKID");

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER(10,2)")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.Cardholdname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CARDHOLDNAME");

                entity.Property(e => e.Cardnumber)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CARDNUMBER");

                entity.Property(e => e.Cvv)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CVV");

                entity.Property(e => e.Expirydate)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIRYDATE");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("CONTACT");

                entity.Property(e => e.Contactid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CONTACTID");

                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CONTENT");

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PHONENUMBER");
            });

            modelBuilder.Entity<DbtoolsExecutionHistory>(entity =>
            {
                entity.ToTable("DBTOOLS$EXECUTION_HISTORY");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("TIMESTAMP(6) WITH TIME ZONE")
                    .HasColumnName("CREATED_ON");

                entity.Property(e => e.Hash)
                    .HasColumnType("CLOB")
                    .HasColumnName("HASH");

                entity.Property(e => e.Statement)
                    .HasColumnType("CLOB")
                    .HasColumnName("STATEMENT");

                entity.Property(e => e.Times)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TIMES");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("TIMESTAMP(6) WITH TIME ZONE")
                    .HasColumnName("UPDATED_ON");
            });

            modelBuilder.Entity<Gallery>(entity =>
            {
                entity.HasKey(e => e.Imageid)
                    .HasName("SYS_C0023108");

                entity.ToTable("GALLERY");

                entity.Property(e => e.Imageid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IMAGEID");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("INVOICE");

                entity.Property(e => e.Invoiceid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("INVOICEID");

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.Description)
                    .HasColumnType("CLOB")
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Invoicelink)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("INVOICELINK");

                entity.Property(e => e.Requestid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("REQUESTID");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.Requestid)
                    .HasConstraintName("FKTRIPREQUEST");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("LOGIN");

                entity.HasIndex(e => e.Username, "SYS_C0023066")
                    .IsUnique();

                entity.Property(e => e.Loginid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LOGINID");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKLOGINROLE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKLOGINUSER");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("PAYMENT");

                entity.Property(e => e.Paymentid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PAYMENTID");

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER(10,2)")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.Paidat)
                    .HasColumnType("DATE")
                    .HasColumnName("PAIDAT")
                    .HasDefaultValueSql("SYSDATE");

                entity.Property(e => e.Paymentmethod)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PAYMENTMETHOD");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("POST");

                entity.Property(e => e.Postid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("POSTID");

                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CONTENT");

                entity.Property(e => e.Createdat)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEDAT");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLE");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROLENAME");
            });

            modelBuilder.Entity<Staticabout>(entity =>
            {
                entity.ToTable("STATICABOUT");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CONTENT");

                entity.Property(e => e.Img1path)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IMG1PATH");

                entity.Property(e => e.Title1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TITLE1");
            });

            modelBuilder.Entity<Staticheaderandfooter>(entity =>
            {
                entity.ToTable("STATICHEADERANDFOOTER");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Content)
                    .HasColumnType("CLOB")
                    .HasColumnName("CONTENT");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Logo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LOGO");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Phonenumber)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PHONENUMBER");
            });

            modelBuilder.Entity<Statichome>(entity =>
            {
                entity.ToTable("STATICHOME");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Img1path)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IMG1PATH");

                entity.Property(e => e.Img2path)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IMG2PATH");

                entity.Property(e => e.Img3path)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IMG3PATH");

                entity.Property(e => e.P1).HasColumnType("CLOB");

                entity.Property(e => e.P2).HasColumnType("CLOB");

                entity.Property(e => e.P3).HasColumnType("CLOB");

                entity.Property(e => e.Title1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TITLE1");

                entity.Property(e => e.Title2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TITLE2");

                entity.Property(e => e.Title3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TITLE3");
            });

            modelBuilder.Entity<Testimonial>(entity =>
            {
                entity.ToTable("TESTIMONIAL");

                entity.Property(e => e.Testimonialid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TESTIMONIALID");

                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CONTENT");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Testimonials)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTESTIMONIALUSER");
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.ToTable("TRIP");

                entity.Property(e => e.Tripid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TRIPID");

                entity.Property(e => e.Description)
                    .HasColumnType("CLOB")
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Enddate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Latitude)
                    .HasColumnType("NUMBER(8,6)")
                    .HasColumnName("LATITUDE");

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Longitude)
                    .HasColumnType("NUMBER(9,6)")
                    .HasColumnName("LONGITUDE");

                entity.Property(e => e.Maxusers)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAXUSERS");

                entity.Property(e => e.Maxvolunteers)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAXVOLUNTEERS");

                entity.Property(e => e.Minage)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MINAGE");

                entity.Property(e => e.Price)
                    .HasColumnType("NUMBER(10,2)")
                    .HasColumnName("PRICE");

                entity.Property(e => e.Startdate)
                    .HasColumnType("DATE")
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Tripname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TRIPNAME");
            });

            modelBuilder.Entity<Triprequest>(entity =>
            {
                entity.HasKey(e => e.Requestid)
                    .HasName("SYS_C0023089");

                entity.ToTable("TRIPREQUEST");

                entity.Property(e => e.Requestid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("REQUESTID");

                entity.Property(e => e.Cvfilepath)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CVFILEPATH");

                entity.Property(e => e.Paymentid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PAYMENTID");

                entity.Property(e => e.Requestedat)
                    .HasColumnType("DATE")
                    .HasColumnName("REQUESTEDAT")
                    .HasDefaultValueSql("SYSDATE");

                entity.Property(e => e.Requesttype)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("REQUESTTYPE");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Tripid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TRIPID");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Triprequests)
                    .HasForeignKey(d => d.Paymentid)
                    .HasConstraintName("FKREQUESTPAYMENT");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.Triprequests)
                    .HasForeignKey(d => d.Tripid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKREQUESTTRIP");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Triprequests)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKREQUESTUSER");
            });

            modelBuilder.Entity<Userr>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("SYS_C0023049");

                entity.ToTable("USERR");

                entity.HasIndex(e => e.Email, "SYS_C0023050")
                    .IsUnique();

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERID");

                entity.Property(e => e.Age)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AGE");

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRY");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FNAME");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LNAME");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLEID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Userrs)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKUSERROLE");
            });

            modelBuilder.HasSequence("DBTOOLS$EXECUTION_HISTORY_SEQ");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
