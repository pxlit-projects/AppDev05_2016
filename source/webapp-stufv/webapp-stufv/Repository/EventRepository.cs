using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapp_stufv.Models;

namespace webapp_stufv.Repository
{
    public class EventRepository : IEventRepository
    {
        public List<Event> GetAllEvents()
        {
            using (var context = new STUFVModelContext())
            {
                List<Event> events = new List<Event>();
                events = context.Events.ToList();
                return events;
            }
        }
        public List<Event> GetAllUnexpiredEvents()
        {
            using (var context = new STUFVModelContext())
            {
                List<Event> events = new List<Event>();
                events = context.Events.Where(o => (o.End > DateTime.Today) && o.Active == true).ToList();
                return events;
            }
        }

        public string getCity(string Zipcode)
        {
            List<Cities> cities = new List<Cities>();
            using (var context = new STUFVModelContext())
            {
                cities = context.Cities.ToList();
                var city = cities.Single(r => r.ZipCode == Zipcode);
                return (string)city.City;
            }
        }
    }
}