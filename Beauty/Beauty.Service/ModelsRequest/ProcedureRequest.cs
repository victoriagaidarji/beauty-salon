using Beauty.Data;

namespace Beauty.Service.ModelsRequest
{
    public class ProcedureRequest : BaseModelRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Duration { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}