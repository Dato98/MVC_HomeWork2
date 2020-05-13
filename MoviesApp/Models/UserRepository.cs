using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }

        List<string> Create(User user);

    }


    public class UserRepository : IUserRepository
    {
        private List<User> Data = new List<User>()
            {
                
            };

        public IEnumerable<User> Users => Data;

        public List<string> Create(User user)
        {
            List<string> errors = new List<string>();
            if (!ExistsEmail(user.Email))
                errors.Add("ელ ფოსტა უკვე რეგისტრირებულია");
            if (!PasswordMatch(user.Password, user.PasswordConfirmation))
                errors.Add("პაროლები არ ემთხვევა ერთმანეთს");
            if (errors.Count > 0)
                return errors;
            var mv = Data.OrderBy(x => x.Id).LastOrDefault();
            user.Id = mv != null ? mv.Id + 1 : 1;
            Data.Add(user);

            return null;
        }

        private bool ExistsEmail(string email)
        {
            var Email = Data.Find(e => e.Email == email);
            if (Email != null)
                return false;
            return true;
        }

        private bool PasswordMatch(string pass,string reppass)
        {
            if (pass == reppass)
                return true;
            return false;
        }
    }
}
