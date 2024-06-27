using Microsoft.Extensions.DependencyInjection;

namespace ConsoleAppTemplateExample.Interfaces
{
    internal interface IExampleTransientService: IReportServiceLifetime
    {
        ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Transient;
    }
}
