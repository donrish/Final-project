using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelsProject.Services
{
    public interface IRepo<T>
    {
        IEnumerable<T> GetAll();
        int Login(T t);
        T Get(int id);
        void Add(T t);
        void Update(int id, T t);
        void UpdateOrder(int id, T t);
        void CancelBooking(T t);
       
    }
}
