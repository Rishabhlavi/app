using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Xamarin.Data.Models;

namespace Xamarin.Data.Controllers
{
    public class ValuesController : ApiController
    {
        private AmbassadorContext context = new AmbassadorContext();

        // GET api/values
        public IEnumerable<Ambassador> Get()
        {
            var ambassadors = context.XamarinAmbassadors.ToList();
            foreach (var item in ambassadors)
            {
                item.PhotoUri = String.Format("{0}{1}", Request.RequestUri.GetLeftPart(UriPartial.Authority), item.PhotoUri);
                item.University.Logo = String.Format("{0}{1}", Request.RequestUri.GetLeftPart(UriPartial.Authority), item.University.Logo);
            }

            return ambassadors;
        }

        // GET api/values/5
        public Ambassador Get(int id)
        {
            var ambassador = context.XamarinAmbassadors.Where(x => x.Id == id).SingleOrDefault();

            ambassador.PhotoUri = String.Format("{0}{1}", ambassador.PhotoUri);
            ambassador.University.Logo = String.Format("{0}{1}", Request.RequestUri.GetLeftPart(UriPartial.Authority), ambassador.University.Logo);

            return ambassador;
        }
    }
}
