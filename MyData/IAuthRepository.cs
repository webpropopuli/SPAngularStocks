using System.Threading.Tasks;
using StockApp.MyModels;

namespace StockApp.MyData
{
    /* This repository adds a layer between the DB and the API as I'll probably
    move this to a different DB at some point.
     */
    public interface IAuthRepository
    {
        Task<Userlogin> Register(Userlogin user, string pwd);
        Task<Userlogin> Login(string username, string pwd);
        Task<bool> UserExists(string username);
    }
}