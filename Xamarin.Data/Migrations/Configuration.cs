using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Xamarin.Data.Models;

namespace Xamarin.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AmbassadorContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Xamarin.Data.Models.AmbassadorContext";
        }

        protected override void Seed(AmbassadorContext context)
        {
            context.Users.AddOrUpdate<XamarinLogin>(new XamarinLogin []
            {
                new XamarinLogin()
                {
                    Username = "ambassador@xamarin.com",
                    Password = "6EE1F003B9E6B772718956D1BB775277"
                }
            });

            context.SaveChanges();
        }
    }
}
