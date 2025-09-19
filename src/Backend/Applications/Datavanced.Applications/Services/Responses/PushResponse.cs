namespace Datavanced.Applications.Services.Responses;

public class PushResponse
{
    public bool DidSucceed { get; set; }
    public string Message { get; set; }

}

public class PushResponse<TModel> : PushResponse where TModel : BaseModel
{
    public TModel Model { get; set; }

    public List<TModel> Models { get; set; }

}