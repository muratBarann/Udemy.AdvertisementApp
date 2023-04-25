using Microsoft.AspNetCore.Http;
using System;

namespace Udemy.AdvertisementApp.UI.Models
{
    public class AdvertisementAppUserCreateModel
    {
        public int AdvertisementId { get; set; }
        public int AppUserId { get; set; }
        public int AdvertisementAppUserStatusId { get; set; }
        public int MilitaryStatusId { get; set; }
        public DateTime EndDate{ get; set; }
        public string WorkExperience { get; set; }
        public IFormFile CvFile { get; set; }

    }
}
