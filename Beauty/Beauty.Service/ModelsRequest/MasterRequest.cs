using Beauty.Data;

namespace Beauty.Service.ModelsRequest
{
    public class MasterRequest : BaseModelRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public int Experience { get; set; }
        public string PhotoUrl { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
