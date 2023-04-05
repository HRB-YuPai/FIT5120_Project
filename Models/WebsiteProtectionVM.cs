using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FIT5120_Quality_Education_in_Australia_Iterastion_01.Models
{
    public class WebsiteProtectionVM
    {
        [Required]
        public string password { get; set; }
    }
}