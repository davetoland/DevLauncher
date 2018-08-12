using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace DevLauncher
{
    public class ConsoleLauncher
    {
        public void BuildExecutable(string pathToProjOrSln)
        {
            string projOrSln = Path.GetFileName(pathToProjOrSln);
            string directory = Path.GetDirectoryName(pathToProjOrSln);

            LaunchAndWait(Path.Combine(RuntimeEnvironment.GetRuntimeDirectory(), "msbuild.exe"), projOrSln, directory, "Build succeeded.");
        }
        public void BuildDotnetCoreApp(string pathToDir)
        {
            LaunchAndWait("dotnet", "build", pathToDir, "Build succeeded.");
        }

        public string LaunchAndWait(string pathToExe, string args, string workingDir, string regexToWaitFor)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    FileName = pathToExe,
                    Arguments = args,
                    WorkingDirectory = workingDir
                }
            };
            process.Start();

            string output = "";
            do
            {
                output = process.StandardOutput.ReadLine();
                if (output != null && !Regex.Match(output, regexToWaitFor).Success)
                {
                    Console.WriteLine(output);
                    Debug.WriteLine(output);
                }
            }
            while (output == null || !Regex.Match(output, regexToWaitFor).Success);

            return output;
        }
    }
}
