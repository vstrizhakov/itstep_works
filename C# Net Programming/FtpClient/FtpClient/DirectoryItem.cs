using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpClient
{
	class DirectoryItem
	{
		public String Name { get; set; }
		public String DateTime { get; set; }
		public String Size { get; set; }
		public bool IsDirectory { get; set; }

		public DirectoryItem(String name, String datetime, String size, bool isdirectory)
		{
			this.Name = name;
			this.DateTime = datetime;
			this.Size = size;
			this.IsDirectory = isdirectory;
		}
	}
}
