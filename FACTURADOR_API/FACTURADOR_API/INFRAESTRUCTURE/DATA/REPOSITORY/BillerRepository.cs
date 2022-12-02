using FACTURADOR_API.DOMAIN.MODELS;
using System.Diagnostics;
using System.Linq;

namespace FACTURADOR_API.INFRAESTRUCTURE.DATA.REPOSITORY
{
    public class BillerRepository : IBillerRepository
    {
        private IList<History> _history = new List<History>();
        private IList<User> _users = new List<User>();
        private IList<PrePagoPlan> _prePagoPlan= new List<PrePagoPlan>();
        private TimeOnly startNormalTime = new TimeOnly(06,30,00);
        private TimeOnly finishNormalTime = new TimeOnly(20, 00, 00);
        private TimeOnly startReducidoTime = new TimeOnly(20, 01, 00);
        private TimeOnly finishReducidoTime = new TimeOnly(00, 59, 00);
        private TimeOnly startSuperReducidoTime = new TimeOnly(01, 00, 00);
        private TimeOnly finishSuperReducidoTime = new TimeOnly(06, 29, 00);

        public BillerRepository()
        {
            //DATOS PRE PAGO
            _prePagoPlan.Add(new PrePagoPlan()
            {
                Id = 1,
                Category = "Pre Pago Libre",
                HorNormalPrice = 1.70,
                HorReducidoPrice = 0.80,
                HorSuperReducidoPrice = 0.50,
                SMSPrice = 0.2
            });
            _prePagoPlan.Add(new PrePagoPlan()
            {
                Id = 2,
                Category = "Pre Pago Familia",
                HorNormalPrice = 1.70,
                HorReducidoPrice = 0.75,
                HorSuperReducidoPrice = 0.50,
                SMSPrice = 0.2
            });

            //DATOS USUARIOS
            _users.Add(new User()
            {
                Id = 1,
                CI = "1457890",
                Name = "Persona 1",
                TypePlan = "Prepago",
                CategoryId = 1
            });
            _users.Add(new User()
            {
                Id = 2,
                CI = "3654781",
                Name = "Persona 2",
                TypePlan = "Prepago",
                CategoryId = 2
            });

            //DATOS HISTORIAL
            _history.Add(new History()
            {
                Id = 1,
                UserCI = "3654781",
                Activity = "Llamada",
                StartHour = new DateTime(2022, 12, 01, 14, 0, 0),
                EndHour = new DateTime(2022, 12, 01, 14, 2, 0)
            });
            _history.Add(new History()
            {
                Id = 2,
                UserCI = "3654781",
                Activity = "Llamada",
                StartHour = new DateTime(2022, 12, 08, 6, 0, 7),
                EndHour = new DateTime(2022, 12, 08, 6, 4, 56)
            });
            _history.Add(new History()
            {
                Id = 3,
                UserCI = "3654781",
                Activity = "Llamada",
                StartHour = new DateTime(2022, 11, 29, 10, 30, 0),
                EndHour = new DateTime(2022, 11, 29, 10, 30, 35)
            });


            _history.Add(new History()
            {
                Id = 4,
                UserCI = "1457890",
                Activity = "Llamada",
                StartHour = new DateTime(2022, 06, 27, 14, 59, 0),
                EndHour = new DateTime(2022, 06, 27, 15, 2, 0)
            });
            _history.Add(new History()
            {
                Id = 5,
                UserCI = "1457890",
                Activity = "Llamada",
                StartHour = new DateTime(2022, 06, 08, 4, 39, 30),
                EndHour = new DateTime(2022, 06, 08, 4, 40, 30)
            });
            _history.Add(new History()
            {
                Id = 6,
                UserCI = "1457890",
                Activity = "Llamada",
                StartHour = new DateTime(2022, 07, 01, 23, 30, 0),
                EndHour = new DateTime(2022, 07, 01, 23, 31, 54)
            });
            _history.Add(new History()
            {
                Id = 7,
                UserCI = "1457890",
                Activity = "SMS",
                StartHour = new DateTime(2022, 06, 01, 23, 30, 0),
                EndHour = new DateTime(2022, 06, 01, 23, 30, 0)
            });
            _history.Add(new History()
            {
                Id = 8,
                UserCI = "1457890",
                Activity = "SMS",
                StartHour = new DateTime(2022, 06, 30, 3, 30, 0),
                EndHour = new DateTime(2022, 06, 30, 3, 30, 0)
            });
            _history.Add(new History()
            {
                Id = 9,
                UserCI = "3654781",
                Activity = "SMS",
                StartHour = new DateTime(2022, 12, 30, 3, 30, 0),
                EndHour = new DateTime(2022, 12, 30, 3, 30, 0)
            });
        }


        public Biller GetBiller(string userCI, DateTime startMonth, DateTime finishMonth)
        {
            var newBiller = new Biller();

            var user = _users.FirstOrDefault(x => x.CI == userCI);
            var userHistory = _history.Where(x => x.UserCI == userCI && x.StartHour >= startMonth && x.EndHour <= finishMonth);
            var userPlan = _prePagoPlan.FirstOrDefault(x => x.Id == user.CategoryId);

            var userHistoryNormal = getHistoryTime(userHistory, startNormalTime, finishNormalTime);
            var userHistoryReduce = getHistoryTime(userHistory, startReducidoTime, finishReducidoTime);
            var userHistorySuperReduce = getHistoryTime(userHistory, startSuperReducidoTime, finishSuperReducidoTime);

            foreach (var history in userHistory)
            {
                newBiller.AmountTotalSMS ++;
            }
            foreach (var normalHistory in userHistoryNormal)
            {
                newBiller.AmountTotalHoursNormal += getMinutes(normalHistory);
            }
            foreach (var reduceHistory in userHistoryReduce)
            {
                newBiller.AmountTotalHoursReducido += getMinutes(reduceHistory);
            }
            foreach (var superReduceHistory in userHistorySuperReduce)
            {
                newBiller.AmountTotalHoursSuperReducido += getMinutes(superReduceHistory);
            }
            newBiller.UserCI = user.CI;
            newBiller.NameUser = user.Name;
            newBiller.TypePlan = "Pre Pago";
            newBiller.Category = userPlan.Category;
            newBiller.TotalSMSPrice = Math.Round(newBiller.AmountTotalSMS * userPlan.SMSPrice);
            newBiller.TotalNormalPrice = newBiller.AmountTotalHoursNormal * userPlan.HorNormalPrice;
            newBiller.TotalReducidoPrice = newBiller.AmountTotalHoursReducido * userPlan.HorReducidoPrice;
            newBiller.TotalSuperReducidoPrice = newBiller.AmountTotalHoursSuperReducido * userPlan.HorSuperReducidoPrice;
            newBiller.TotalPayment = Math.Round(newBiller.TotalSMSPrice + newBiller.TotalNormalPrice + newBiller.TotalReducidoPrice + newBiller.TotalSuperReducidoPrice, 2);
            return newBiller;
        }

        public IEnumerable<History> getHistoryTime(IEnumerable<History> history, TimeOnly start, TimeOnly finish)
        {
            var historyList = history.Where(x =>
                                                        x.StartHour >= new DateTime(x.StartHour.Year, x.StartHour.Month, x.StartHour.Day, start.Hour, start.Minute, start.Second) &&
                                                        x.EndHour <= new DateTime(x.EndHour.Year, x.EndHour.Month, x.EndHour.Day, finish.Hour, finish.Minute, finish.Second));
            return historyList;
        }
        public int  getMinutes(History history)
        {
            var duration = (int) (history.EndHour - history.StartHour).TotalMinutes;
            return duration;
        }
    }
}
