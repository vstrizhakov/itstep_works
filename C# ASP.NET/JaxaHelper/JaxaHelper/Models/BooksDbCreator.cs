using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace JaxaHelper.Models
{
	public class BooksDbCreator : DropCreateDatabaseAlways<BookContext>
	{
		protected override void Seed(BookContext context)
		{
			context.Books.Add(new SrcBook()
			{
				name = "",

			});
			base.Seed(context);
		}
	}
}