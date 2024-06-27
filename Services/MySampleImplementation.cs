using ConsoleAppTemplateExample.Interfaces;

namespace ConsoleAppTemplateExample.Services
{
    internal class MySampleImplementation : IMySampleInterface
    {
        public Task Execute()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"MySampleImplementation.Execute: {i + 1}");
                Thread.Sleep(1000);
            }
            return Task.CompletedTask;
        }
    }
}
