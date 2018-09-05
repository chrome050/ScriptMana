using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ScriptMana.Interpreter;

namespace ScriptMana.Interpreters
{
    public class Batch : IInterpreter
    {
        private string ScriptEnding = ".bat";

        public InterpreterType Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string PathToExecutable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private bool IsBatchFile(string scriptPath)
        {
            if (File.Exists(scriptPath) && scriptPath.EndsWith(ScriptEnding))
                return true;

            return false;
        }

        private bool WasSuccessfulCall(int exitCode)
        {
            if (exitCode == 0)
                return true;
            return false;
        }

        private async Task<bool> Run(string scriptPath)
        {
            ProcessStartInfo processInfo;
            Process process;

            if (IsBatchFile(scriptPath))
            {
                var scriptName = Path.GetFileName(scriptPath);

                processInfo = new ProcessStartInfo(scriptPath)
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    WorkingDirectory = Assembly.GetEntryAssembly().Location + "\\" + scriptName
                };

                process = Process.Start(processInfo);

                process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
                    Console.WriteLine("output>>" + e.Data);
                process.BeginOutputReadLine();

                process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
                    Console.WriteLine("error>>" + e.Data);
                process.BeginErrorReadLine();

                //TODO add dynamic timeout
                process.WaitForExit(1000);

                process.Close();

                return WasSuccessfulCall(process.ExitCode);
            }
            return false;

        }

        public async Task<bool> Call<T>(string scriptPath, Dictionary<string, string> arguments)
        {
            if (await Run(scriptPath))
                return true;

            return false;
        }
    }
}
