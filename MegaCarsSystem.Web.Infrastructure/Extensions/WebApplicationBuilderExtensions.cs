﻿namespace MegaCarsSystem.Web.Infrastructure.Extensions
{
    using System.Reflection;

    using Microsoft.Extensions.DependencyInjection;

    public static class WebApplicationBuilderExtensions
    {
        /// <summary>
        /// This method registers all services with their interfacesa and 
        /// implementations of given assembly.
        /// The assembly is taken from the type of random service interface or
        /// implementation provided.
        /// </summary>
        /// <param name="serviceType"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void AddApplicationServices(this IServiceCollection services, Type serviceType)
        {
            Assembly? serviceAssembly = Assembly.GetAssembly(serviceType);

            if (serviceAssembly == null)
            {
                throw new InvalidOperationException("Invalid service type provided!");
            }

            Type[] serviceTypes = serviceAssembly
                .GetTypes()
                .Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
                .ToArray();

            foreach (Type sType in serviceTypes)
            {
                Type? interfaceType = sType.GetInterface($"I{sType.Name}");

                if (interfaceType == null)
                {
                    throw new InvalidOperationException($"No interface is provided for the service with name: {sType.Name}");
                }

                services.AddScoped(interfaceType, sType);
            }
        }
    }
}