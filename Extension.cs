using System;
using System.IO;
using System.Text;

namespace Aryes
{
    internal static class Extension
    {
        internal static void Emit(this StreamWriter sw, OpCodes Operator)
        {
            Emit(sw, Operator, null);
        }

        internal static void Emit(this StreamWriter sw, OpCodes Operator, object operand)
        {
            var cmd = new StringBuilder(Operator.ToString());
            if (operand != null)
            {
                cmd.Append(' ');
                if (operand is bool)
                    cmd.Append((bool)operand ? "ON" : "OFF");
                else if (operand is string)
                    cmd.Append(operand);
                else
                    throw new ApplicationException("What is that?");
            }
            sw.WriteLine(cmd.ToString());
        }
    }
}