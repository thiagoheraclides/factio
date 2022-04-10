using Br.Com.FactIO.Domain.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Br.Com.FactIO.Domain.Entities
{
    public class User : BaseEntity
    {
        private User() { }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Credential Credential { get; private set; }
        public Contact Contact { get; private set; }
        public string Type { get; private set; }
        public bool Status { get; private set; }


        public static User CreateUser(string firstName, string lastName, Credential credencial, string type, string loggedUser)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Credential = credencial,
                Type = type,
                Status = true,
                CreatedBy = loggedUser,
                CreatedOn = DateTime.Now
            };
        }

    }
}
