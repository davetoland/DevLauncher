using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevLauncher.Tests
{
    [TestClass]
    public class ConsoleLauncherTests
    {
        [TestMethod]
        public void Console_LaunchAndWait_WaitsForAll()
        {
            var launcher = new ConsoleLauncher();
            string root = @"C:\Development\Projects\DevLauncher\DevLauncher.Tests.Mocks\";

            launcher.BuildExecutable(Path.Combine(root, "DevLauncher.Tests.MockConsole.csproj"));

            launcher.LaunchAndWait(Path.Combine(root, "bin", "Debug", "DevLauncher.Tests.MockConsole.exe"), "", "", "I \\w+ finished!");
            launcher.LaunchAndWait(Path.Combine(root, "bin", "Debug", "DevLauncher.Tests.MockConsole.exe"), "", "", "I am finished!");
            launcher.LaunchAndWait(Path.Combine(root, "bin", "Debug", "DevLauncher.Tests.MockConsole.exe"), "", "", "I am fin\\w+");
        }
    }
}
