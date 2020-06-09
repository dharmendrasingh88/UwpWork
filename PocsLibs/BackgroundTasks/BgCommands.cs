using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace PocsLibs.BackgroundTasks
{
	public  class BgCommands
	{
		
		
		
		public async static Task<bool> WriteData()
		{
			try
			{
				Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
				Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync("test.txt",
																Windows.Storage.CreationCollisionOption.GenerateUniqueName);

				await Windows.Storage.FileIO.WriteTextAsync(sampleFile, GetRandomNumber(10, 100).ToString());
				return true;
			}
			catch(Exception )
			{
				return false;
			}
		}
		public static int GetRandomNumber(int min, int max)
		{
			Random random = new Random();
			return random.Next(min, max);
		}
	}
}
