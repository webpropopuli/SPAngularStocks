namespace StockApp.MyModels
{
    public class Userlogin
    {
    public int Id {get; set;} 
    public string Username {get; set;}
    public byte[] PwdHash {get; set;}
    public byte[] PwdSalt {get; set;}
    }
}