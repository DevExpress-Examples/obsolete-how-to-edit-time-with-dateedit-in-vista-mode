using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DatetimeEditor
{
    public partial class Clock : UserControl
    {
        public Clock() {
            InitializeComponent();
            DataContext = this;
        }
        public static readonly DependencyProperty DateTimeValueProperty =
            DependencyProperty.Register("DateTimeValue", typeof(DateTime), typeof(Clock),
            new PropertyMetadata(DateTime.Now,
                new PropertyChangedCallback(OnDateTimeValuePropertyChanged)));
        public DateTime DateTimeValue {
            get { return (DateTime)GetValue(DateTimeValueProperty); }
            set { SetValue(DateTimeValueProperty, value); }
        }
        private static void OnDateTimeValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            OnDateTimeValuePropertyChanged(d, e.NewValue, e.OldValue);
        }
        private static void OnDateTimeValuePropertyChanged(DependencyObject d, object p1, object p2) {
            Clock sender = d as Clock;
            double minutes = (double)sender.DateTimeValue.Minute;
            double seconds = (double)sender.DateTimeValue.Second;
            sender.a_hour.Value = (sender.DateTimeValue.Hour) % 12 + minutes / 60.0;
            sender.a_minute.Value = ((sender.DateTimeValue.Minute + seconds / 60.0) / 60.0) * 12;
            sender.a_second.Value = (seconds / 60.0) * 12;
        }
    }
}
