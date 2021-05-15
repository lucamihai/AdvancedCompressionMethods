using System.Diagnostics.CodeAnalysis;
using AdvancedCompressionMethods.ArithmeticCoding;
using AdvancedCompressionMethods.ArithmeticCoding.Interfaces;
using AdvancedCompressionMethods.FileOperations;
using AdvancedCompressionMethods.FileOperations.Interfaces;
using AdvancedCompressionMethods.FileOperations.Interfaces.Validators;
using AdvancedCompressionMethods.FileOperations.Validators;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AdvancedCompressionMethods.DI
{
    [ExcludeFromCodeCoverage]
    public static class DependencyResolver
    {
        public static ServiceCollection GetServices()
        {
            var services = new ServiceCollection();
            
            services.AddTransient<IBuffer, Buffer>();
            services.AddTransient<IFileReader, FileReader>();
            services.AddTransient<IFileWriter, FileWriter>();
            services.AddSingleton<IFilepathValidator, FilepathValidator>();

            services.AddScoped<IArithmeticEncoder, ArithmeticEncoder>();
            services.AddScoped<IArithmeticDecoder, ArithmeticDecoder>();

            services.AddScoped<INearLosslessPredictiveEncoder, NearLosslessPredictiveEncoder>();
            services.AddScoped<INearLosslessPredictiveDecoder, NearLosslessPredictiveDecoder>();

            return services;
        }
    }
}
