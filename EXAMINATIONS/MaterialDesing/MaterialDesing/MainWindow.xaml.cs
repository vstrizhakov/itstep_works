using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using MaterialDesignColors.WpfExample.Domain;
using MaterialDesignThemes.Wpf;

namespace MaterialDesing
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BackgroundWorker worker = new BackgroundWorker();
        delegate void UpdateProgressBarDelegate(DependencyProperty dp, object value);

        private ItemsList[] ListItems = new ItemsList[]
        {
            new ItemsList("LOL1", 52), new ItemsList("LOL2", 485),  new ItemsList("LOL3", 99)
        };

        public MainWindow()
        {
            InitializeComponent();
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            DemoItemsListBox.ItemsSource = ListItems;
            
            //this.BBB.Background =  new SolidColorBrush(Color.FromArgb(255,255,234,0));
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            CopyFiles();
        }
       
        private void CopyFiles()
        {
            UpdateProgressBarDelegate updProgress = new UpdateProgressBarDelegate(Progress.SetValue);
            UpdateProgressBarDelegate updProgress2 = new UpdateProgressBarDelegate(Progress2.SetValue);

            double value = 0;
            double value2 = 0;
            for (int i = 0; i<100; i++)
            {
                Dispatcher.Invoke(updProgress, new object[] { ProgressBar.ValueProperty, ++value });
                Dispatcher.Invoke(updProgress2, new object[] { ProgressBar.ValueProperty, ++value2 });
                Thread.Sleep(50);
            }
        }

        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            Progress.Value = 0;
            Progress2.Value = 0;
            worker.RunWorkerAsync();
        }
        
        //////////////
       
        private void Button_ClickMe(object sender, RoutedEventArgs e)
        {
            if (CountingBadge.Badge == null || Equals(CountingBadge.Badge, ""))
                CountingBadge.Badge = 0;

            var next = int.Parse(CountingBadge.Badge.ToString()) + 1;

            CountingBadge.Badge = next < 21 ? (object)next : null;
        }

        private void PopupBox_OnOpened(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Just making sure the popup has opened.");
        }

        private void PopupBox_OnClosed(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Just making sure the popup has closed.");
        }
        private void Flipper_OnIsFlippedChanged(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            System.Diagnostics.Debug.WriteLine("Card is flipped = " + e.NewValue);
        }
        private void Sample1_DialogHost_OnDialogClosing(object sender, DialogClosingEventArgs eventArgs)
        {
            Console.WriteLine("SAMPLE 1: Closing dialog with parameter: " + (eventArgs.Parameter ?? ""));

            if (!Equals(eventArgs.Parameter, true)) return;

            if (!string.IsNullOrWhiteSpace(FruitTextBox.Text))
                FruitListBox.Items.Add(FruitTextBox.Text.Trim());
        }



        private void Sample2_DialogHost_OnDialogClosing(object sender, DialogClosingEventArgs eventArgs)
        {
            Console.WriteLine("SAMPLE 2: Closing dialog with parameter: " + (eventArgs.Parameter ?? ""));
        }
        public ICommand SaveComand { get; }

        /////
        private void SnackBar3_OnClick(object sender, RoutedEventArgs e)
        {
            // используйте очередь сообщений для отправки сообщения.
            var messageQueue = SnackbarThree.MessageQueue;
            var message = MessageTextBox.Text;

            // очередь сообщений можно вызывать из любого потока
            Task.Factory.StartNew(() => messageQueue.Enqueue(message));
        }
        //
        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //until we had a StaysOpen glag to Drawer, this will help with scroll bars
            var dependencyObject = Mouse.Captured as DependencyObject;
            //while (dependencyObject != null)
            //{
            //    if (dependencyObject is ScrollBar) return;
            //    dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            //}

            Console.WriteLine();

            MenuToggleButton.IsChecked = false;
        }

        private async void MenuPopupButton_OnClick(object sender, RoutedEventArgs e)
        {
            var sampleMessageDialog = new SampleMessageDialog
            {
                Message = { Text = ((ButtonBase)sender).Content.ToString() }
            };
            await DialogHost.Show(sampleMessageDialog, "RootDialog");
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            SampleDialog sampleMessageDialog = new SampleDialog();
            object result = await DialogHost.Show(sampleMessageDialog, "RootDialog");
            if(result is bool)
            {
                Console.WriteLine(result.ToString());
                if ((bool)result)
                    TextBox_singleLine.Text = $"Имя: {sampleMessageDialog.TextBox_Name.Text},  Фамилия: {sampleMessageDialog.TextBox_LastName.Text}";
            }
           
        }

        private void Button_Click_1()
        {

        }
    }
    class ItemsList
    {
        public string Name { set; get; }
       public int price { set; get; }
        public ItemsList(string Name, int price)
        {
            this.Name = Name;
            this.price = price;
        }
    }
}