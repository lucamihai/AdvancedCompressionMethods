using System.Drawing;
using System.Text;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Entities
{
    public class ImageMatrices
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public byte[,] Codes { get; private set; }
        public byte[,] Predictions { get; private set; }
        public int[,] Errors { get; private set; }
        public int[,] QuantizedErrors { get; private set; }
        public int[,] DequantizedErrors { get; private set; }
        public byte[,] Decoded { get; private set; }

        public ImageMatrices(int width, int height)
        {
            Width = width;
            Height = height;

            InitializeMatrices();
        }

        public ImageMatrices(Bitmap image)
        {
            Width = image.Width;
            Height = image.Height;

            InitializeMatrices();

            AddImageCodes(image);
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(GetMatrixString(Codes, nameof(Codes)));
            stringBuilder.AppendLine(GetMatrixString(Predictions, nameof(Predictions)));
            stringBuilder.AppendLine(GetMatrixString(Errors, nameof(Errors)));
            stringBuilder.AppendLine(GetMatrixString(QuantizedErrors, nameof(QuantizedErrors)));
            stringBuilder.AppendLine(GetMatrixString(DequantizedErrors, nameof(DequantizedErrors)));
            stringBuilder.AppendLine(GetMatrixString(Decoded, nameof(Decoded)));

            return stringBuilder.ToString();
        }

        private static string GetMatrixString<T>(T[,] matrix, string name)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(name);

            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                for (var column = 0; column < matrix.GetLength(1); column++)
                {
                    stringBuilder.Append($"{matrix[row, column]} ");
                }

                stringBuilder.AppendLine();
            }

            stringBuilder.AppendLine();

            return stringBuilder.ToString();
        }

        private void InitializeMatrices()
        {
            Codes = new byte[Width, Height];
            Predictions = new byte[Width, Height];
            Errors = new int[Width, Height];
            QuantizedErrors = new int[Width, Height];
            DequantizedErrors = new int[Width, Height];
            Decoded = new byte[Width, Height];
        }

        private void AddImageCodes(Bitmap image)
        {
            for (var row = 0; row < image.Width; row++)
            {
                for (var column = 0; column < image.Height; column++)
                {
                    Codes[row, column] = image.GetPixel(row, column).R;
                }
            }
        }
    }
}