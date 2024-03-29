﻿using System;
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
        public string GetPassengerName(int userId) {
            IUserRepository iuser = new UserRepository();
            List<User> users = iuser.GetAllUsers();
            User user = users.Single(e => e.Id == userId);
            return user.LastName + " " + user.FirstName;
        }
        public string GetProfilePicture(int userId) {
            IUserRepository iuser = new UserRepository();
            List<User> users = iuser.GetAllUsers();
            User user = users.Single(e => e.Id == userId);
            return user.ProfilePicture;
        }
        public bool IsPassenger(int desId, int userId, out int eventId)
        {
            List<Passenger> passengers = GetAllPassengers();
            int x;
            eventId = 0;
            for (x = 0; x < passengers.Count(); x++)
            {
                if (passengers.ElementAt(x).DesDriverId.Equals(desId) && passengers.ElementAt(x).UserId.Equals(userId) && passengers.ElementAt(x).Active == true && passengers.ElementAt(x).Accepted == true)
                {
                    eventId = passengers.ElementAt(x).EventId;
                    return true;
                }
            }
            return false;
        }
        public bool SignedUp(int desId, int userId)
        {
            List<Passenger> passengers = GetAllPassengers();
            int x;
            for (x = 0; x < passengers.Count(); x++)
            {
                if (passengers.ElementAt(x).DesDriverId.Equals(desId) && passengers.ElementAt(x).UserId.Equals(userId) && passengers.ElementAt(x).Active == true)
                {
                    return true;
                }
            }
            return false;
        }

        public void NewPassenger(int userId, int desId, out int eventId)
        {
            eventId = 0;
            IDesDriverRepository ides = new DesDriverRepository();
            List<DesDriver> desdriver = ides.GetAllDrivers();
            eventId = desdriver.Single(d => d.Id == desId).EventId;
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
            count = passengers.Count(e => e.DesDriverId == id && e.Active && e.Accepted);
            return count;
        }
    }
}