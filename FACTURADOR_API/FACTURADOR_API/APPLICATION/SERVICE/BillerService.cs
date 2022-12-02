using FACTURADOR_API.DOMAIN.MODELS;
using FACTURADOR_API.INFRAESTRUCTURE.DATA.REPOSITORY;
using System.Reflection.Metadata.Ecma335;

namespace FACTURADOR_API.APPLICATION.SERVICE
{
    public class BillerService : IBillerService
    {
        private IBillerRepository _billerRepository;
        public BillerService(IBillerRepository billerRepository)
        {
            _billerRepository = billerRepository;
        }
        public Biller getBiller(string userCI, DateTime startMonth, DateTime finishMonth)
        {
            if(userCI == null)
            {
                throw new NotImplementedException("El cliente no existe");
            }
            var biller = _billerRepository.GetBiller(userCI, startMonth, finishMonth);
            return biller;
        }

    }
}
