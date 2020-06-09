using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.ApplicationModel.Core;
using Windows.Data.Xml.Dom;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;
using Windows.UI.Core;
using Windows.UI.Notifications;
using Windows.UI.Xaml;

namespace PocsLibs.Common
{
    public static class Helpers
    {
        /// <summary>
        /// Runs the specified handler on the UI thread at Normal priority. 
        /// </summary>
        public static async Task CallOnUiThreadAsync(DispatchedHandler handler) => await
            CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, handler);

        /// <summary>
        /// Starts a timer to perform the specified action at the specified interval.
        /// </summary>
        /// <param name="intervalInMinutes">The interval.</param>
        /// <param name="action">The action.</param>
        public static void StartTimer(int intervalInMinutes, Action action, int intervalInSec = 0)
        {
            var timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, intervalInMinutes, intervalInSec);
            timer.Tick += (s, e) => action();
            timer.Start();
        }
        /// <summary>
        /// Shows the specified text in a toast notification if notifications are enabled.
        /// </summary>
        /// <param name="text">The text to show.</param>
        public static void ShowToast(string text)
        {
            var toastXml = new XmlDocument();
            toastXml.LoadXml("<toast duration='short'><visual><binding template='ToastText01'>" +
                $"<text id='1'>{text}</text></binding></visual></toast>");
            var toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

    }
}
