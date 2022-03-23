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

namespace WpfLab6_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public enum WeatherEnum
        {
            sun, rain, clouds, snow
        }

        public class WeatherControl : DependencyObject
        {
            private string wind;
            private int windSpeed;
            private WeatherEnum weather;
            public static readonly DependencyProperty TemperaturaProperty;

            public string Wind { get; set; }
            public int WindSpeed { get; set; }

            public WeatherControl( string wind, int windSpeed, WeatherEnum weather)
            {
                this.Wind = wind;
                this.WindSpeed = windSpeed;
                this.weather = weather;
            }

            static WeatherControl()
            {
                TemperaturaProperty = DependencyProperty.Register(nameof(Temperatura), typeof(int), typeof(WeatherControl),
                    new FrameworkPropertyMetadata(
                        0,
                        FrameworkPropertyMetadataOptions.AffectsMeasure |   //чтобы было
                        FrameworkPropertyMetadataOptions.AffectsRender,     //чтобы было
                        null,
                        new CoerceValueCallback(CoerceTemperatura)),
                    new ValidateValueCallback(ValidateAge));
            }

            private static bool ValidateAge(object value)
            {
                int v = (int)value;
                if (v > 60 || v < -60)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            private static object CoerceTemperatura(DependencyObject d, object baseValue)
            {
                int v = (int)baseValue;
                if (v >= -50 && v <= 50)
                {
                    return v;
                }
                else
                {
                    if (v > 50)
                    {
                        return 50;
                    }
                    else
                    {
                        if (v < -50)
                        {
                            return -50;
                        }
                        else
                        {
                            return null; //чтобы не ругалось
                        }
                    }
                }
            }

            public int Temperatura
            {
                get { return (int)GetValue(TemperaturaProperty); }
                set { SetValue(TemperaturaProperty, value); }
            }
        }
    }
}
