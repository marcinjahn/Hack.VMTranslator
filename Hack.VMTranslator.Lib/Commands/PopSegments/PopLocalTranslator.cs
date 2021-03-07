namespace Hack.VMTranslator.Lib.Commands.PopSegments
{
    public class PopLocalTranslator : SimplePopTranslator
    {
        public PopLocalTranslator() : base(Constants.LocalBasePointer)
        {
        }
    }
}