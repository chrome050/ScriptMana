using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScriptMana.Interpreter
{
    interface IInterpreter<T>
    {
        InterpreterType Type { get; set; }

        string PathToExecutable { get; set; }

        Task Call(Dictionary<string, string> Arguments);
    }
}
