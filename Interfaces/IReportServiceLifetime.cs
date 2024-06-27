using Microsoft.Extensions.DependencyInjection;

namespace ConsoleAppTemplateExample.Interfaces
{
    internal interface IReportServiceLifetime
    {
        Guid Id { get; }

        ServiceLifetime Lifetime { get; }
    }
}
