using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace model_64132763.EF
{
    public partial class Model_64132763DbContext : DbContext
    {
        public Model_64132763DbContext()
            : base("name=Model_64132763DbContext")
        {
        }

        public virtual DbSet<ADVERTISEMENT> ADVERTISEMENTs { get; set; }
        public virtual DbSet<CART> CARTs { get; set; }
        public virtual DbSet<CART_DETAIL> CART_DETAIL { get; set; }
        public virtual DbSet<CATEGORY> CATEGORies { get; set; }
        public virtual DbSet<MENU> MENUs { get; set; }
        public virtual DbSet<MENU_TYPE> MENU_TYPE { get; set; }
        public virtual DbSet<PRODUCT> PRODUCTs { get; set; }
        public virtual DbSet<PRODUCT_CATEGORY> PRODUCT_CATEGORies { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TAG> TAGs { get; set; }
        public virtual DbSet<USER_ROLE> USER_ROLE { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ADVERTISEMENT>()
                .Property(e => e.META_TITLE_PRODUCT)
                .IsUnicode(false);

            modelBuilder.Entity<ADVERTISEMENT>()
                .HasMany(e => e.TAGs)
                .WithMany(e => e.ADVERTISEMENTs)
                .Map(m => m.ToTable("ADVERTISEMENT_TAG").MapLeftKey("ID_ADVERTISEMENT").MapRightKey("ID_TAG"));

            modelBuilder.Entity<CART>()
                .Property(e => e.SHIP_MOBILE)
                .IsUnicode(false);

            modelBuilder.Entity<CART>()
                .HasMany(e => e.CART_DETAIL)
                .WithRequired(e => e.CART)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CART_DETAIL>()
                .Property(e => e.PRICE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CATEGORY>()
                .Property(e => e.META_TITLE_CATEGORY)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORY>()
                .HasMany(e => e.ADVERTISEMENTs)
                .WithOptional(e => e.CATEGORY)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MENU>()
                .Property(e => e.ID_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<MENU_TYPE>()
                .Property(e => e.ID_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.CODE)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.PRICE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.PRICE_SALE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.META_TITLE_PRODUCT)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .HasMany(e => e.CART_DETAIL)
                .WithRequired(e => e.PRODUCT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRODUCT_CATEGORY>()
                .Property(e => e.META_TITLE_PRODUCT_CATEGORY)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT_CATEGORY>()
                .HasMany(e => e.PRODUCTs)
                .WithOptional(e => e.PRODUCT_CATEGORY)
                .HasForeignKey(e => e.ID_CATEGORY)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TAG>()
                .Property(e => e.ID_TAG)
                .IsUnicode(false);

            modelBuilder.Entity<USER_ROLE>()
                .Property(e => e.NAME_USER)
                .IsUnicode(false);

            modelBuilder.Entity<USER_ROLE>()
                .Property(e => e.PASSWORD_USER)
                .IsUnicode(false);
        }
    }
}
