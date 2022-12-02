using System.ComponentModel.DataAnnotations;

namespace FACTURADOR_API.DOMAIN.MODELS
{
    public class User
    {
        public int Id { get; set; }
        public string CI{ get; set; }
        public string Name { get; set; }
        public string TypePlan { get; set; }
        public int CategoryId { get; set; }
    }
}
