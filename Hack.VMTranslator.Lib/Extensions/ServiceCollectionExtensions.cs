using System;
using Hack.VMTranslator.Lib.Commands;
using Hack.VMTranslator.Lib.Commands.PopSegments;
using Hack.VMTranslator.Lib.Commands.PushSegments;
using Hack.VMTranslator.Lib.Input;
using Hack.VMTranslator.Lib.Output;
using Hack.VMTranslator.Lib.Resolvers;
using Microsoft.Extensions.DependencyInjection;

namespace Hack.VMTranslator.Lib.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, string inputFileName)
        {
            services.AddTransient<PopArgumentTranslator>();
            services.AddTransient<PopLocalTranslator>();
            services.AddTransient<PopPointerTranslator>();
            services.AddTransient<PopStaticTranslator>();
            services.Configure<PopStaticTranslatorOptions>(o =>
                o.FileName = inputFileName);
            services.AddTransient<PopTempTranslator>();
            services.AddTransient<PopThatTranslator>();
            services.AddTransient<PopThisTranslator>();
            services.AddTransient<PopTranslatorFactory>();
            services.AddTransient<PopTranslator>();
            
            services.AddTransient<PushArgumentTranslator>();
            services.AddTransient<PushLocalTranslator>();
            services.AddTransient<PushPointerTranslator>();
            services.AddTransient<PushStaticTranslator>();
            services.Configure<PushStaticTranslatorOptions>(o =>
                o.FileName = inputFileName);
            services.AddTransient<PushTempTranslator>();
            services.AddTransient<PushThatTranslator>();
            services.AddTransient<PushThisTranslator>();
            services.AddTransient<PushConstantTranslator>();
            services.AddTransient<PushTranslatorFactory>();
            services.AddTransient<PushTranslator>();

            services.AddTransient<AddTranslator>();
            services.AddTransient<SubTranslator>();
            services.AddTransient<AndTranslator>();
            services.AddTransient<NegTranslator>();
            services.AddTransient<NotTranslator>();
            services.AddTransient<OrTranslator>();
            
            services.AddSingleton<EqTranslator>();
            services.AddSingleton<GtTranslator>();
            services.AddSingleton<LtTranslator>();

            services.AddTransient<CommandTypeResolver>();
            services.AddTransient<MemorySegmentResolver>();
            services.AddTransient<CommandTranslatorFactory>();

            services.AddTransient<VMTranslator>();

            return services;
        }

        public static IServiceCollection AddInputSupport(this IServiceCollection services, string inputFilePath)
        {
            services.AddTransient<LineCleaner>();
            services.AddTransient<VMCodeLoader>();
            services.Configure<VMCodeLoaderOptions>(o =>
                o.InputPath = inputFilePath);

            return services;
        }

        public static IServiceCollection AddOutputSupport(this IServiceCollection services)
        {
            services.AddTransient<FileSaver>();

            return services;
        }
        
    }
}