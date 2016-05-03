using System.Collections.Generic;

namespace STUFV.Repository
{
    public interface IPassengerRepository
    {
        List<Passenger> GetAllPassengers();
        void NewPassenger(int userId, int desId);
        int PassengersPerDriver(int id);
        bool IsPassenger(int driverId, int userId);

    }
}