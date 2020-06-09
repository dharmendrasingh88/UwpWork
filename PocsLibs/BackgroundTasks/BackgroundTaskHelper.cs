using System.Linq;
using Windows.ApplicationModel.Background;
namespace PocsLibs.BackgroundTasks.Helpers
{
    /// <summary>
    /// Provides helper methods for registering and unregistering background tasks. 
    /// </summary>
    public static class BackgroundTaskHelper
    {
        /// <summary>
        /// Registers a background task with the specified taskEntryPoint, name, trigger,
        /// and condition (optional).
        /// </summary>
        /// <param name="taskEntryPoint">Task entry point for the background task.</param>
        /// <param name="taskName">A name for the background task.</param>
        /// <param name="trigger">The trigger for the background task.</param>
        /// <param name="condition">Optional parameter. A conditional event that must be true for the task to fire.</param>
        /// <returns>The registered background task.</returns>
        public static BackgroundTaskRegistration RegisterBackgroundTask(
            string taskEntryPoint, string taskName, IBackgroundTrigger trigger, IBackgroundCondition condition)
        {
            // Check for existing registrations of this background task.
            foreach (var task in BackgroundTaskRegistration.AllTasks)
            {
                if (task.Value.Name.Equals(taskName))
                {
                    // The task is already registered.
                    return task.Value as BackgroundTaskRegistration;
                }
            }

            // Register the background task.
            var builder = new BackgroundTaskBuilder { Name = taskName, TaskEntryPoint = taskEntryPoint };
            if (condition != null) builder.AddCondition(condition);
            builder.SetTrigger(trigger);

            return builder.Register();
        }

        /// <summary>
        /// Unregisters the background task with the specified name. 
        /// </summary>
        /// <param name="taskName">The name of the background task to unregister.</param>
        public static void UnregisterBackgroundTask(string taskName)
        {
            BackgroundTaskRegistration.AllTasks.First(task =>
                taskName.Equals(task.Value.Name)).Value.Unregister(cancelTask: true);
        }
    }
}
