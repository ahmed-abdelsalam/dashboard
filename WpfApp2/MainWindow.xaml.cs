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
        int cellindex = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        public static T FindChild<T>(DependencyObject parent, string childName)
   where T : DependencyObject
        {
            // Confirm parent and childName are valid. 
            if (parent == null) return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                // If the child is not of the request child type child
                T childType = child as T;
                if (childType == null)
                {
                    // recursively drill down the tree
                    foundChild = FindChild<T>(child, childName);

                    // If the child is found, break so we do not overwrite the found child. 
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    // If the child's name is set for search
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        // if the child's name is of the request name
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    // child element found.
                    foundChild = (T)child;
                    break;
                }
            }

            return foundChild;
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cellindex == 3)
                cellindex = 0;
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
                
                WebBrowser ie = new WebBrowser();
                ie.Margin= new Thickness(2, 2, 2, 2);
                ie.Name = "w" + (dashboard.RowDefinitions.Count).ToString()+(cellindex+1);
                ie.Navigate("http://google.com");
                Grid.SetRow(ie, (dashboard.RowDefinitions.Count-1));
                Grid.SetColumn(ie, cellindex);
                dashboard.Children.Add(ie);
                cellindex++;
            }
        }


        private void url_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var name = "w" + index.Text.ToString();
                WebBrowser web = FindChild<WebBrowser>(Application.Current.MainWindow, name);
               // WebBrowser web = (WebBrowser)dashboard.FindName(name);
                web.Navigate(url.Text.ToString());

            }
        }

        private void TextBox_TouchEnter(object sender, TouchEventArgs e)
        {

        }
    }
}
