using System;
using System.ComponentModel;
using System.Diagnostics;
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

namespace Odepax.BigNotif
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			var random = new Random();

			Background = new SolidColorBrush(Color.FromRgb(
				(byte)random.Next(150),
				(byte)random.Next(150),
				(byte)random.Next(150)
			));

			TimeText.Text = "It's " + DateTime.Now.ToShortTimeString();

			string[] args = Environment.GetCommandLineArgs();

			if (args.Length == 3 && args[1].Equals("-Message"))
			{
				MessageText.Text = args[2];
			}
			else if (args.Length == 2)
			{
				MessageText.Text = args[1];
			}
		}

		private void GithubLinkText_MouseUp(object sender, MouseButtonEventArgs e)
		{
			try
			{
				Process.Start("https://github.com/Odepax/big-notif");

				Application.Current.Shutdown(0);
			}
			catch
			{
				GithubLinkText.Text = "Unable to open browser, copy this link instead:";

				Topmost = false;
			}
		}
	}
}
