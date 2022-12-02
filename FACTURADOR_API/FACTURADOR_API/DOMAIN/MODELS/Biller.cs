namespace FACTURADOR_API.DOMAIN.MODELS
{
    public class Biller
    {
        public string UserCI { get; set; }
        public string NameUser { get; set; }
        public string TypePlan { get; set; }
        public string Category { get; set; }
        public double AmountTotalHoursNormal { get; set; }
        public double TotalNormalPrice { get; set; }
        public double AmountTotalHoursReducido { get; set; }
        public double TotalReducidoPrice { get; set; }
        public double AmountTotalHoursSuperReducido { get; set; }
        public double TotalSuperReducidoPrice { get; set; }
        public double AmountTotalSMS { get; set; }
        public double TotalSMSPrice { get; set; }
        public double TotalPayment { get; set; }

    }
}
