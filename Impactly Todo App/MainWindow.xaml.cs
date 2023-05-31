using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Drawing;
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

namespace Impactly_Todo_App
{
    public partial class MainWindow : Window
    {
        List<Todo> Todos = new List<Todo>();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            Todo testtodo = new Todo("Ongoing", "Clean locker");
            Todo testtodo1 = new Todo("Not Started", "Wash the floor");

            Todos.Add(testtodo);
            Todos.Add(testtodo1);

            Menu.ItemsSource = Todos;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Todos.Add(new Todo(StatusTxt.Text, Convert.ToString(DesTxt.Text)));
                Menu.Items.Refresh();
            }
            catch
            {
                MessageBox.Show("Der sket en fejl", "Error", MessageBoxButton.OK);
            }
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter skriv = new StreamWriter(@"C:\Users\rasm50m1\OneDrive - AspIT\S\S3\todoapp\todoliste\Todo.txt");
            foreach (Todo pz in Todos)
            {
                skriv.WriteLine($"{pz.Status}.{pz.Description}");
            }

        }

        private void openBtn_Click(object sender, RoutedEventArgs e)
        {

            using (StreamReader reader = new StreamReader(@"C:\Users\rasm50m1\OneDrive - AspIT\S\S3\todoapp\todoliste\Todo.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string[] todoString = reader.ReadLine().Split('.');
                    Todos.Add(new Todo((todoString[0]), todoString[1]));

                }

            }
        }
    }
}
