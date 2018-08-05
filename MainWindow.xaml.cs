using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Odepax.BigNotif
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			InitializeRandomBackground();
			InitializeCurrentTimeDisplay();
			InitializeNotificationMessageDisplay();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void InitializeRandomBackground()
		{
			var random = new Random();

			Background = new SolidColorBrush(Color.FromRgb(
				(byte)random.Next(150),
				(byte)random.Next(150),
				(byte)random.Next(150)
			));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void InitializeCurrentTimeDisplay()
		{
			TimeTextBlock.Text = "It's " + DateTime.Now.ToShortTimeString();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void InitializeNotificationMessageDisplay()
		{
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

		private void OpenGithubRepo(object sender, MouseButtonEventArgs e)
		{
			try
			{
				// Opens the browser.
				Process.Start("https://github.com/Odepax/big-notif");

				Application.Current.Shutdown(0);
			}
			catch
			{
				GithubLinkTextBlock.Text = "Unable to open browser, copy this link instead:";

				Topmost = false;
			}
		}

		private void CloseApplication(object sender, MouseButtonEventArgs e)
		{
			Application.Current.Shutdown(0);
		}
	}
}
