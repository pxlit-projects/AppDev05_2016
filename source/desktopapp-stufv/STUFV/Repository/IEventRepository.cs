using System.Collections.Generic;

namespace STUFV.Repository
{
    public interface IEventRepository
    {
        string getCity(string Zipcode);
        List<Event> GetAllEvents();

    }
}