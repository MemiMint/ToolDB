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

namespace ToolDB
{
    /// <summary>
    /// Lógica de interacción para Comment.xaml
    /// </summary>
    public partial class Comment : UserControl
    {
        private double firstXpos, firstYpos, firstArrowXpos, firstArrowYpos;
        private object MovingObject;

        public Comment()
        {
            InitializeComponent();
        }

        private Visibility buttonState(Grid dockPanel)
        {
            return dockPanel.Visibility == Visibility.Hidden ? dockPanel.Visibility = Visibility.Visible : dockPanel.Visibility = Visibility.Hidden;
        }

        private void LblComment_MouseLeave(object sender, MouseEventArgs e)
        {
        }

        private void BtnEditComment_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new CommentName(this).ShowDialog();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ((Canvas)Parent).Children.Remove(this);
        }

        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            firstXpos = e.GetPosition(sender as Control).X;
            firstYpos = e.GetPosition(sender as Control).Y;
            firstArrowXpos = e.GetPosition((sender as Control).Parent as Control).X - firstXpos;
            firstArrowYpos = e.GetPosition((sender as Control).Parent as Control).Y - firstYpos;

            MovingObject = sender;
        }

        private void UserControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (MovingObject != null)
                {
                    (MovingObject as FrameworkElement).SetValue(Canvas.LeftProperty, e.GetPosition((MovingObject as FrameworkElement).Parent as FrameworkElement).X - firstXpos);
                    (MovingObject as FrameworkElement).SetValue(Canvas.TopProperty, e.GetPosition((MovingObject as FrameworkElement).Parent as FrameworkElement).Y - firstYpos);
                }

                else
                {
                    MovingObject = null;
                }
            }
        }
    }
}
