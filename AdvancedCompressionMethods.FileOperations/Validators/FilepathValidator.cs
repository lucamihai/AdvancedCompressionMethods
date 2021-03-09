using System;
using System.IO;

namespace AdvancedCompressionMethods.FileOperations.Validators
{
    public class FilepathValidator
    {
        public void ValidateAndThrow(string filePath, bool checkIfExists = true)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException();
            }

            if (checkIfExists && !File.Exists(filePath))
            {
                throw new ArgumentException($"File '{filePath}' does not exist");
            }
        }
    }
}