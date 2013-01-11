using System;
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
using System.Windows.Shapes;
using System.ComponentModel;
using System.Windows.Media.Animation;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public static int popcounter = 0;
        public Window1()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Left = (SystemParameters.VirtualScreenWidth / 2) - this.Width;
            //MessageBox.Show(Convert.ToString(SystemParameters.VirtualScreenWidth));
            //this.Left = 0;
            this.Top = popcounter;
            //this.Height = SystemParameters.VirtualScreenHeight;

            popcounter += Convert.ToInt32(this.Height) - 90;
        }
        private bool closeStoryBoardCompleted = false;

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (!closeStoryBoardCompleted)
            {
                //MessageBox.Show("triggered");
                closeStoryBoard.Begin();
                e.Cancel = true;
            }
        }

        private void closeStoryBoard_Completed_1(object sender, EventArgs e)
        {
            closeStoryBoardCompleted = true;
            this.Close();
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }

        private void poly_MouseEnter(object sender, MouseEventArgs e)
        {
            set_Big(this);
            this.poly.Fill.Opacity = 0.9;
        }

        private void poly_MouseLeave(object sender, MouseEventArgs e)
        {
            set_Small(this);
            this.poly.Fill.Opacity = 0.7;
        }

        private void poly_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
        private void set_Small(object sender)
        {
            //20,0 400,0 420,20 420,40 440,40 420,60 420,100 20,100 20,60
            this.poly.Points = new PointCollection() { new Point(320, 100), new Point(320, 0), new Point(400, 0), new Point(420, 20), new Point(420, 40), new Point(440, 40), new Point(420, 60), new Point(420, 100) };
            this.pic.Margin = new Thickness(10, 10, -110, -10);
            this.label1.Opacity = 0;
            this.label2.Opacity = 0;
        }
        private void set_Big(object sender)
        {
            this.poly.Points = new PointCollection() { new Point(20, 0), new Point(400, 0), new Point(420, 20), new Point(420, 40), new Point(440, 40), new Point(420, 60), new Point(420, 100), new Point(20, 100), new Point(20, 60) };
            this.pic.Margin = new Thickness(-290, 10, 208, -10);
            this.label1.Opacity = 1;
            this.label2.Opacity = 1;
        }

        private void label1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Window2 send = new Window2();
            send.Show();
        }
    }
}
