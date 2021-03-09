using System;
using AdvancedCompressionMethods.FileOperations.Interfaces;

namespace AdvancedCompressionMethods.FileOperations.Validators
{
    public class BufferValidator
    {
        public void ValidateAndThrow(IBuffer buffer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}