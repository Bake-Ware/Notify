using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Windows.Media.Animation;
using System.Windows.Interop;


namespace WpfApplication1
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window1 pop = new Window1();
            pop.Show();
            
            pop.label1.Content = this.textBox1.Text;
            pop.label2.Content = this.textBox2.Text;

            if (this.textBox3.Text.Length > 0)
            {
                var image = System.Drawing.Image.FromFile(this.textBox3.Text); // or wherever it comes from
                var bitmap = new System.Drawing.Bitmap(image);
                var bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(),
                                                                                      IntPtr.Zero,
                                                                                      Int32Rect.Empty,
                                                                                      BitmapSizeOptions.FromEmptyOptions()
                      );
                bitmap.Dispose();
                var brush = new ImageBrush(bitmapSource);

                pop.pic.Fill = brush;
            }
            else
                pop.pic.Fill.Opacity = 0;

        }
        public string filename;
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 

            dlg.DefaultExt = ".txt";

            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";



            // Display OpenFileDialog by calling ShowDialog method 

            Nullable<bool> result = dlg.ShowDialog();



            // Get the selected file name and display in a TextBox 

            if (result == true)
            {

                // Open document 

                string filename = dlg.FileName;

                textBox3.Text = filename;
                

            }


        }

    }
}
