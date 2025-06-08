using Beauty.Data;

namespace Beauty.Service.ModelsRequest
{
    public class AppointmentRequest : BaseModelRequest
    {
        public Guid UserId { get; set; }
        public Guid MasterId { get; set; }
        public Guid ServiceId { get; set; } // Procedure
        public DateTime DateTime { get; set; }
        public string Status { get; set; } = "Запланирована";
    }
}
