using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace admin_master_pro__mvc_.Models
{
    public class EmployeeViewModel
    {
        public Guid ID { get; set; }
        [Required(ErrorMessage = "This is a mandatory field.")]
        public string firstname { get; set; }
        [Required(ErrorMessage = "This is a mandatory field.")]
        public string lastname { get; set; }
        [Required(ErrorMessage = "This is a mandatory field.")]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
        ErrorMessage = "Please enter a valid E-mail Id.")]
        public string email { get; set; }
        [Required(ErrorMessage = "This is a mandatory field.")]
        public string contactnumber { get; set; }
        [Required(ErrorMessage = "This is a mandatory field.")]
        public string companyname { get; set; }
        [Required(ErrorMessage = "This is a mandatory field.")]
        public DateTime dateofjoining { get; set; }
        [Required(ErrorMessage = "This is a mandatory field.")]
        public List<string> qualification { get; set; }
        [Required(ErrorMessage = "This is a mandatory field.")]
        public List<Int32> marks { get; set; }


    }
}