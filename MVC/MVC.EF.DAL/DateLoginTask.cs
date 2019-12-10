namespace MVC.EF.DAL
{
    using System.Data.Entity;

    public partial class DateLoginTask : DbContext
    {


        public DateLoginTask()
            : base("name=DateLoginTask")
        {
        }

        public virtual DbSet<Task> Task { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.sex)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
