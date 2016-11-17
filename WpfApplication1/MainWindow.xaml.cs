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

namespace WpfApplication1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public String Text { get; set; }
		public double doubl { get; set; }

		public MainWindow()
		{
			InitializeComponent();
			doubl = 4.3;
			this.DataContext = this;
			doubl = 5.6;
			this.Text = "asd";
			doubl = 124.14;

		}

		private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			doubl = 124.14;
			InitializeComponent();

		}

		private void button_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			doubl = 43.26;
			InitializeComponent();
		}
	}
}
