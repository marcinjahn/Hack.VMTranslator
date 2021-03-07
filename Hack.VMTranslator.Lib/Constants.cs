namespace Hack.VMTranslator.Lib
{
    public static class Constants
    {
        public static int StackPointer { get; } = 0;
        public static int LocalBasePointer { get; } = 1;
        public static int ArgumentBasePointer { get; } = 2;
        public static int ThisBasePointer { get; } = 3;
        public static int ThatBasePointer { get; } = 4;
        public static int TempBaseAddress { get; } = 5;
        public static int TempAddressLength { get; } = 8;
    }
}