using System;
using System.Linq;

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockApp.MyModels;
using StockApp1.API.MyData;

namespace StockApp.MyData
{
    public class AuthRepository : IAuthRepository
    {
        private readonly StockDataContext _context;
        public AuthRepository( StockDataContext context)
        {
             _context = context;
        }
        public async Task<Userlogin> Login(string username, string pwd)
        {
            var user = await _context.Userlogins.FirstOrDefaultAsync(x => x.Username == username);
            if (user == null)
                return null;
            
            if (!VerifyPasswordHash( pwd, user.PwdHash, user.PwdSalt))
                return null;

            // auth OK
            return user;
        }

        private bool VerifyPasswordHash(string pwd, byte[] pHash, byte[] pSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(pSalt))
                {
                    var realHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pwd));
                    for (int i=0; i < realHash.Length; i++)
                        if(realHash[i] != pHash[i])
                            return false;
                } 
            return true;   
        }
        public async Task<Userlogin> Register(Userlogin user, string pwd)
        {
            byte[] pHash, pSalt;
            CreatePwdHash(pwd, out pHash, out pSalt);

            // add to db
            user.PwdHash = pHash;
            user.PwdSalt = pSalt;

            // add to our users then save to db
            await _context.Userlogins.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private void CreatePwdHash(string pwd, out byte[] pHash, out byte[] pSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
                {
                    pSalt = hmac.Key;
                    pHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pwd));
                }
             
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Userlogins.AnyAsync(x => x.Username == username))
                return true;
            return false;
        }
    }
}