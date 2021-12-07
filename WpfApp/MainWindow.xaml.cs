using Models;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();

        }

        public ObservableCollection<Person> Items = new ObservableCollection<Person>();

        static IAsyncService<Person> Service { get; set; } = new Service<Person>(new JsonDataProvider<Person>(
             System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "database.txt")
             ));

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
                var items = await Service.ReadAsync();
                foreach (var item in items)
                {

                    Items.Add(item);
                }
        }
    }
}
