using System.Collections.Generic;
namespace STUFV.Repository
{
    public interface IEmergencyRepository
    {
        List<Emergency> getAllEmergencies();
    }
}