using System.ComponentModel;

namespace FACTURADOR_API.DOMAIN.MODELS
{
    public class PrePagoPlan
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public double HorNormalPrice { get; set; }
        public double HorReducidoPrice { get; set; }
        public double HorSuperReducidoPrice { get; set; }
        public double SMSPrice { get; set; }
    }
}
