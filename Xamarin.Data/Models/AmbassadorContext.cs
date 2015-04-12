using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Data.Models
{
    public class AmbassadorContext : DbContext
    {
        public AmbassadorContext() : base("DefaultConnection")
        {

        }

        public DbSet<Ambassador> XamarinAmbassadors { get; set; }

        public DbSet<University> Universities { get; set; }

        public DbSet<XamarinLogin> Users { get; set; }
    }
}
