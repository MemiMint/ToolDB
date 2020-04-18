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
using System.Windows.Shapes;

namespace ToolDB
{
    /// <summary>
    /// Lógica de interacción para CommentName.xaml
    /// </summary>
    public partial class CommentName : Window
    {
        private Comment Comment;

        public CommentName(Comment comment)
        {
            InitializeComponent();
            Comment = comment;
        }

        private void BtnEditComment_Click(object sender, RoutedEventArgs e)
        {
            if (txtEditComment.Text == string.Empty)
            {
                new WarningModal("Empty fields are not allowed").ShowDialog();
            }

            else
            {
                Comment.lblComment.Text = "//" + txtEditComment.Text;
                Close();
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
