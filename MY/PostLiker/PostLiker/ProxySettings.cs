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
using System.Net.Sockets;
using System.Threading;

namespace PostLiker
{
	public partial class ProxySettings : Form
	{
		private bool isChecking = false;
		public ProxySettings()
		{
			InitializeComponent();

			this.progressBar.Maximum = 0;
		}

		private void CheckProxy(object sender, EventArgs e)
		{
			if (this.isChecking == true)
				return;
			String proxies = this.inputProxy.Text;
			String[] proxyArray = proxies.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
			this.progressBar.Maximum = proxyArray.Length;
			this.progressBar.Value = 0;
			this.checkProxyButton.Enabled = false;
			this.outputProxy.Items.Clear();
			foreach (String proxy in proxyArray)
			{
				ProxyChecker PC = new ProxyChecker("https://google.com/", proxy, this.outputProxy, this.progressBar);
				Thread T = new Thread(PC.Check);
				T.IsBackground = true;
				T.Start();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			String result = "";
			foreach (String s in this.outputProxy.Items)
				result += s + "\r\n";
			Clipboard.SetText(result);
		}

		private void outputProxy_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.outputProxy.SelectedItems.Count > 0)
				this.outputProxy.ContextMenuStrip = this.contextMenuStrip1;
			else
				this.outputProxy.ContextMenuStrip = null;
		}

		private void скопироватьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.outputProxy.SelectedItems.Count > 0)
			{
				String result = "";
				foreach (String s in this.outputProxy.SelectedItems)
					result += s + "\r\n";
				Clipboard.SetText(result);
			}
			else
				MessageBox.Show("Выберите хотя бы один элемен для того, чтобы скопировать", "Ошибка", MessageBoxButtons.OK);
		}

		private void inputProxy_TextChanged(object sender, EventArgs e)
		{
			if (this.progressBar.Maximum == this.progressBar.Value || this.progressBar.Maximum == 0)
				this.checkProxyButton.Enabled = true;
		}
	}

	class ProxyChecker
	{
		private String proxy;
		private String url;
		private ListBox proxy_list;
		private ProgressBar p_bar;

		public ProxyChecker(String url, String proxy, ListBox proxy_list, ProgressBar p_bar)
		{
			this.proxy = proxy;
			this.url = url;
			this.proxy_list = proxy_list;
			this.p_bar = p_bar;
		}

		public void Check()
		{
			try
			{
				HttpWebRequest HWR = WebRequest.CreateHttp("https://google.com");
				HWR.Proxy = new WebProxy(proxy.ToString());
				HWR.Timeout = 30000;
				HttpWebResponse HWS = (HttpWebResponse)HWR.GetResponse();
				this.proxy_list.Items.Add(proxy);
			}
			catch { }
			finally
			{
				this.p_bar.Invoke(new Action(() => { this.p_bar.Value++; }));
			}
		}
	}
}
