using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Data.Models;
using XamarinSA.Locator.Data.Extensions;

namespace XamarinSA.Locator.Data
{
	public static class AmbassadorService
	{
        private const String HOST_NAME = "https://rest-xamarinambassador.azurewebsites.net/api";
        private const String ALL_AMBASSADORS = "/values/";
        private const String DETA_AMBASSADOR = "/values/{0}";

        public async Task<List<Ambassador>> GetAmbassadorsList()
        {
            HttpClient _Client = new HttpClient();
            try
            {
                HttpResponseMessage resp = await _Client.GetAsync(ALL_AMBASSADORS);
                resp.EnsureSuccessStatusCode();
                String json = await resp.Content.ReadAsStringAsync();

                List<Ambassador> result = JsonHelper.Deserialize<List<Ambassador>>(json);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Get one ambassador by id - needs to be tested (deserialization may crash)
        public async Task<Ambassador> GetAmbassadorDetails(int id)
        {
            HttpClient _Client = new HttpClient();
            try
            {
                HttpResponseMessage resp = await _Client.GetAsync(String.Format(DETA_AMBASSADOR, id));
                resp.EnsureSuccessStatusCode();
                String json = await resp.Content.ReadAsStringAsync();

                Ambassador result = JsonHelper.Deserialize<Ambassador>(json);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

	}
}

