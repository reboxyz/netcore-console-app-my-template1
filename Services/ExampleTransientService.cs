using ConsoleAppTemplateExample.Interfaces;

namespace ConsoleAppTemplateExample.Services
{
    internal class ExampleTransientService: IExampleTransientService
    {
        Guid IReportServiceLifetime.Id { get; } = Guid.NewGuid();
    }
}
