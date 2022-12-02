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
        public void TestMethod1()
        {
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
        }
    }
}
