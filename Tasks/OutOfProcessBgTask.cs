using PocsLibs.BackgroundTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace Tasks
{
	public sealed class OutOfProcessBgTask :IBackgroundTask
	{
		BackgroundTaskDeferral _deferral;
		public async void Run(IBackgroundTaskInstance taskInstance)
		{
			BackgroundTaskDeferral deferral = taskInstance.GetDeferral();
			bool isCanceled = false;
			taskInstance.Canceled += (s, e) => isCanceled = true;
			try
			{
				if (isCanceled)
				{
					deferral.Complete();
					return;
				}
				await BgCommands.WriteData();
			}
			finally
			{
				deferral.Complete();
			}
		}
		// Generate a random number between two numbers  
		public int GetRandomNumber(int min, int max)
		{
			Random random = new Random();
			return random.Next(min, max);
		}
		
		private void OnCompleted(BackgroundTaskRegistration sender, BackgroundTaskCompletedEventArgs args)
		{
			var settings = Windows.Storage.ApplicationData.Current.LocalSettings;
			//var key = task.TaskId.ToString();
			//var message = settings.Values[key].ToString();
			//UpdateUI(message);
		}
	}
}
