using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace multi_instance_background_task
{
    static class Background
    {


        static public ApplicationTrigger AppTrigger;
        static private bool taskRegistered;

        public async static Task<ApplicationTriggerResult> StartBackgroundTask()
        {
            return await AppTrigger.RequestAsync();
        }

        static public async void RegisterBackgroundSaveTrigger()
        {
            AppTrigger = new ApplicationTrigger();
            var requestStatus = await BackgroundExecutionManager.RequestAccessAsync();
            if (requestStatus != BackgroundAccessStatus.DeniedBySystemPolicy && requestStatus != BackgroundAccessStatus.DeniedByUser)
            {
                string entryPoint = "background_tasks.ThisBackgroundTask";
                string taskName = "ThisBackgroundTask";

                BackgroundTaskRegistration task = RegisterBackgroundTask(entryPoint, taskName, AppTrigger, null);
}

        }

        static private BackgroundTaskRegistration RegisterBackgroundTask(string entryPoint, string taskName, IBackgroundTrigger appTrigger, IBackgroundCondition condition)
        {
            foreach (var task in BackgroundTaskRegistration.AllTasks)
            {
                if (task.Value.Name == taskName)
                {
                    taskRegistered = true;
                    return (BackgroundTaskRegistration)(task.Value);
                }
            }
            var builder = new BackgroundTaskBuilder();

            builder.Name = taskName;
            builder.TaskEntryPoint = entryPoint;
            builder.SetTrigger(appTrigger);

            if (condition != null)
            {

                builder.AddCondition(condition);
            }

            return builder.Register();
        }

    }


}
