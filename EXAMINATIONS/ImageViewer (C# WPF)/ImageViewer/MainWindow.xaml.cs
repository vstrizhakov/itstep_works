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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.IO;
using System.Collections;
using System.Threading;
using Microsoft.Win32;

namespace ImageViewer
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private CancellationTokenSource CTS;
		private String prevPath;
		private double prevX;
		private double prevY;
		public MainWindow()
		{
			InitializeComponent();
			String[] drives = Directory.GetLogicalDrives();
			foreach (String drive in drives)
			{
				DirItem DI = new DirItem(drive, drive);
				try
				{
					if (Directory.GetDirectories(drive).Length != 0)
						DI.Nodes.Add(new DirItem("", null));
				}
				catch { }
				this.folders.Items.Add(DI);
			}
			this.ImageViewer.RenderTransform = new ScaleTransform();
		}

		private void img_MouseWheel(object sender, MouseWheelEventArgs e)
		{
			if (e.Delta > 0)
			{
				if (((ScaleTransform)this.ImageViewer.RenderTransform).ScaleX < 8)
				{
					((ScaleTransform)this.ImageViewer.RenderTransform).ScaleX += 0.05;
					((ScaleTransform)this.ImageViewer.RenderTransform).ScaleY += 0.05;
					((ScaleTransform)this.ImageViewer.RenderTransform).CenterX = e.GetPosition(relativeTo: this.ImageViewer).X;
					((ScaleTransform)this.ImageViewer.RenderTransform).CenterY = e.GetPosition(relativeTo: this.ImageViewer).Y;
				}
			}
			else
			{
				if (((ScaleTransform)this.ImageViewer.RenderTransform).ScaleX > 1)
				{
					((ScaleTransform)this.ImageViewer.RenderTransform).ScaleX -= 0.05;
					((ScaleTransform)this.ImageViewer.RenderTransform).ScaleY -= 0.05;
				}
			}
		}

		private void img_MouseMove(object sender, MouseEventArgs e)
		{

			if (e.LeftButton == MouseButtonState.Pressed)
			{
				Point ViewerLocation1 = this.ImageViewer.TranslatePoint(new Point(0, 0), relativeTo: this.WrapViewer);
				Point ViewerLocation2 = this.ImageViewer.TranslatePoint(new Point(this.ImageViewer.ActualWidth, this.ImageViewer.ActualHeight), relativeTo: this.WrapViewer);
				//MessageBox.Show(ViewerLocation2.X.ToString());
				double dX = this.prevX - e.GetPosition(relativeTo: this).X, dY = this.prevY - e.GetPosition(relativeTo: this).Y;
				if (dX > 0 && this.WrapViewer.ActualWidth - ViewerLocation2.X < 20)
					((ScaleTransform)this.ImageViewer.RenderTransform).CenterX += dX;
				else if (dX < 0 && ViewerLocation1.X < 20)
					((ScaleTransform)this.ImageViewer.RenderTransform).CenterX -= dX * -1;
				if (dY > 0 && this.WrapViewer.ActualHeight - ViewerLocation2.Y < 20)
					((ScaleTransform)this.ImageViewer.RenderTransform).CenterY += dY;
				else if (dY < 0 && ViewerLocation1.Y < 20)
					((ScaleTransform)this.ImageViewer.RenderTransform).CenterY -= dY * -1;
				this.prevX = e.GetPosition(relativeTo: this).X;
				this.prevY = e.GetPosition(relativeTo: this).Y;
			}
		}

		private void img_MouseUp(object sender, MouseButtonEventArgs e)
		{
			this.ImageViewer.Cursor = Cursors.Arrow;
		}

		private void img_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2)
			{
				if (((ScaleTransform)this.ImageViewer.RenderTransform).ScaleX < 8)
				{
					((ScaleTransform)this.ImageViewer.RenderTransform).ScaleX += (((ScaleTransform)this.ImageViewer.RenderTransform).ScaleX == 1) ? 1 : 2;
					((ScaleTransform)this.ImageViewer.RenderTransform).ScaleY += (((ScaleTransform)this.ImageViewer.RenderTransform).ScaleY == 1) ? 1 : 2;
				}
				else
				{
					((ScaleTransform)this.ImageViewer.RenderTransform).ScaleX = 1;
					((ScaleTransform)this.ImageViewer.RenderTransform).ScaleY = 1;
				}
				((ScaleTransform)this.ImageViewer.RenderTransform).CenterX = e.GetPosition(relativeTo: this.ImageViewer).X;
				((ScaleTransform)this.ImageViewer.RenderTransform).CenterY = e.GetPosition(relativeTo: this.ImageViewer).Y;
			}
			else
			{
				if (((ScaleTransform)this.ImageViewer.RenderTransform).ScaleX > 1)
					this.ImageViewer.Cursor = Cursors.SizeAll;
				this.prevX = e.GetPosition(relativeTo: this).X;
				this.prevY = e.GetPosition(relativeTo: this).Y;
			}
		}
		private void fillTree(String fullPath, DirItem parent)
		{
			try
			{
				String[] dirs = Directory.GetDirectories(fullPath);
				foreach (String dir in dirs)
				{
					DirItem DI = new DirItem(System.IO.Path.GetFileName(dir), dir);
					try
					{
						if (Directory.GetDirectories(dir).Length != 0)
							DI.Nodes.Add(new DirItem("", null));
					}
					catch { }
					parent.Nodes.Add(DI);
				}
			}
			catch { }
		}

		public async Task LoadFolder(string folderName, CancellationToken CT)
		{
			this.StatusText.Text = "Загрузка изображений...";
			ObservableCollection<ImageBlock> TMP = new ObservableCollection<ImageBlock>();
			this.ImageList.ItemsSource = TMP;
			String[] extensions = { "*.jpg", "*.png", "*.jpeg", "*.bmp", "*.gif", "*.tiff", "*.ico" };
			List<String> images = new List<String>();
			foreach (String ext in extensions)
				images = images.Concat(Directory.GetFiles(folderName, ext).ToList()).ToList();
			int i = 0;
			int count = images.Count;
			foreach (String path in images)
			{
				CT.ThrowIfCancellationRequested();
				ImageSource IS;
				try
				{
					IS = await LoadImage(path);
				}
				catch { continue; }
				TMP.Add(new ImageBlock(IS, System.IO.Path.GetFileName(path), path, i, (((BitmapImage)IS).PixelHeight < 130) ? "None" : "Uniform"));
				this.StatusText.Text = String.Format("Загрузка изображения {0} ({1} из {2}) ...", System.IO.Path.GetFileName(path), ++i, count);
			}
			this.StatusText.Text = "Готово. Загружено " + i + " изображений из " + count + " (" + folderName + ")";
			if (count > 0)
				this.MenuSlideShow.IsEnabled = true;
			else
				this.MenuSlideShow.IsEnabled = false;
		}

		private Task<BitmapImage> LoadImage(String path)
		{
			return Task.Run(() =>
			{
				BitmapImage BI = new BitmapImage(new Uri(path));
				int height = BI.PixelHeight;
				BI = new BitmapImage();
				using (FileStream sr = new FileStream(path, FileMode.Open, FileAccess.Read))
				{
					BI.BeginInit();
					BI.CacheOption = BitmapCacheOption.OnLoad;
					BI.StreamSource = sr;
					if (height > 130)
						BI.DecodePixelHeight = 130;
					BI.EndInit();
					BI.Freeze();
				}
				return BI;
			});
		}

		private void ImageList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			KeyValuePair<String, int> tmp = (KeyValuePair<String, int>)((Button)sender).Tag;
			this.ImageViewer.Source = new BitmapImage(new Uri(tmp.Key));
			this.ImageList.SelectedIndex = tmp.Value;
			if (this.WrapViewer.ActualWidth < ((BitmapImage)this.ImageViewer.Source).PixelWidth || this.WrapViewer.ActualHeight < ((BitmapImage)this.ImageViewer.Source).PixelHeight)
				this.ImageViewer.Stretch = Stretch.Uniform;
			else
				this.ImageViewer.Stretch = Stretch.None;
			this.MenuImg.IsEnabled = true;
			((ScaleTransform)this.ImageViewer.RenderTransform).ScaleX = 1;
			((ScaleTransform)this.ImageViewer.RenderTransform).ScaleY = 1;
		}

		private TreeViewItem SearchNode(ItemsControl TV, Object item)
		{
			TreeViewItem TVI;
			TVI = TV.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem;
			if (TVI != null)
				return TVI;
			foreach (Object tmpItem in TV.Items)
			{
				TreeViewItem IVT = TV.ItemContainerGenerator.ContainerFromItem(tmpItem) as TreeViewItem;
				if (IVT != null)
					TVI = this.SearchNode(IVT, item);
				if (TVI != null)
					return TVI;
			}
			return null;
		}

		private async void Button_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			Button btn = null;
			DirItem DI = null;
			if (sender is Button)
			{
				btn = (Button)sender;
				DI = (DirItem)btn.Tag;
			}
			else if (sender is DirItem)
				DI = (DirItem)sender;
			TreeViewItem TVI = this.SearchNode(this.folders, DI);
			TVI.IsSelected = true;
			if (TVI.Items.Count != 0 & btn != null)
				TVI.IsExpanded = !TVI.IsExpanded;
			if (DI.fullPath == this.prevPath)
				return;
			this.prevPath = DI.fullPath;
			DI.Nodes.Clear();
			this.fillTree(DI.fullPath, DI);
			if (CTS != null)
				CTS.Cancel();
			try
			{
				CTS = new CancellationTokenSource();
				await this.LoadFolder(DI.fullPath, CTS.Token);
			}
			catch (OperationCanceledException) { }
			catch (Exception a) { MessageBox.Show(a.Message); }
		}

		private void folders_Expanded(object sender, RoutedEventArgs e)
		{
			TreeViewItem tmp = (TreeViewItem)e.OriginalSource;
			DirItem DI = (DirItem)tmp.Header;
			this.Button_MouseDoubleClick(DI, null);
		}

		private void RotateImg(object sender, RoutedEventArgs e)
		{
			MenuItem IMG = (MenuItem)sender;
			int Angle = Int32.Parse((String)IMG.Tag);
			if (this.ImageViewer.Source == null)
				return;
			TransformedBitmap TB = new TransformedBitmap();
			TB.BeginInit();
			if (this.ImageViewer.Source is BitmapImage)
				TB.Source = (BitmapImage)this.ImageViewer.Source;
			else if (this.ImageViewer.Source is TransformedBitmap)
				TB.Source = (TransformedBitmap)this.ImageViewer.Source;
			else if (this.ImageViewer.Source is FormatConvertedBitmap)
				TB.Source = (FormatConvertedBitmap)this.ImageViewer.Source;
			TB.Transform = new RotateTransform(Angle);
			TB.EndInit();
			this.ImageViewer.Source = TB;
			((ScaleTransform)this.ImageViewer.RenderTransform).ScaleX = 1;
			((ScaleTransform)this.ImageViewer.RenderTransform).ScaleY = 1;
		}

		private void ToGray(object sender, RoutedEventArgs e)
		{
			FormatConvertedBitmap FCB = new FormatConvertedBitmap();
			FCB.BeginInit();
			if (this.ImageViewer.Source is BitmapImage)
				FCB.Source = (BitmapImage)this.ImageViewer.Source;
			else if (this.ImageViewer.Source is TransformedBitmap)
				FCB.Source = (TransformedBitmap)this.ImageViewer.Source;
			else if (this.ImageViewer.Source is FormatConvertedBitmap)
				FCB.Source = (FormatConvertedBitmap)this.ImageViewer.Source;
			FCB.DestinationFormat = PixelFormats.Gray32Float;
			FCB.EndInit();
			this.ImageViewer.Source = FCB;
		}

		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			if ((Key.RightCtrl & Key.D0) == e.Key || (Key.LeftCtrl & Key.D0) == e.Key)
			{
				((ScaleTransform)this.ImageViewer.RenderTransform).ScaleX = 1;
				((ScaleTransform)this.ImageViewer.RenderTransform).ScaleY = 1;
			}
			if (Key.OemPlus == e.Key)
			{
				if (((ScaleTransform)this.ImageViewer.RenderTransform).ScaleX < 8)
				{
					((ScaleTransform)this.ImageViewer.RenderTransform).CenterX = this.ImageViewer.ActualWidth / 2;
					((ScaleTransform)this.ImageViewer.RenderTransform).CenterY = this.ImageViewer.ActualHeight / 2;
					((ScaleTransform)this.ImageViewer.RenderTransform).ScaleX += 0.05;
					((ScaleTransform)this.ImageViewer.RenderTransform).ScaleY += 0.05;
				}
			}
			if (Key.OemMinus == e.Key && ((ScaleTransform)this.ImageViewer.RenderTransform).ScaleX > 1)
			{
				((ScaleTransform)this.ImageViewer.RenderTransform).ScaleX -= 0.05;
				((ScaleTransform)this.ImageViewer.RenderTransform).ScaleY -= 0.05;
			}
		}

		private void MenuSlideShow_Click(object sender, RoutedEventArgs e)
		{
			SlideShow SS = new SlideShow(this.ImageList.Items);
			SS.Show();
		}

		private void MenuOpen(object sender, RoutedEventArgs e)
		{
			OpenFileDialog OFD = new OpenFileDialog();
			OFD.ShowDialog();
			this.ImageViewer.Source = new BitmapImage(new Uri(OFD.FileName));
			if (this.WrapViewer.ActualWidth < ((BitmapImage)this.ImageViewer.Source).PixelWidth || this.WrapViewer.ActualHeight < ((BitmapImage)this.ImageViewer.Source).PixelHeight)
				this.ImageViewer.Stretch = Stretch.Uniform;
			else
				this.ImageViewer.Stretch = Stretch.None;
			((ScaleTransform)this.ImageViewer.RenderTransform).ScaleX = 1;
			((ScaleTransform)this.ImageViewer.RenderTransform).ScaleY = 1;
		}

		private void MenuClearImageViewer(object sendet, RoutedEventArgs e)
		{
			this.ImageViewer.Source = null;
			((ScaleTransform)this.ImageViewer.RenderTransform).ScaleX = 1;
			((ScaleTransform)this.ImageViewer.RenderTransform).ScaleY = 1;
		}
	}

	public class ImageBlock
	{
		public ImageSource Source { get; set; }
		public String Name { get; set; }
		public KeyValuePair<String, int> Info { get; set; }
		public String Stretching { get; set; }
		public ImageBlock(ImageSource source, String name, String path, int index, String Stretching)
		{
			this.Source = source;
			this.Name = name;
			this.Info = new KeyValuePair<String, int>(path, index);
			this.Stretching = Stretching;
		}
	}

	class DirItem
	{
		public String fileName { get; set; }
		public String fullPath { get; set; }

		public DirItem Self { get; set; }

		private ObservableCollection<DirItem> nodes = new ObservableCollection<DirItem>();

		public ObservableCollection<DirItem> Nodes
		{
			get
			{
				return this.nodes;
			}
			set { this.nodes = value; }
		}

		public String ImageName
		{
			get
			{
				return @"Resources/koala.jpg";
			}
		}

		public DirItem(String fileName, String fullPath)
		{
			this.fileName = fileName;
			this.fullPath = fullPath;
			this.Self = this;
		}
	}
}
