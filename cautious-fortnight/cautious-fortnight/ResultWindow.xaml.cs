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

namespace cautious_fortnight
{
    /// <summary>
    /// Interaction logic for ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
        public event EventHandler<ResultEventArgs> ResultEvent;
        public ResultWindow()
        {
            InitializeComponent();
        }
    }

    public class ResultEventArgs : EventArgs
    {
        private string args;
        public ResultEventArgs(string result)
        {
            args = result;
        }
        public string EventData
        {
            get { return args; }
        }
    }
}
