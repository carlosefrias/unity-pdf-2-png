using System;
using System.Diagnostics;
using System.IO;
using UnityEngine;

namespace Assets.Scripts
{
    public class Convert2Png : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            const string pdfFilePath = @"Assets/PDFs/Unix_cmd.pdf";
            const string converterFilePath = @"../dist/convert2png.exe";

            ExecuteCommand(converterFilePath, pdfFilePath);
        }


        public void ExecuteCommand(string converterFilePath, string pdfFilePath)
        {

            var fullPath = Path.GetFullPath(converterFilePath);
            var start = new ProcessStartInfo
            {
                FileName = fullPath,
                Arguments = pdfFilePath,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            using (var process = Process.Start(start))
            {
                if (process == null) return;
                using (var reader = process.StandardOutput)
                {
                    var stderr = process.StandardError.ReadToEnd(); // Here are the exceptions from our Python script
                    Console.Error.WriteLine(stderr);
                    var result = reader.ReadToEnd(); // Here is the result of StdOut(for example: print "test")
                    Console.WriteLine(result);
                }
            }
        }

    }
}
