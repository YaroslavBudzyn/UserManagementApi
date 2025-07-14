using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validators
{
    public static  class UserValidator
    {
        public static void Validate(User user)
        {
            if (string.IsNullOrWhiteSpace(user.FullName) || user.FullName.Length < 2)
                throw new ArgumentException("FullName is required and must be at least 2 characters.");

            if (!IsValidEmail(user.Email))
                throw new ArgumentException("Invalid email format.");

            if (user.DateOfBirth > DateTime.UtcNow)
                throw new ArgumentException("DateOfBirth cannot be in the future.");
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
