using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapp_stufv.Models;

namespace webapp_stufv.Repository
{
    public interface IEventRepository
    {
        string getCity(string Zipcode);
        List<Event> GetAllEvents();

    }
}