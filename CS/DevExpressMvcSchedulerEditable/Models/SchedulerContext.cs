using System.Data.Entity;

namespace DevExpressMvcSchedulerEF.Views
{
    public class SchedulerContext:DbContext
    {
        public DbSet<EFAppointment> EFAppointments { get; set; }
        public DbSet<EFResource> EFResources { get; set; }
    }

  class SchedulerContextSeedInilializer : DropCreateDatabaseIfModelChanges<SchedulerContext> {
        protected override void Seed(SchedulerContext context)
        {
            EFResource res1 = new EFResource();
            res1.ResourceID = 1;
            res1.ResourceName = "Resource1";
            context.EFResources.Add(res1);
            res1.Color = System.Drawing.Color.DarkOrange.ToArgb();

            EFResource res2 = new EFResource();
            res2.ResourceID = 2;
            res2.ResourceName = "Resource2";
            res2.Color = System.Drawing.Color.SteelBlue.ToArgb();
            context.EFResources.Add(res2);

            base.Seed(context);
        }
    
    }
}
