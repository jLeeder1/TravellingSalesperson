namespace TravellingSalespersonProj
{
    class ConvertIntToString
    {
        public static string Convert(int integertoConvert)
        {
            string result = string.Empty;
            while (--integertoConvert >= 0)
            {
                result = (char)('A' + integertoConvert % 26) + result;
                integertoConvert /= 26;
            }
            return result;
        }
    }
}
