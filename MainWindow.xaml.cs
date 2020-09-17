using Microsoft.Win32;
using System.Diagnostics;
using System.Windows;

namespace pjefixer
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var javaw = Process.GetProcessesByName("javaw");
            if (javaw.Length > 0)
            {
                javaw[0].Kill();
            }

            var pjeHKUSR = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("JavaSoft").OpenSubKey("Prefs").OpenSubKey("br").OpenSubKey("jus").OpenSubKey("cnj", true);
            if (pjeHKUSR != null)
            {
                    if (pjeHKUSR.OpenSubKey("pje") != null)
                    {
                        pjeHKUSR.DeleteSubKeyTree("pje");
                    }
            }

            label.Content = "Arrumado";
        }
    }
}
