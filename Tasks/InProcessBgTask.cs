using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace Tasks
{
	public sealed class InProcessBgTask:IBackgroundTask
	{
		public void Run(IBackgroundTaskInstance taskInstance)
		{
			throw new NotImplementedException();
		}
	}
}
