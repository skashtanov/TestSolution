using System.Collections.Generic;
using System.Linq;

namespace TestSolution.Tasks.Third
{
    class InterpretedAssembly : IInterpretedAssembly
    {
        private readonly string[] _commands;

        public InterpretedAssembly(string[] commands) =>
            _commands = commands;

        public InterpretedAssembly(IEnumerable<string> commands) :
            this(commands.ToArray())
        {
        }

        public Dictionary<string, int> Result()
        {
            var variables = new Dictionary<string, int>();
            for (var command = 0; command < _commands.Length;)
            {
                var expressionArgs = _commands[command].Split(' ');
                var instruction = expressionArgs[0];
                if (instruction == "inc")
                {
                    var variable = expressionArgs[1];
                    variables[variable]++;
                }
                else if (instruction == "dec")
                {
                    var variable = expressionArgs[1];
                    variables[variable]--;
                }
                else if (instruction == "mov")
                {
                    var source = ExtractedValue(variables, expressionArgs[2]);
                    var destination = expressionArgs[1];
                    variables[destination] = source;
                }
                else if (instruction == "jnz")
                {
                    var regulator = ExtractedValue(variables, expressionArgs[1]);
                    var shift = ExtractedValue(variables, expressionArgs[2]);
                    if (regulator != 0)
                    {
                        command += shift;
                        continue;
                    }
                }
                command++;
            }
            return variables;
        }

        private static int ExtractedValue(Dictionary<string, int> variables, string registerOrConstant)
        {
            if (int.TryParse(registerOrConstant, out var value) == false)
            {
                return variables[registerOrConstant];
            }
            return value;
        }
    }
}
