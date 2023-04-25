using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Business.AutoMapper;

namespace Udemy.AdvertisementApp.Business.Helpers
{
    public static class ProfilHelpers
    {
        public static List<Profile> GetProfiles()
        {
            return new List<Profile>
            {
                new ProvidedServiceProfile(),
                new AdvertisementServiceProfile(),
                new AppUserProfile(),
                new GenderProfile(),
                new AppRoleProfile(),
            };
        }
    }
}
