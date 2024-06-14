using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Animation;

namespace 四色灯闪烁
{
   public partial class MainWindowViewmodel:ObservableRecipient
    {
        private Storyboard _storyboard;
        public MainWindowViewmodel()
        {
            SetupAnimation();

        }
        private void SetupAnimation()
        {
            _storyboard = new Storyboard
            {
                RepeatBehavior = RepeatBehavior.Forever,
                AutoReverse = true
            };

            var colorAnimation1 = new ColorAnimation
            {
                From = (Color)ColorConverter.ConvertFromString(value: "#00FF04"),
                To= (Color)ColorConverter.ConvertFromString(value: "#FF43982E"),
                Duration = new Duration(TimeSpan.FromSeconds(0.5))
            };
            Storyboard.SetTargetName(colorAnimation1, "Greenlight");
            Storyboard.SetTargetProperty(colorAnimation1, new PropertyPath("(Rectangle.Fill).(LinearGradientBrush.GradientStops)[0].(GradientStop.Color)"));

            var colorAnimation2 = new ColorAnimation
            {
                From = (Color)ColorConverter.ConvertFromString(value: "#00FF04"),
                To = (Color)ColorConverter.ConvertFromString(value: "#FF43982E"),
                Duration = new Duration(TimeSpan.FromSeconds(0.5))
            };
            Storyboard.SetTargetName(colorAnimation2, "Greenlight");
            Storyboard.SetTargetProperty(colorAnimation2, new PropertyPath("(Rectangle.Fill).(LinearGradientBrush.GradientStops)[1].(GradientStop.Color)"));

            var colorAnimation3 = new ColorAnimation
            {
                From = (Color)ColorConverter.ConvertFromString(value: "#00FF04"),
                To = (Color)ColorConverter.ConvertFromString(value: "#FF43982E"),
                Duration = new Duration(TimeSpan.FromSeconds(0.5))
            };
            Storyboard.SetTargetName(colorAnimation3, "Greenlight");
            Storyboard.SetTargetProperty(colorAnimation3, new PropertyPath("(Rectangle.Fill).(LinearGradientBrush.GradientStops)[2].(GradientStop.Color)"));


            _storyboard.Children.Add(colorAnimation1);
            _storyboard.Children.Add(colorAnimation2);
            _storyboard.Children.Add(colorAnimation3);

        }

        public void StartFlashing()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                _storyboard.Begin(Application.Current.MainWindow, true);
            });
        }

        public void StopFlashing()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                _storyboard.Stop(Application.Current.MainWindow);
            });
        }

        [RelayCommand]
        private void CheckConditionAndFlash()
        {
            // Your condition here
            bool conditionMet = true; // Change this based on your logic

            if (conditionMet)
            {
                StartFlashing();
            }
            else
            {
                StopFlashing();
            }
        }

    }
}
