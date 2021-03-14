using System;
using Hack.VMTranslator.Lib.Commands;
using Hack.VMTranslator.Lib.Commands.Arithmetic;
using Hack.VMTranslator.Lib.Commands.Branching;
using Hack.VMTranslator.Lib.Commands.Functions;
using Hack.VMTranslator.Lib.Commands.Logical;
using Hack.VMTranslator.Lib.Commands.Relational;
using Hack.VMTranslator.Lib.Commands.Stack;
using Hack.VMTranslator.Lib.Commands.Stack.PopSegments;
using Hack.VMTranslator.Lib.Commands.Stack.PushSegments;
using Hack.VMTranslator.Lib.Input;
using Hack.VMTranslator.Lib.Output;
using Hack.VMTranslator.Lib.Resolvers;
using Microsoft.Extensions.DependencyInjection;

namespace Hack.VMTranslator.Lib.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, bool includeBootstrap)
        {
            services.AddTransient<PopArgumentTranslator>();
            services.AddTransient<PopLocalTranslator>();
            services.AddTransient<PopPointerTranslator>();
            services.AddTransient<PopStaticTranslator>();
            services.AddTransient<PopTempTranslator>();
            services.AddTransient<PopThatTranslator>();
            services.AddTransient<PopThisTranslator>();
            services.AddTransient<PopTranslatorFactory>();
            services.AddTransient<PopTranslator>();
            
            services.AddTransient<PushArgumentTranslator>();
            services.AddTransient<PushLocalTranslator>();
            services.AddTransient<PushPointerTranslator>();
            services.AddTransient<PushStaticTranslator>();
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

            services.AddTransient<LabelTranslator>();
            services.AddTransient<GotoTranslator>();
            services.AddTransient<IfGotoTranslator>();
            
            services.AddTransient<FunctionTranslator>();
            services.AddTransient<CallTranslator>();
            services.AddTransient<ReturnTranslator>();

            services.AddTransient<CommandTypeResolver>();
            services.AddTransient<MemorySegmentResolver>();
            services.AddTransient<CommandTranslatorFactory>();

            services.AddTransient<BootstrapGenerator>();

            services.AddTransient<VMTranslator>();
            services.Configure<VMTranslatorOptions>(
                o => o.IncludeBootstrap = includeBootstrap);

            return services;
        }

        public static IServiceCollection AddInputSupport(this IServiceCollection services)
        {
            services.AddTransient<InputCodeLineFactory>();
            services.AddTransient<VmFileLoaderFactory>();
            services.AddTransient<VmDirectoryLoaderFactory>();

            return services;
        }

        public static IServiceCollection AddOutputSupport(this IServiceCollection services)
        {
            services.AddTransient<FileSaver>();

            return services;
        }
        
    }
}