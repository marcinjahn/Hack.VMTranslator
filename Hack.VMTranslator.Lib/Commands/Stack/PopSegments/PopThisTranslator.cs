namespace Hack.VMTranslator.Lib.Commands.Stack.PopSegments
{
    public class PopThisTranslator : SimplePopTranslator
    {
        public PopThisTranslator() : base(Constants.ThisBasePointer)
        {
        }
    }
}