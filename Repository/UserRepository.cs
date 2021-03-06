using ControleFinanceiro.Data;
using ControleFinanceiro.Entity;
using System.Collections.Generic;
using System.Linq;

namespace ControleFinanceiro.Repositories
{
    public static class UserRepository
    {
        
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Username = "admin", Password = "admin", Role = "manager" });
            users.Add(new User { Id = 2, Username = "suporte", Password = "suporte", Role = "suporte" });

            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == password).FirstOrDefault();
        }
    }
}