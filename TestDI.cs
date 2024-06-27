using ConsoleAppTemplateExample.Interfaces;


namespace ConsoleAppTemplateExample
{
    internal class TestDI
    {
        private readonly IExampleTransientService _service;

        public TestDI(IExampleTransientService service)
        {
            _service = service;
        }

        public void Run()
        {
            Console.WriteLine("Running ... " + _service.Id + " => " + _service.Lifetime);
            Console.WriteLine();
        }
    }
}
