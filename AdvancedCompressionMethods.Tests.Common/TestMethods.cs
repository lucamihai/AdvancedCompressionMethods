﻿using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;
using KellermanSoftware.CompareNetObjects;

namespace AdvancedCompressionMethods.Tests.Common
{
    [ExcludeFromCodeCoverage]
    public static class TestMethods
    {
        public static void CreateFileWithTextContents(string filePath, string textContents)
        {
            File.WriteAllText(filePath, textContents);
        }

        public static void CreateFileWithGivenBytes(string filePath, byte[] bytes)
        {
            File.WriteAllBytes(filePath, bytes);
        }

        public static void CopyFileAndReplaceIfAlreadyExists(string source, string destination)
        {
            if (File.Exists(destination))
            {
                File.Delete(destination);
            }

            File.Copy(source, destination);
        }

        public static void DeleteFileIfExists(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static bool FilesHaveTheSameContent(string filePath1, string filePath2)
        {
            var bytesFromFile1 = File.ReadAllBytes(filePath1);
            var bytesFromFile2 = File.ReadAllBytes(filePath2);

            var comparer = new CompareLogic();
            return comparer.Compare(bytesFromFile1, bytesFromFile2).AreEqual;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethodName()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }
    }
}
