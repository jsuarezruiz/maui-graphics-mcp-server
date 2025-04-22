namespace MauiGraphicsMcp
{
    public static class TaskExtensions
    {
        public static void RunAndForget(this Task task, Action<Exception>? onError = null)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task), "The task cannot be null.");
            }

            _ = Task.Run(async () =>
            {
                try
                {
                    await task.ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    onError?.Invoke(ex);

                    Console.WriteLine($"Uncaught exception in RunAndForget: {ex}");
                }
            });
        }
    }
}
