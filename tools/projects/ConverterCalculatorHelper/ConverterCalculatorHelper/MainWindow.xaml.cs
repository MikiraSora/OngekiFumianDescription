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

namespace ConverterCalculatorHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region DPs

        public string InputText
        {
            get { return (string)GetValue(InputTextProperty); }
            set { SetValue(InputTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InputText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InputTextProperty =
            DependencyProperty.Register("InputText", typeof(string), typeof(MainWindow), new PropertyMetadata("10 50"));

        public float Bpm
        {
            get { return (float)GetValue(BpmProperty); }
            set { SetValue(BpmProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Bpm.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BpmProperty =
            DependencyProperty.Register("Bpm", typeof(float), typeof(MainWindow), new PropertyMetadata(240f));

        public int ResT
        {
            get { return (int)GetValue(ResTProperty); }
            set { SetValue(ResTProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ResT.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ResTProperty =
            DependencyProperty.Register("ResT", typeof(int), typeof(MainWindow), new PropertyMetadata(1920));

        public string OutputText
        {
            get { return (string)GetValue(OutputTextProperty); }
            set { SetValue(OutputTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OutputText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OutputTextProperty =
            DependencyProperty.Register("OutputText", typeof(string), typeof(MainWindow), new PropertyMetadata(""));

        public int ConvertTarget
        {
            get { return (int)GetValue(ConvertTargetProperty); }
            set { SetValue(ConvertTargetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ConvertTarget.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ConvertTargetProperty =
            DependencyProperty.Register("ConvertTarget", typeof(int), typeof(MainWindow), new PropertyMetadata(0));

        #endregion

        public MainWindow()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var output = string.Join(Environment.NewLine, (InputText ?? "").Split("\n").Select(x => ConvertTarget == 1 ? ProcessLineToMsec(x) : ProcessLineToUnitGrid(x)).OfType<string>());

            OutputText = output;
        }

        private string ProcessLineToUnitGrid(string line)
        {
            if (!float.TryParse(line, out var msec))
                return "N/A";

            var T = msec * (ResT * Bpm) / 240000.0f;
            var unit = T / ResT;

            return "0";
        }

        private string ProcessLineToMsec(string line)
        {
            var data = line.Split(line.FirstOrDefault(x => !(char.IsDigit(x) || x == '.'))).OfType<string>().Select(x => x.Trim()).ToArray();
            if (data.Length != 2)
                return "N/A";

            var unit = int.Parse(data[0]);
            var grid = int.Parse(data[1]);

            var T = (ulong)(unit * ResT + grid);

            var msec = 240000 * T / (ResT * Bpm);

            return msec.ToString();
        }
    }
}
