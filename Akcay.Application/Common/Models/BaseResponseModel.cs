namespace Akcay.Application.Common.Models;

public class BaseResponseModel<T>
{
    public string FriendlyMessage { get; set; }
    public List<string> ErrorMessageList { get; set; }
    public T Data { get; set; }

    public BaseResponseModel()
    {
        
    }

    public BaseResponseModel(T data,string message = "")
    {
        FriendlyMessage = message;
        Data = data;
    }

    public BaseResponseModel(string message)
    {
        FriendlyMessage = message;
    }

    public BaseResponseModel(List<string> messages)
    {
        FriendlyMessage = "Technical Error";
        ErrorMessageList = messages;
    }
}