using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapp_stufv.Models;

namespace webapp_stufv.Repository
{
    public interface IPassengerRepository
    {
        List<Passenger> GetAllPassengers();
        void NewPassenger(int userId, int desId);
        int PassengersPerDriver(int id);
        bool IsPassenger(int driverId, int userId);

    }
}