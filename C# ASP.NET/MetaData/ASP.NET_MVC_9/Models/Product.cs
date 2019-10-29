using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_MVC_9.Models
{
	[ValidateInput(true)]
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int id { get; set; }

        [Display(Name = "Название")] // то что будет отображаться на странице
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Display(Name="Стоимость")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [Display(Name = "Масса")]
        public int Weight { get; set; }

        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Email")] 
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}