using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Store_Management.Utils
{
    public class Notification
    {

        public static void Notify(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButton.OK);   
        }
    }
}
