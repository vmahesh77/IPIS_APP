using ArecaIPIS.Server_Classes;

namespace ArecaIPIS.Taddb_Controllers
{
    class IntegrationSeperators
    {
        public static byte[] PfdbMldbTrainNameSeperators = PfdbController.ConvertDecimalNumberTOByteArray(58);
        public static byte[] PfdbMldbExptSeperators = PfdbController.ConvertDecimalNumberTOByteArray(253);
        public static byte[] PfdbMldbADSeperators = PfdbController.ConvertDecimalNumberTOByteArray(297);
        public static byte[] PfdbMldbPFSeperators = PfdbController.ConvertDecimalNumberTOByteArray(309);
        public static byte[] Seperators = new byte[] { 231, 00 };
    }
}
