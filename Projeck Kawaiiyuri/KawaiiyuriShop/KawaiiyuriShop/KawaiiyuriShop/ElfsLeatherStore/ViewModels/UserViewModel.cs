using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ElfsLeatherStore.ViewModels
{
    public class UserViewModel
    {
        public string UserId { get; set; }
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        public string Email { get; set; }
    }
}