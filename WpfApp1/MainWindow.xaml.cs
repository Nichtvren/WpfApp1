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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        Book book;
        int chap;
        int page;
        public MainWindow()
        {
            InitializeComponent();
            book = App.book;
            HomeScreen(new object(), new RoutedEventArgs());
        }

        public void ClearScreen()
        {
            NavBar.Children.Clear();
            NavBar.ColumnDefinitions.Clear();

            Layout.Children.Clear();
            Layout.ColumnDefinitions.Clear();
            Layout.RowDefinitions.Clear();
        }

        public void HomeScreen(object sender, RoutedEventArgs e)
        {
            ClearScreen();
            int size = (int)Math.Ceiling(Math.Sqrt(book.chapters.Count));

            Layout.HorizontalAlignment = HorizontalAlignment.Center;
            Layout.VerticalAlignment = VerticalAlignment.Center;

            for (int rows_cols = 0; rows_cols < size; rows_cols++)
            {
                Layout.ColumnDefinitions.Add(new ColumnDefinition());
                Layout.RowDefinitions.Add(new RowDefinition());
            }

            int x = 0, y = 0;
            for (int i = 0; i < book.chapters.Count; i++)
            {
                Button button = new Button();
                button.Content = book.chapters[i].name;
                button.Tag = i;
                button.Click += new RoutedEventHandler(ChapterScreen);
                Grid.SetColumn(button, x);
                Grid.SetRow(button, y);
                Layout.Children.Add(button);
                x++;
                if (x == size)
                {
                    x = 0;
                    y++;
                }
            }
        }


        public void ChapterScreen(object sender, RoutedEventArgs e)
        {
            ClearScreen();
            Button btn = sender as Button;
            chap = (int)btn.Tag;
            NavBar.HorizontalAlignment = HorizontalAlignment.Left;

            StackPanel sp = new StackPanel();
            NavBar.Children.Add(sp);

            for (int i = 0; i < book.chapters.Count; i++)
            {                
                Button button = new Button();
                button.Content = book.chapters[i].name;
                button.Tag = i;
                button.Click += new RoutedEventHandler(ChapterScreen);
                sp.Children.Add(button);
            }
            Layout.HorizontalAlignment = HorizontalAlignment.Center;
            Layout.VerticalAlignment = VerticalAlignment.Center;

            int size = (int)Math.Ceiling(Math.Sqrt(book.chapters[chap].pages.Count));
            for (int rows_cols = 0; rows_cols < size; rows_cols++)
            {
                Layout.ColumnDefinitions.Add(new ColumnDefinition());
                Layout.RowDefinitions.Add(new RowDefinition());
            }

            int x = 0, y = 0;
            for (int i = 0; i < book.chapters[chap].pages.Count; i++)
            {
                Button button = new Button();
                button.Content = book.chapters[chap].pages[i].name;
                button.Tag = i;
                button.Click += new RoutedEventHandler(PageScreen);
                Grid.SetColumn(button, x);
                Grid.SetRow(button, y);
                Layout.Children.Add(button);
                x++;
                if (x == size)
                {
                    x = 0;
                    y++;
                }
            }
        }
        
        public void PageScreen(object sender, RoutedEventArgs e)
        {
            ClearScreen();
            Button btn = sender as Button;
            page = (int)btn.Tag;
            NavBar.HorizontalAlignment = HorizontalAlignment.Left;

            StackPanel sp = new StackPanel();
            NavBar.Children.Add(sp);
            Button homeButton = new Button();
            homeButton.Content = "Home";
            
            homeButton.Click += new RoutedEventHandler(HomeScreen);
            sp.Children.Add(homeButton);

            Button chapButton = new Button();
            chapButton.Content = book.chapters[chap].name;
            chapButton.Tag = chap;
            chapButton.Click += new RoutedEventHandler(ChapterScreen);
            sp.Children.Add(chapButton);


            for (int i = 0; i < book.chapters[chap].pages.Count; i++)
            {
                Button button = new Button();
                button.Content = book.chapters[chap].pages[i].name;
                button.Tag = i;
                button.Click += new RoutedEventHandler(PageScreen);
                sp.Children.Add(button);
            }
            StackPanel pageLayoutStackPanel = new StackPanel();
            Layout.Children.Add(pageLayoutStackPanel);
            foreach (KeyValuePair<string, object> item in book.chapters[chap].pages[page].data)
            {
                if (true)
                {

                }
            }

    

        }
    }
}
