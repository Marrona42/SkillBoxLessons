using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace SkillboxCSharpHW9
{
    public partial class MainWindow : Window
    {
        ObservableCollection<string> data = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();
            ListBox.ItemsSource = data;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            string[] splitText;
            string firstText = TextBox1.Text;
            splitText = firstText.Split(new char[] { });
            for (int i = 0;i < splitText.Length; i++)
            {
                data.Add(splitText[i]);
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            string dataX;
            string[] splitText;
            string firstText = TextBox2.Text;
            splitText = firstText.Split(new char[] { });
            Array.Reverse(splitText);
            dataX = string.Join(" ", splitText);
            Label.Content = dataX;
        }
    }
}
