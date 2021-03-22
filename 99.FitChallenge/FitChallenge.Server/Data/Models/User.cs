using System;
using FitChallenge.Server.Data.Models.Base;
using Microsoft.AspNetCore.Identity;

namespace FitChallenge.Server.Data.Models
{
    public class User : IdentityUser, IEntity
    {
        public Profile Profile { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
