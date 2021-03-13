namespace Hack.VMTranslator.Lib.Commands.Stack.PopSegments
{
    public class PopLocalTranslator : SimplePopTranslator
    {
        public PopLocalTranslator() : base(Constants.LocalBasePointer)
        {
        }
    }
}