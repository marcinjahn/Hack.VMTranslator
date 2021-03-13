namespace Hack.VMTranslator.Lib.Commands.Stack.PushSegments
{
    public class PushThisTranslator : SimplePushTranslator
    {
        public PushThisTranslator() : base(Constants.ThisBasePointer)
        {
        }
    }
}