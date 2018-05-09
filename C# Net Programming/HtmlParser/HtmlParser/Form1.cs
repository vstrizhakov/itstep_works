using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Threading;

namespace HtmlParser
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			this.listView1.Columns.Add("Название");
			this.listView1.Columns.Add("Цена");
		}

		private String GetSubStr(String start, String end, ref String content)
		{
			int startPos = content.IndexOf(start) + start.Length;
			int endPos = content.IndexOf(end);
			int length = endPos - startPos;
			if (length < 0)
				return null;
			String result = content.Substring(startPos, length);
			content = content.Substring(endPos + end.Length);
			return result;
		}

		private List<Product> GetProductsFromPage(String page)
		{
			List<Product> products = new List<Product>();
			String start = "<div class=\"g-i-tile g-i-tile-catalog\" data-location=\"SearchResults\">";
			String end = "if (pricerawjson) price = JSON.parse(decodeURIComponent(pricerawjson));";
			String productBlock = this.GetSubStr(start, end, ref page);
			Regex priceBlockEx = new Regex("var pricerawjson = '(.*)'");
			Regex priceEx = new Regex("{\"price\":(.*),\"status");
			Regex imgEx = new Regex("data-rz-lazy-load-src=\"(.*)\"");
			Regex nameEx = new Regex("<a onclick=.*>(.*)</a>", RegexOptions.Singleline);
			while (productBlock != null)
			{
				String jsonPrice = HttpUtility.UrlDecode(priceBlockEx.Match(productBlock).Groups[1].Value);
				String price = priceEx.Match(jsonPrice).Groups[1].Value;
				String img = imgEx.Match(productBlock).Groups[1].Value;
				String name = nameEx.Match(productBlock).Groups[1].Value.Trim();
				//MessageBox.Show(price + " - " + img + " - " + name);
				products.Add(new Product(img, name, price));
				productBlock = this.GetSubStr(start, end, ref page);
			}
			return products;
		}

		private void LoadImage(object P)
		{
			Product product = (Product)P;
			HttpWebRequest webRequest = WebRequest.CreateHttp(product.Image);
			HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
			if (webResponse.StatusCode == HttpStatusCode.OK)
			{
				Stream receiveStream = webResponse.GetResponseStream();
				StreamReader SR = new StreamReader(receiveStream);
				Image img = Bitmap.FromStream(receiveStream);
				lock (this.imageList1)
				{
					this.imageList1.Images.Add(img);
					product.ImageIndex = this.imageList1.Images.Count - 1;
				}
			}
		}

		private void LoadImages(object obj)
		{
			List<Product> products = (List<Product>)obj;
			List<Thread> threads = new List<Thread>();
			foreach (Product p in products)
			{
				Thread T = new Thread(this.LoadImage);
				T.IsBackground = true;
				T.Start(p);
			}

			foreach (Thread T in threads)
				T.Join();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				this.listView1.Items.Clear();
				String directUri = "https://rozetka.com.ua/search/?text=" + this.searchString.Text;
				HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(directUri);
				HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
				if (webResponse.StatusCode == HttpStatusCode.OK)
				{
					Stream receiveStream = webResponse.GetResponseStream();
					StreamReader SR = new StreamReader(receiveStream, Encoding.UTF8);
					List<Product> products = this.GetProductsFromPage(SR.ReadToEnd());
					//Thread T = new Thread(this.LoadImages);
					//T.IsBackground = true;
					//T.Start(products);
					//T.Join();
					if (products.Count == 0)
						MessageBox.Show("По Вашему запросу ничего не найдено");
					else
					{
						foreach (Product P in products)
						{
							this.LoadImage(P);
							ListViewItem LVI = new ListViewItem(P.Name);
							LVI.SubItems.Add(P.Price + " грн");
							LVI.ImageIndex = P.ImageIndex;

							this.listView1.Items.Add(LVI);
						}
					}
				}
				else
				{
					MessageBox.Show(String.Format("Получен ответ: {0} - {1}", webResponse.StatusCode, webResponse.StatusDescription));
				}
			}
			catch (Exception a)
			{
				MessageBox.Show(a.Message);
			}
		}

		private void searchString_Enter(object sender, EventArgs e)
		{
			if (this.searchString.Text == "Введите запрос...")
			{
				this.searchString.Text = "";
				this.searchString.ForeColor = Color.Black;
			}
		}

		private void searchString_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
				this.button1_Click(null, null);
		}

		private void searchString_Leave(object sender, EventArgs e)
		{
			if (this.searchString.Text == "")
			{
				this.searchString.Text = "Введите запрос...";
				this.searchString.ForeColor = Color.Gray;
			}
		}
	}

	class Product
	{
		public String Image { get; set; }
		public String Name { get; set; }
		public String Price { get; set; }
		public int ImageIndex { get; set; } = 0;
		public Product(String img, String name, String price)
		{
			this.Image = img;
			this.Name = name;
			this.Price = price;
		}
	}
}
