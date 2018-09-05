using ScriptMana.Interpreters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ScriptMana.Interpreter
{
    public class Interpreter : IInterpreter
    {
        private Batch BatchInterpreter { get; set; }

        public InterpreterType Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PathToExecutable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Interpreter()
        {
            BatchInterpreter = new Batch();
        }

        public Task<bool> Call<T>(string scriptPath, Dictionary<string, string> arguments)
        {
            if (typeof(T) == typeof(Batch))
            {
                return BatchInterpreter.Call<T>(scriptPath, arguments);
            }

            throw new NotImplementedException();
        }
    }
}
