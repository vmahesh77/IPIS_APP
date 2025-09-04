namespace ArecaIPIS.Forms.VdcForms
{
    public class MediaFile
    {
        public string FileName { get; set; }
        public int ImageTime { get; set; }
        public string DisplayEffect { get; set; }
        public string ClearingEffect { get; set; }
        public string FilePath { get; set; }
        public int MediaType { get; set; }

        public MediaFile(string fileName, int imageTime, string displayEffect, string clearingEffect, string filePath, int mediaType)
        {
            FileName = fileName;
            ImageTime = imageTime;
            DisplayEffect = displayEffect;
            ClearingEffect = clearingEffect;

            FilePath = filePath;

            MediaType = mediaType;
        }

        public override string ToString()
        {
            return $"{FileName} - {ImageTime} sec - {DisplayEffect} - {ClearingEffect} - {FilePath}";
        }
    }
}
