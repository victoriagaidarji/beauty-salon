namespace Photo.Data;

public class Picture: BaseModel
{
    public Registration Registration { get; set; }
    public string PathBefore { get; set; }
    public string PathAfter { get; set; }
}