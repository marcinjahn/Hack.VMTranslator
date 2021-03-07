namespace Hack.VMTranslator.Lib.Commands.PushSegments
{
    public class PushLocalTranslator : SimplePushTranslator
    {
        public PushLocalTranslator() : base(Constants.LocalBasePointer)
        {
        }
    }
}