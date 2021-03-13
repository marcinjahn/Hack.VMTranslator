namespace Hack.VMTranslator.Lib.Commands.Stack.PushSegments
{
    public class PushLocalTranslator : SimplePushTranslator
    {
        public PushLocalTranslator() : base(Constants.LocalBasePointer)
        {
        }
    }
}