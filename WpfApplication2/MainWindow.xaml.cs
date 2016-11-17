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

namespace WpfApplication2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private MainWindow rootElement;
		public MainWindow()
		{
			this.rootElement = this;
			this.DataContext = this;
			InitializeComponent();
		}

		private void Bordertwo_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			rootElement.Content = new Window1(rootElement).Content;
		}
		public MainWindow(MainWindow rootElement)
		{
			this.rootElement = rootElement;
			InitializeComponent();
			this.DataContext = this;


		}
	}
}
