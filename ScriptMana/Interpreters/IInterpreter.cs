using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScriptMana.Interpreter
{
    interface IInterpreter
    {
        InterpreterType Type { get; set; }

        string PathToExecutable { get; set; }

        Task<bool> Call<T>(string scriptPath, Dictionary<string, string> arguments);
    }
}
