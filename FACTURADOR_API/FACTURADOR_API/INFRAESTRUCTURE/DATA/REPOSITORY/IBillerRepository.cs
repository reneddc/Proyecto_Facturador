
using FACTURADOR_API.DOMAIN.MODELS;

namespace FACTURADOR_API.INFRAESTRUCTURE.DATA.REPOSITORY
{
    public interface IBillerRepository
    {
        Biller GetBiller(string userCI, DateTime startMonth, DateTime finishMonth);
    }
}
