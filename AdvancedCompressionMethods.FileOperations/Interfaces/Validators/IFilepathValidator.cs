namespace AdvancedCompressionMethods.FileOperations.Interfaces.Validators
{
    public interface IFilepathValidator
    {
        void ValidateAndThrow(string filePath, bool checkIfExists = true);
    }
}