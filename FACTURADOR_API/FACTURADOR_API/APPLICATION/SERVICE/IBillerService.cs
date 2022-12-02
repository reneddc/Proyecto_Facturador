using FACTURADOR_API.DOMAIN.MODELS;

namespace FACTURADOR_API.APPLICATION.SERVICE
{
    public interface IBillerService
    {
        Biller getBiller(string userCI, DateTime startMonth, DateTime finishMonth);
    }
}
