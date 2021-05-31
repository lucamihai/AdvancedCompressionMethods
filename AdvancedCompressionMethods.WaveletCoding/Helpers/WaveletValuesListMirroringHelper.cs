using System.Collections.Generic;

namespace AdvancedCompressionMethods.WaveletCoding.Helpers
{
    // TODO: Make this a service instead of static
    public static class WaveletValuesListMirroringHelper
    {
        public static List<T> GetValuesListWithMirroredExtremities<T>(List<T> values)
        {
            // TODO: Maybe handle cases when values.Count < 4?

            var newValues = new List<T>();

            for (var i = 4; i >= 1; i--)
            {
                newValues.Add(values[i]);
            }

            newValues.AddRange(values);

            var indexOfLastElement = values.Count - 1;
            for (var i = 0; i < 4; i++)
            {
                newValues.Add(values[indexOfLastElement - 1 - i]);
            }

            return newValues;
        }
    }
}