using Photo.Data;

namespace Photo.Service.ModelRequest;

public class PictureRequest: BaseModelRequest
{
    public Guid RegistrationId{ get; set; }
    public string PathBefore { get; set; }
    public string PathAfter { get; set; }
}