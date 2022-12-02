namespace FACTURADOR_API.DOMAIN.MODELS
{
    public class History
    {
        public int Id { get; set; }
        public string UserCI { get; set; }
        public string Activity { get; set; }
        public DateTime StartHour { get; set; }
        public DateTime EndHour { get; set; }
    }
}
