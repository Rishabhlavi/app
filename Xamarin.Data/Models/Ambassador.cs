using System;
using System.Runtime.Serialization;
using System.Text;

#if !ASPNET && (RELEASE || DEBUG)
    using XamarinSA.Locator.Data.Models;
#else
    using System.ComponentModel.DataAnnotations;
#endif


namespace Xamarin.Data.Models
{
    
	public class Ambassador
    {
#if !ASPNET && (RELEASE || DEBUG)

		private string fullName;
		public string FullName 
        {
			get 
            {  
                return String.Format("{0} {1}", FirstName, LastName); 
            }
		}

		private Location location;
		public Location Location {
			get {
                if(location == null){
                    location = new Location (this);
                }
				return location;
			}

		}

#endif

        [IgnoreDataMember]
#if ASPNET
        [ScaffoldColumn(false)]
#endif
        public int Id { get; set; }

        [DataMember]
#if ASPNET
        [Display(Name="First Name"), Required]
#endif
        public String FirstName { get; set; }

        [DataMember]
#if ASPNET
        [Display(Name = "Middle Name")]
#endif
        public String MiddleName { get; set; }

        [DataMember]
#if ASPNET
        [Display(Name = "Last Name"), Required]
#endif
        public String LastName { get; set; }

		[DataMember]
#if ASPNET
		[Display(Name = "City"), Required]
#endif
		public String City { get; set; }

		[DataMember]
#if ASPNET
		[Display(Name = "State or Region")]
#endif
		public String StateRegion { get; set; }

        [DataMember]
#if ASPNET
        [Display(Name = "Country"), Required]
#endif
        public String Country { get; set; }

        [DataMember]
#if ASPNET
        [Display(Name = "Email"), Required, DataType(DataType.EmailAddress)]
#endif
        public String ContactEmail { get; set; }

        [DataMember]
#if ASPNET
        [Display(Name = "Twitter handle"), Required]
#endif
        public String TwitterHandle { get; set; }

        [DataMember]
#if ASPNET
        [Display(Name = "Facebook ID"), Required]
#endif
        public Int64 FacebookName { get; set; }

        [DataMember]
#if ASPNET
        [Display(Name = "LinkedIn ID")]
#endif
        public Int64 LinkedInName { get; set; }

        [DataMember]
#if ASPNET
        [Display(Name = "Blog"), DataType(DataType.Url)]
#endif
        public String Blog { get; set; }

        [DataMember]
#if ASPNET
        [Display(Name = "Is Certified")]
#endif
        public Boolean IsCertified { get; set; }

        [DataMember]
#if ASPNET
        [Display(Name = "Picture"), DataType(DataType.Upload)]
#endif
        public String PhotoUri { get; set; }

#if ASPNET
        [DataMember]
        [Display(Name = "Promotion page"), Required, DataType(DataType.Url)]
#endif
        public String EventPage { get; set; }

#if ASPNET
        [DataMember]
        [Display(Name = "Bio"), Required, DataType(DataType.MultilineText)]
#endif
        public String Biography { get; set; }

#if ASPNET
        [DataMember]
        [Display(Name = "GPS Coordinates")]
        [RegularExpression("[0-9]+(\\.|\\,)[0-9]+;[0-9]+(\\.|\\,)[0-9]+",ErrorMessage="Invalid format. Format is: x.yz;x.yz or x,yz;x,yz")]
#endif
        public String GpsCoordinates { get; set; }

        [DataMember]
#if ASPNET
        [Display(Name = "University"), Required]
#endif
        public Int32? UniversityId { get; set; }

        [DataMember]
#if ASPNET
        [ScaffoldColumn(false), Display(Name="University name")]
#endif
        public virtual University University { get; set; }
	}
}

