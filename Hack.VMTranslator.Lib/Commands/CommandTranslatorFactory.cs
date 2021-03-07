using System;
using System.Dynamic;
using Microsoft.Extensions.DependencyInjection;

namespace Hack.VMTranslator.Lib.Commands
{
    public class CommandTranslatorFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandTranslatorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public ICommandTranslator GetTranslator(CommandType type)
        {
            return type switch
            {
                CommandType.Add => Get<AddTranslator>(),
                CommandType.Sub => Get<SubTranslator>(),
                CommandType.Neg => Get<NegTranslator>(),
                CommandType.Eq => Get<EqTranslator>(),
                CommandType.Gt => Get<GtTranslator>(),
                CommandType.Lt => Get<LtTranslator>(),
                CommandType.And => Get<AndTranslator>(),
                CommandType.Or => Get<OrTranslator>(),
                CommandType.Not => Get<NotTranslator>(),
                CommandType.Pop => Get<PopTranslator>(),
                CommandType.Push => Get<PushTranslator>(),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }

        private ICommandTranslator Get<T>()
        {
            return new TranslatorWithComment((ICommandTranslator) _serviceProvider.GetRequiredService<T>());
        }
    }
}