using System;

namespace Udemy.AdvertisementApp.Enities
{
    //Bu class sayesinde tüm sınıflarda olacak id değerlerini buradan çekiyor 
    public class BaseEntity
    {
        public int Id { get; set; }
    }
}
