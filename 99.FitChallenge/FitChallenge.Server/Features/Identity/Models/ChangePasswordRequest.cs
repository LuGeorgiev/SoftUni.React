using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitChallenge.Server.Features.Identity.Models
{
    public class ChangePasswordRequest
    {
        public string CurrentPassword { get; set; }

        public string OldPassword { get; set; }
    }
}
