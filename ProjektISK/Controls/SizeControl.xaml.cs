using System.Windows;
using System.Windows.Controls;

namespace ProjektISK.Controls
{
    public partial class SizeControl
    {
        public static readonly DependencyProperty WatermarkDependencyProperty =
            DependencyProperty.Register("Watermark", typeof(string), typeof(SizeControl), new FrameworkPropertyMetadata(null));

        public SizeControl()
        {
            InitializeComponent();
        }

        public string Watermark
        {
            get => (string)GetValue(WatermarkDependencyProperty);
            set => SetValue(WatermarkDependencyProperty, value);
        }
    }
}
