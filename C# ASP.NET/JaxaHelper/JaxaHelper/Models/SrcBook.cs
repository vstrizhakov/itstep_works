using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JaxaHelper.Models
{
	public class SrcBook
	{
		public int id { get; set; } = 0;
		public int code { get; set; } = 0;
		public int @new { get; set; } = 1;
		public string name { get; set; } = "book";
		public decimal price { get; set; } = 19;
		public string izd { get; set; } = "lol";
		public int npages { get; set; } = 123;
		public string format { get; set; } = "123";
		public string dateizd { get; set; } = "12.11.2018";
		public int pressrun { get; set; } = 99;
		public string themes { get; set; } = "rweqr";
		public string category { get; set; } = " werwer";
	}
}