using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace FinancialStore.Core;
public static class ServiceExtensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        return services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddMediatR(Assembly.GetExecutingAssembly());
    }
}
