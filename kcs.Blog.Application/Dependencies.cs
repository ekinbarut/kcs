using FluentValidation;
using kcs.Blog.Abstraction.Validator;
using kcs.Blog.Application.ValidationRequestPreProcessor;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace kcs.Blog.Application
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterRequestHandlers(
            this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPostProcessorBehavior<,>));

            return services;
        }
    }
}