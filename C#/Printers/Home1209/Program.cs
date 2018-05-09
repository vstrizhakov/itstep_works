using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home1209
{
	class Document
	{
		private String[] pages;
		private String header;

		public Document(String[] pages, String header)
		{
			this.pages = pages;
			this.header = header;

		}

		public String[] Pages
		{
			set
			{
				this.pages = value;
			}
			get
			{
				return this.pages;
			}
		}

		public String Header
		{
			set
			{
				this.header = value;
			}
			get
			{
				return this.header;
			}
		}

		public override string ToString()
		{
			String doc = "";
			doc += "===================================================================================================\n";
			doc += "Заголовок: " + this.header + "\n";
			doc += "===================================================================================================\n\n";
			for (int i = 0; i < this.pages.Length; i++)
			{
				doc += this.pages[i] + "\n\n";
				doc += "===================================================================================================\n";
				doc += "Страница " + (i + 1) + "\n";
				doc += "===================================================================================================\n\n";
			}
			return doc;
		}
	}
	abstract class Printer
	{
		protected String type;

		public Printer()
		{
			this.type = "Неизвестный принтер";
		}

		abstract public void Print(Document doc);
	}

	class MatrixPrinter : Printer
	{
		public MatrixPrinter()
		{
			this.type = "Матричный принтер";
		}

		public override void Print(Document doc)
		{
			Console.WriteLine("~~~~~ {0} печатает документ {1}\n", this.type, doc.Header);
			Console.WriteLine(doc);
			Console.WriteLine("~~~~~ {0} напечатал документ {1}", this.type, doc.Header);
		}
	}

	class JetPrinter : Printer
	{
		public JetPrinter()
		{
			this.type = "Струйный принтер";
		}

		public override void Print(Document doc)
		{
			Console.WriteLine("~~~~~ {0} печатает документ {1}\n", this.type, doc.Header);
			Console.WriteLine(doc);
			Console.WriteLine("~~~~~ {0} напечатал документ {1}", this.type, doc.Header);
		}
	}

	class LaserPrinter : Printer
	{
		public LaserPrinter()
		{
			this.type = "Лазерный принтер";
		}

		public override void Print(Document doc)
		{
			Console.WriteLine("~~~~~ {0} печатает документ {1}\n", this.type, doc.Header);
			Console.WriteLine(doc);
			Console.WriteLine("~~~~~ {0} напечатал документ {1}", this.type, doc.Header);
		}
	}

	class ColorPrinter : Printer
	{
		public ColorPrinter()
		{
			this.type = "Цветной принтер";
		}

		public override void Print(Document doc)
		{
			Console.WriteLine("~~~~~ {0} печатает документ {1}\n", this.type, doc.Header);
			Console.WriteLine(doc);
			Console.WriteLine("~~~~~ {0} напечатал документ {1}", this.type, doc.Header);
		}
	}

	class CopyCenter
	{
		private Printer p;

		public CopyCenter(Printer p)
		{
			this.p = p;
		}

		public Printer P
		{
			set
			{
				this.p = value;
			}
			get
			{
				return this.p;
			}
		}

		public void Print(Document doc)
		{
			this.p.Print(doc);
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Random R = new Random();
			String[] pg = new String[3];
			pg[0] = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas et mattis arcu. Aenean dapibus gravida suscipit. Nullam eu viverra nunc. Nulla imperdiet ultricies justo et elementum. Phasellus consequat mollis posuere. Etiam metus velit, volutpat non semper et, fermentum in sapien. Quisque in turpis maximus tortor tempor dignissim ut et leo. Cras eget nisl accumsan, vestibulum tellus egestas, dapibus augue. Ut convallis vel est sed mattis. Donec auctor metus at iaculis interdum. Donec at volutpat sem, eget rhoncus turpis. Proin accumsan vehicula nibh sed efficitur. Fusce vitae purus vitae risus finibus faucibus vel dapibus sem. Pellentesque sollicitudin, nunc id condimentum tristique, sem nunc condimentum quam, vel vulputate risus arcu ut ligula.Suspendisse imperdiet dignissim nunc vitae hendrerit. Phasellus convallis ac quam sed aliquam. Suspendisse luctus, lacus ut tincidunt tempus, mi lorem sagittis ex, ac convallis justo ante quis purus.Mauris ut arcu interdum, vehicula ipsum ut, lacinia ligula.Nullam faucibus pulvinar felis, vel lobortis turpis blandit ac. Curabitur dui nulla, varius congue tortor pharetra, aliquet tincidunt tellus. Praesent elit felis, ullamcorper dignissim turpis id, dignissim accumsan tellus. Nam ac arcu imperdiet, rutrum diam et, lobortis elit.Phasellus congue dui mi, non condimentum arcu euismod quis. Sed eget elit ex. Vivamus facilisis molestie lorem, ut auctor felis egestas ac. Vivamus cursus tincidunt varius. Nunc tincidunt scelerisque quam, in mollis urna malesuada in. Duis maximus porttitor lectus, eget semper nulla accumsan at. In maximus at odio ut sagittis. Nulla bibendum nulla nibh, vel accumsan magna fermentum condimentum. Duis sit amet nunc laoreet, malesuada est ut, suscipit est. Nulla quis neque at ante pellentesque dictum.Nullam nec laoreet dolor. Proin at arcu et sem pharetra varius ut nec libero. In aliquet ipsum a fermentum mollis. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.";
			pg[1] = "Curabitur luctus bibendum venenatis. Quisque faucibus rhoncus justo, et ultricies neque feugiat vel. Maecenas porttitor tortor at maximus malesuada. Vivamus venenatis tellus ultricies turpis maximus, ac maximus metus sagittis. Phasellus vitae vehicula ligula. Ut non lacus pharetra orci facilisis porttitor. Etiam cursus dui urna, vel dignissim neque tempor ut. Donec id sapien in ante fermentum convallis. Cras luctus vulputate rutrum. Praesent vitae rutrum velit. Nulla purus quam, posuere a commodo in, vestibulum vel leo. Sed at sagittis lorem. Morbi blandit, purus eget dignissim porttitor, diam diam lacinia ligula, at consectetur sem elit eget velit. Nulla aliquam dapibus velit ut tincidunt. Mauris ut eleifend nisi. Suspendisse suscipit nec nisl vel convallis. Integer eu augue justo. Nullam sem erat, placerat at diam vitae, aliquam accumsan ligula. Quisque cursus eros eget suscipit dictum. Nulla urna eros, convallis a pharetra eu, varius at dui. Aliquam erat volutpat.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Vivamus ut diam rutrum, auctor tellus eu, ornare quam.Donec lacinia justo vel leo feugiat, eget bibendum ante finibus.Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Cras ac massa vitae diam tempor eleifend sed ut justo. Etiam in elementum nibh. Donec velit augue, efficitur vel sollicitudin a, imperdiet at lacus. Vestibulum turpis ex, ultricies nec dolor nec, egestas viverra metus. Etiam ultrices fermentum nulla ac hendrerit. Cras vitae vulputate velit. Maecenas placerat mauris nec risus luctus finibus.Vestibulum eu sagittis eros, ac hendrerit neque. Aliquam et blandit lorem. Aenean placerat ligula in vestibulum dictum. Nam tempor, ipsum in venenatis dictum, magna libero congue justo, ut ullamcorper ante nisi quis ipsum. Nulla ante libero, scelerisque vitae vehicula ultricies, interdum in dui.Duis porttitor est vitae iaculis fringilla. Mauris et rutrum enim. Maecenas lobortis sollicitudin ex, eu laoreet sem sodales ac. Morbi vehicula, mauris vel elementum sodales, dolor est efficitur lorem, sed condimentum sapien purus non diam.Ut vitae nulla sit amet lacus rutrum eleifend non nec risus.In eget sapien eu nibh ultrices blandit.";
			pg[2] = "Quisque viverra ut nisl nec consequat. Mauris et purus condimentum dui ultricies rhoncus vel ac lacus. Suspendisse non porttitor magna. Cras pretium sapien et nibh pretium consectetur. Vestibulum augue libero, pellentesque lobortis enim quis, egestas vestibulum metus. Curabitur id nunc nulla. Integer condimentum elit a faucibus pellentesque. Vivamus justo orci, suscipit ut blandit non, suscipit non quam. Vestibulum malesuada urna sit amet elementum dictum. Aliquam tristique nulla a ipsum aliquet, posuere viverra sem pulvinar. Curabitur a nisi euismod, tincidunt est non, malesuada turpis. Nam ac mollis ex. Aliquam erat volutpat. Sed eu orci sit amet quam aliquam feugiat. In nisi velit, efficitur eget ultricies nec, interdum eget quam. Maecenas aliquam condimentum neque, eu tincidunt nisi. Curabitur eget eros in odio facilisis dapibus aliquam non eros. Fusce accumsan ac metus nec blandit. Nullam pretium est eget urna ornare, at semper nunc scelerisque.Ut aliquet massa a tortor dapibus blandit.In ullamcorper, dui ut consequat porttitor, augue lorem rhoncus eros, eu tincidunt neque mauris eu justo.Mauris porta nulla augue, id cursus quam fermentum et. Nunc porta ex tellus, eget blandit leo faucibus a. Morbi pellentesque cursus tortor, nec viverra nisi tempor nec. In hac habitasse platea dictumst.Sed bibendum ipsum quis vestibulum sodales. Vivamus lobortis nunc quis nisi euismod, sit amet ultricies ipsum pharetra. Phasellus ex orci, malesuada id nisl eget, ultricies vestibulum ante. Sed scelerisque leo in mauris lobortis, sit amet interdum massa malesuada. Suspendisse nisl turpis, viverra sit amet suscipit vitae, gravida eu turpis.Phasellus odio odio, dictum et ligula vitae, sagittis congue augue. Phasellus tincidunt metus at ligula porta tristique.Nulla facilisi. Integer euismod et eros eu pretium. Maecenas finibus auctor dolor ut condimentum. Duis in elit quam. Sed placerat aliquam purus. Phasellus ac sodales ex, iaculis vulputate purus. Praesent sed malesuada libero. Maecenas eu arcu felis.";
			Document doc = new Document(pg, "Lorem ipsum");

			Printer[] p = new Printer[4];
			p[0] = new MatrixPrinter();
			p[1] = new LaserPrinter();
			p[2] = new JetPrinter();
			p[3] = new ColorPrinter();

			CopyCenter cc = new CopyCenter(p[R.Next(0, 4)]);
			cc.Print(doc);
		}
	}
}
