namespace ShoppingListApp.Application.Common.Responses;
public class FileResponse
{
    public byte[] Data { get; set; }
    public string ContentType { get; set; }
    public string FileName { get; set; }
}
