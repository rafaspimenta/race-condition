namespace RaceCondition
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var semaphore = new SemaphoreSlim(1);

            var tasks = new List<Task>();
            var resource = 0;

            async Task work()
            {
                await semaphore.WaitAsync();
                resource++;
                semaphore.Release();
            }

            for (int i = 0; i < 1000; i++)
            {
                var t = work();
                tasks.Add(t);

            }

            await Task.WhenAll(tasks);
            Console.WriteLine(resource);
        }
    }
}