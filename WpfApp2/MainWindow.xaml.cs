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

namespace WpfApp2
{
    using System.Windows.Media;


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int cellindex = 1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cellindex == 3)
                cellindex = 1;
            GridLength heigh = new GridLength(290);
            RowDefinition newrow = new RowDefinition();
            newrow.Height = heigh;
            dashboard.RowDefinitions.Add(newrow);



            GridSplitter gs = new GridSplitter();
            gs.VerticalAlignment =System.Windows.VerticalAlignment.Bottom;
            gs.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            gs.Height = 8;
            gs.ResizeDirection = System.Windows.Controls.GridResizeDirection.Rows;
            gs.BorderThickness= new Thickness(3);
            gs.BorderBrush = new SolidColorBrush(Colors.Black);
            Grid.SetRow(gs, (dashboard.RowDefinitions.Count-1));
            Grid.SetColumnSpan(gs, 20);
            dashboard.Children.Add(gs);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            if (cellindex == 3)
                MessageBox.Show("Please add new row ", "yes");
            else
            {
                Rectangle ie = new Rectangle();
                ie.Fill = new SolidColorBrush(Colors.Blue);
                //WebBrowser ie = new WebBrowser();
                ie.Margin= new Thickness(2, 2, 2, 2);
                Grid.SetRow(ie, (dashboard.RowDefinitions.Count-1));
                Grid.SetColumn(ie, cellindex);
                dashboard.Children.Add(ie);
                cellindex++;
            }
        }
    }
}
