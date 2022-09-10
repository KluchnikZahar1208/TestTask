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
using TestTask.Model;
using ScottPlot;
using System.Data;

namespace TestTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int COUNTDAYS = 30;
        List<Root> roots = new List<Root>();
        List<PersonInfo> personsInfo = new List<PersonInfo>();
        List<List<double>> steps = new List<List<double>>();
        public MainWindow()
        {
            InitializeComponent();
            
            for(int i = 1; i <= COUNTDAYS; i++)
            {
                var path = $"E:\\Универ\\TestTask\\TestTask\\day{i}.json";
                var json = File.ReadAllText(path);
                roots = JsonConvert.DeserializeObject<List<Root>>(json);
                
                foreach(var root in roots)
                {
                    PersonInfo person = new PersonInfo(root.User, root.Steps);

                    if (!personsInfo.Exists(x => x.Name == root.User))
                    {
                        personsInfo.Add(person);
                        steps.Add(new List<double>());
                        
                    }
                    else
                    {
                        personsInfo[personsInfo.FindIndex(x => x.Name==root.User)].AvgSteps += root.Steps;
                        if (personsInfo[personsInfo.FindIndex(x => x.Name == root.User)].MaxCountSteps < root.Steps)
                        {
                            personsInfo[personsInfo.FindIndex(x => x.Name == root.User)].MaxCountSteps = root.Steps;
                        }
                        if (personsInfo[personsInfo.FindIndex(x => x.Name == root.User)].MinCountSteps > root.Steps)
                        {
                            personsInfo[personsInfo.FindIndex(x => x.Name == root.User)].MinCountSteps = root.Steps;
                        }
                    }
                    steps[personsInfo.FindIndex(x => x.Name == root.User)].Add(root.Steps);
                }
                    
                
            }
            for (int i = 0; i < personsInfo.Count; i++)
            {
                personsInfo[i].AvgSteps /= steps[i].Count;
            }
            
            dgUsers.ItemsSource = personsInfo;
            
            
        }

        private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<double> listDays = new List<double>();
            for (int i = 1; i <= steps[dgUsers.SelectedIndex].Count; i++)
            {
                listDays.Add(i);
            }
            WpfPlot1.Plot.Clear();
            double[] days = listDays.ToArray();
            double[] step = steps[dgUsers.SelectedIndex].ToArray();

            WpfPlot1.Plot.AddScatterLines(days, step);
            WpfPlot1.Refresh();

        }

        private void dgUsers_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            
            PersonInfo product = (PersonInfo)e.Row.DataContext;

            if (product.AvgSteps * 1.2 < product.MaxCountSteps || product.AvgSteps * 0.8 > product.MinCountSteps)
                e.Row.Background = new SolidColorBrush(Colors.Orange);
            else
                e.Row.Background = new SolidColorBrush(Colors.White);
        }

        private void CovertJSON_Click(object sender, RoutedEventArgs e)
        {
            PersonInfo personInfo = (PersonInfo)dgUsers.SelectedItem;
            InfoJSON infoJSON = new InfoJSON(personInfo.Name.ToString(), dgUsers.SelectedIndex.ToString(), roots[roots.FindIndex(x => x.User == personInfo.Name)].Status, personInfo.AvgSteps, personInfo.MaxCountSteps, personInfo.MinCountSteps);
            MessageBox.Show(infoJSON.ToJSON());
            //MessageBox.Show(dgUsers.SelectedIndex.ToString());
            //MessageBox.Show(roots[roots.FindIndex(x => x.User == personInfo.Name)].Status);

        }
    }
   
}
