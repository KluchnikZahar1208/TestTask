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
using System.Text.Json;
using System.IO;
using static TestTask.Model.User;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;

namespace TestTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnReadJSON_Click(object sender, RoutedEventArgs e)
        {
            var path = @"E:\Универ\TestTask\TestTask\day1.json";
            var json = File.ReadAllText(path);
            //Root root = JsonConvert.DeserializeObject<Root>(json);
            List<Root> roots = JsonConvert.DeserializeObject<List<Root>>(json);
            foreach(Root root in roots)
            {
                MessageBox.Show(root.User);
            }
            
        }
        private void read
    }
}
