using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.DataAccess.Interfaces;
using Udemy.AdvertisementApp.Enities;

namespace Udemy.AdvertisementApp.DataAccess.UnitOfWork
{
    public interface IUow
    {
        IRepository<T> GetRepostiory<T>() where T : BaseEntity;
        Task SaveChangesAsync();

    }
}
