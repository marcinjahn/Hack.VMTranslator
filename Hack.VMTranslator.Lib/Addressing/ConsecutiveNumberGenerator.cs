namespace Hack.VMTranslator.Lib.Addressing
{
    /// <summary>
    /// Generates consecutive numbers
    /// </summary>
    public static class ConsecutiveNumberGenerator
    {
        private static int _nextNumber;
        
        public static int GetNext()
        {
            return _nextNumber++;
        }
    }
}