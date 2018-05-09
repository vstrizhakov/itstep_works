using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Media.Animation;

namespace ImageViewer
{
	/// <summary>
	/// Логика взаимодействия для SlideShow.xaml
	/// </summary>
	public partial class SlideShow : Window
	{
		private DispatcherTimer DT = new DispatcherTimer();
		private int i = 0;
		private ItemCollection SlideShowImages { get; set; }
		public SlideShow(ItemCollection OCIB)
		{
			InitializeComponent();
			this.SlideShowImages = OCIB;
			this.WindowState = WindowState.Maximized;
			DT.Tick += new EventHandler(ShowImage);
			DT.Interval = new TimeSpan(0, 0, 0);
			DT.Start();
		}

		private void ShowImage(object sender, EventArgs e)
		{
			if (i == 0)
				DT.Interval = new TimeSpan(0, 0, 3);
			this.SlideShowImage.Source = new BitmapImage(new Uri(((ImageBlock)this.SlideShowImages[i++]).Info.Key));
			if (this.WrapViewer.ActualWidth < ((BitmapImage)this.SlideShowImage.Source).PixelWidth || this.WrapViewer.ActualHeight < ((BitmapImage)this.SlideShowImage.Source).PixelHeight)
				this.SlideShowImage.Stretch = Stretch.Uniform;
			else
				this.SlideShowImage.Stretch = Stretch.None;
			this.ShowImg();
			if (this.i >= this.SlideShowImages.Count)
				DT.Stop();
		}

		private void ShowImg()
		{
			DoubleAnimation DA = new DoubleAnimation();
			DA.From = 0;
			DA.To = 1;
			DA.Duration = TimeSpan.FromMilliseconds(1000);
			this.SlideShowImage.BeginAnimation(Grid.OpacityProperty, DA);
		}

		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Escape)
			{
				DT.Stop();
				this.Close();
			}
			if (e.Key == Key.Right)
			{
				if (i > this.SlideShowImages.Count)
					return;
				this.ShowImage(null, null);
				DT.Stop();
				DT.Start();
			}
			if (e.Key == Key.Left)
			{
				if (i <= 0)
					return;
				this.i -= 2;
				this.ShowImage(null, null);
				DT.Stop();
				DT.Start();
			}
		}
	}
}
