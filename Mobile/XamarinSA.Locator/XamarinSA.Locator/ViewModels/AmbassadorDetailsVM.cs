using System;
using System.Windows.Input;
using Xamarin.Base.ViewModels;
using Xamarin.Data.Models;
using Xamarin.Forms;

namespace XamarinSA.Locator.ViewModels
{
	public class AmbassadorDetailsVM : BaseViewModel
	{
		private const string Blog = "blog";
		private const string Twitter = "twitter";

		public Ambassador Xsa { get; private set; }
		public ICommand OpenCommand { get; private set; }

		public AmbassadorDetailsVM (Ambassador ambassador)
		{
			Xsa = ambassador;
			OpenCommand = new Command ((openType) => {
				var openFor = openType.ToString().ToLower();
				if(openFor.CompareTo(Blog) == 0){
					Device.OpenUri(new Uri(string.Format("http://{0}", Xsa.Blog)));
					return;
				}
				if(openFor.CompareTo(Twitter) == 0){
					Device.OpenUri(new Uri(string.Format("twitter://user?screen_name={0}", Xsa.TwitterHandle)));
					return;
				}
			});
		}
	}
}

