global using Microsoft.VisualStudio.TestTools.UnitTesting;
using FACTURADOR_API.APPLICATION.SERVICE;
using FACTURADOR_API.DOMAIN.MODELS;

namespace Tests
{
    [TestClass]
    public class BillerTests
    {
        private IBillerService _billerService;
        public BillerTests(IBillerService billerService)
        {
            _billerService = billerService;
        }

        
        [TestMethod]
        void shouldReturnTheBillerPerson2()
        {

            Biller expectedBiller = new Biller();
            Biller currentBiller = new Biller();

            var CI = "3654781";
            string startDate = "01/12/2022 0:00:00";
            string finishDate = "31/12/2022 23:59:59";

            currentBiller = _billerService.getBiller(CI, DateTime.Parse(startDate), DateTime.Parse(finishDate));

            expectedBiller.UserCI = CI;
            expectedBiller.NameUser = "Persona 2";
            expectedBiller.TypePlan = "Pre Pago";
            expectedBiller.Category = "Pre Pago Familia";
            expectedBiller.AmountTotalSMS = 1;
            expectedBiller.TotalSMSPrice = 0.2;
            expectedBiller.AmountTotalHoursNormal = 2;
            expectedBiller.TotalNormalPrice = 3.4;
            expectedBiller.AmountTotalHoursReducido = 0;
            expectedBiller.TotalReducidoPrice = 0;
            expectedBiller.AmountTotalHoursSuperReducido = 4;
            expectedBiller.TotalSuperReducidoPrice = 2;
            expectedBiller.TotalPayment = 5.6;

            Assert.AreEqual(expectedBiller, currentBiller);
        }

        [TestMethod]
        void shouldReturnTheBillerPerson1()
        {

            Biller expectedBiller = new Biller();
            Biller currentBiller = new Biller();

            var CI = "1457890";
            string startDate = "01/06/2022 0:00:00";
            string finishDate = "30/06/2022 23:59:59";

            currentBiller = _billerService.getBiller(CI, DateTime.Parse(startDate), DateTime.Parse(finishDate));

            expectedBiller.UserCI = CI;
            expectedBiller.NameUser = "Persona 1";
            expectedBiller.TypePlan = "Pre Pago";
            expectedBiller.Category = "Pre Pago Libre";
            expectedBiller.AmountTotalSMS = 2;
            expectedBiller.TotalSMSPrice = 0.4;
            expectedBiller.AmountTotalHoursNormal = 3;
            expectedBiller.TotalNormalPrice = 5.1;
            expectedBiller.AmountTotalHoursReducido = 0;
            expectedBiller.TotalReducidoPrice = 0;
            expectedBiller.AmountTotalHoursSuperReducido = 1;
            expectedBiller.TotalSuperReducidoPrice = 0.5;
            expectedBiller.TotalPayment = 6;

            Assert.AreEqual(expectedBiller, currentBiller);
        }
    }
    
}
