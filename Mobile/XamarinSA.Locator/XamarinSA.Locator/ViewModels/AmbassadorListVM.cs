using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Base.ViewModels;
using Xamarin.Data.Models;
using Xamarin.Forms;
using XamarinSA.Locator.Data;
using XamarinSA.Locator.Views.Pages;

namespace XamarinSA.Locator.ViewModels
{
    public class AmbassadorListVM : BaseListViewModel<Ambassador>
    {

        public AmbassadorListVM()
        {
            //fetch list of ambassadors, then set items.
            Task.Run(async () =>
                {
                    var response = await AmbassadorService.GetAmbassadorsList();
                    if (response != null)
                    {
                        foreach (Ambassador item in response)
                        {
                            Items.Add(item);
                        }

                        MessagingCenter.Send<ICollection<Ambassador>>(response, "AmbassadorsRecieved");
                    }
                });


            SelectionChangedCommand = new Command(async () =>
            {
                if (SelectedItem != null)
                {
                    await Navigation.PushAsync(new AmbassadorDetails()
                    {
                        BindingContext = new AmbassadorDetailsVM(SelectedItem)
                    });
                    SelectedItem = null;
                }
            });

        }
    }
}
