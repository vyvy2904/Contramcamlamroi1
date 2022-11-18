﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Contramcamlamroi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public partial class AdminUser
    {
        [Display(Name = "Mã User")]
        [Required(ErrorMessage = "ID not empty ...")]
        public int ID { get; set; }

        [Display(Name = "Tên User")]
        [Required(ErrorMessage = "Name not empty ...")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Length of the name from 5 - 50 characters")]
        public string NameUser { get; set; }

        [Display(Name = "Nhập mật khẩu")]
        [Required(ErrorMessage = "Pass not empty ...")]
        [DataType(DataType.Password)]
        public string PasswordUser { get; set; }

        [NotMapped]
        [Display(Name = "Nhập lại mật khẩu ")]
        [Compare("PasswordUser", ErrorMessage = "Password not matched")]
        [DataType(DataType.Password)]
        public string ConfirmPass { get; set; }

        [NotMapped]
        public string ErrorLogin { get; set; }

        [Display(Name = "Vị trí")]
        public string RoleUser { get; set; }
    }

}