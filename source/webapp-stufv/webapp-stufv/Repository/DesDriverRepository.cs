using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapp_stufv.Models;

namespace webapp_stufv.Repository
{
    public class DesDriverRepository : IDesDriverRepository
    {
        private IPassengerRepository ipassenger = new PassengerRepository();
        public List<DesDriver> ActiveDriversPerEvent(int eventId, int userId)
        {
            List<DesDriver> allDrivers = GetAllDrivers();
            List<DesDriver> activeDrivers = new List<DesDriver>();
            int x;
            for (x = 0; x < allDrivers.Count(); x++)
            {
                if (allDrivers.ElementAt(x).EventId.Equals(eventId) && allDrivers.ElementAt(x).Active.Equals(true) && allDrivers.ElementAt(x).NrOfPlaces > allDrivers.ElementAt(x).NrOfFilled && allDrivers.ElementAt(x).UserId != userId)
                {
                    activeDrivers.Add(allDrivers.ElementAt(x));
                }
            }
            return activeDrivers;
        }

        public List<DesDriver> GetAllDrivers()
        {
            using (var context = new STUFVModelContext())
            {
                List<DesDriver> drivers = new List<DesDriver>();
                drivers = context.DesDrivers.ToList();
                return drivers;
            }
        }

        public string GetDriverName(int UserId)
        {
            string fullName = "";
            List<User> users = new List<User>();
            using (var context = new STUFVModelContext())
            {
                users = context.Users.ToList();
                var user = users.Single(r => r.Id == UserId);
                fullName = user.FirstName + " " + user.LastName;
            }
            return fullName;

        }

        public bool IsDES(int userId, int eventId)
        {
            List<DesDriver> drivers = GetAllDrivers();
            int x;
            for (x = 0; x < drivers.Count(); x++)
            {
                if (drivers.ElementAt(x).UserId.Equals(userId) && drivers.ElementAt(x).EventId.Equals(eventId) && drivers.ElementAt(x).Active.Equals(true))
                {
                    return true;
                }
            }
            return false;
        }

        public void SetDES(int userId, int eventId, int places)
        {
            if (WasDES(userId, eventId))
            {
                //already in db active == false
                using (var context = new STUFVModelContext())
                {
                    var driver = context.DesDrivers.FirstOrDefault(c => c.UserId == userId && c.EventId == eventId);
                    driver.Active = true;
                    driver.NrOfPlaces = places;
                    context.SaveChanges();
                }

            }
            else {
                var driver = new DesDriver { EventId = eventId, UserId = userId, Active = true, NrOfPlaces = places, NrOfFilled = 0, Flagged = false };
                using (var context = new STUFVModelContext())
                {
                    context.DesDrivers.Add(driver);
                    context.SaveChanges();
                }
            }
        }



        public void unSetDES(int userId, int eventId)
        {
            if (IsDES(userId, eventId))
            {
                using (var context = new STUFVModelContext())
                {
                    var drivers = context.DesDrivers.FirstOrDefault(c => c.UserId == userId && c.EventId == eventId);
                    drivers.Active = false;
                    context.SaveChanges();
                }
            }
        }

        public bool WasDES(int userId, int eventId)
        {
            List<DesDriver> drivers = GetAllDrivers();
            int x;
            for (x = 0; x < drivers.Count(); x++)
            {
                if (drivers.ElementAt(x).UserId.Equals(userId) && drivers.ElementAt(x).EventId.Equals(eventId) && drivers.ElementAt(x).Active.Equals(false))
                {
                    return true;
                }
            }
            return false;
        }
    }
}