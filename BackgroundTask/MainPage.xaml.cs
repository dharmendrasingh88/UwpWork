using PocsLibs.BackgroundTasks.Helpers;
using PocsLibs.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Background;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BackgroundTask
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.New)
            {
               
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           var task= BackgroundTaskHelper.RegisterBackgroundTask(taskEntryPoint: "Tasks.OutOfProcessBgTask",
               taskName: "OutOfProcessBgTask",
               trigger: new MaintenanceTrigger(freshnessTime: 15, oneShot: false),
               condition: new SystemCondition(SystemConditionType.InternetAvailable));
            AttachProgressAndCompletedHandlers(task);
        }
        private void AttachProgressAndCompletedHandlers(IBackgroundTaskRegistration task)
        {
          //  task.Progress += new BackgroundTaskProgressEventHandler(OnProgress);
            task.Completed += new BackgroundTaskCompletedEventHandler(OnCompleted);
        }
        /// <summary>
        /// Handle background task progress.
        /// </summary>
        /// <param name="task">The task that is reporting progress.</param>
        /// <param name="e">Arguments of the progress report.</param>
        //private void OnProgress(IBackgroundTaskRegistration task, BackgroundTaskProgressEventArgs args)
        //{
        //    var ignored = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        //    {
        //        var progress = "Progress: " + args.Progress + "%";
        //        BackgroundTaskSample.ServicingCompleteTaskProgress = progress;
        //        UpdateUI();
        //    });
        //}

        /// <summary>
        /// Handle background task completion.
        /// </summary>
        /// <param name="task">The task that is reporting completion.</param>
        /// <param name="e">Arguments of the completion report.</param>
        private void OnCompleted(IBackgroundTaskRegistration task, BackgroundTaskCompletedEventArgs args)
        {
            //UpdateUI();
            Helpers.ShowToast("dksingh");
        }
        //private async void UpdateUI()
        //{
        //    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
        //    () =>
        //    {
        //        RegisterButton.IsEnabled = !BackgroundTaskSample.ServicingCompleteTaskRegistered;
        //        UnregisterButton.IsEnabled = BackgroundTaskSample.ServicingCompleteTaskRegistered;
        //        Progress.Text = BackgroundTaskSample.ServicingCompleteTaskProgress;
        //        Status.Text = BackgroundTaskSample.GetBackgroundTaskStatus(BackgroundTaskSample.ServicingCompleteTaskName);
        //    });
        //}
    }
}
