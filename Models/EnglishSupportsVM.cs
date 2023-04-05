using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIT5120_Quality_Education_in_Australia_Iteration_01.Models
{
    public partial class EnglishSupportsVM
    {
        public int Id { get; set; }
        public string InstitutionName { get; set; }
        public string Address { get; set; }
        public string Suburb { get; set; }
        public string DetailInformation { get; set; }
        public string Image { get; set; }
        public string OfficialWebsite { get; set; }
        public string Telephone { get; set; }
    }
}
