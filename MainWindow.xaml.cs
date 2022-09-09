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
            List<Root> roots = new List<Root>();
            List<PersonInfo> personsInfo = new List<PersonInfo>();
            var steps = new List<List<int>>();
            //users.Add(new List<int>());
            //users[0].Add(0);
            for(int i = 1; i <= 30; i++)
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
                        steps.Add(new List<int>());
                        
                    }
                    else
                    {
                        personsInfo[personsInfo.FindIndex(x => x.Name==root.User)].AvgSteps += root.Steps;
                    }
                    steps[personsInfo.FindIndex(x => x.Name == root.User)].Add(root.Steps);
                }
                    
                
            }
            for (int i = 0; i < personsInfo.Count; i++)
            {
                personsInfo[i].AvgSteps /= steps[i].Count;
                MessageBox.Show(String.Join(", ", steps[i]));
            }
            
            dgUsers.ItemsSource = personsInfo;

        }

       
    }
}
