using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapp_stufv.Models;

namespace webapp_stufv.Repository
{
    public class PassengerRepository : IPassengerRepository
    {
        public List<Passenger> GetAllPassengers()
        {
            using (var context = new STUFVModelContext())
            {
                List<Passenger> passengers = new List<Passenger>();
                passengers = context.Passengers.ToList();
                return passengers;
            }
        }

        public bool IsPassenger(int eventId, int userId)
        {
            List<Passenger> passengers = GetAllPassengers();
            int x;
            for (x = 0; x < passengers.Count(); x++)
            {
                if (passengers.ElementAt(x).EventId.Equals(eventId) && passengers.ElementAt(x).UserId.Equals(userId))
                {
                    return true;
                }
            }
            return false;
        }

        public void NewPassenger(int userId, int desId)
        {
            int eventId = 0;
            IDesDriverRepository ides = new DesDriverRepository();
            List<DesDriver> desdriver = ides.GetAllDrivers();
            for (int x = 0; x < desdriver.Count(); x++) {
                if (desdriver.ElementAt(x).Id.Equals(desId)) {
                    eventId = desdriver.ElementAt(x).EventId;
                }
            }
            var passenger = new Passenger { UserId = userId, DesDriverId = desId, EventId = eventId, Active = true, Accepted = false};
            using (var context = new STUFVModelContext())
            {
                context.Passengers.Add(passenger);
                context.SaveChanges();
            }
        }

        public int PassengersPerDriver(int id)
        {
            int count = 0;
            List<Passenger> passengers = GetAllPassengers();
            int x;
            for (x = 0; x < passengers.Count(); x++)
            {
                if (passengers.ElementAt(x).DesDriverId.Equals(id))
                {
                    count += 1;
                }
            }

            return count;
        }
    }
}