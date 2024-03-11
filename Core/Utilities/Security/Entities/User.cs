using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Entities
{
    public class User : BaseEntity<int>
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public ICollection<UserOperationClaim> UserOperationClaims { get; set; }

        public User()
        {
            UserOperationClaims = new HashSet<UserOperationClaim>();
        }
        public User(int id,string userName, string firstName, string lastName, DateTime dateOfBirth, string email, byte[] passwordHash, byte[] passwordSalt)
        {
            Id = id;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
    }
}
