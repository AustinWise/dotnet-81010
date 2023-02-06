using System.Globalization;
using System.Diagnostics;

static class Program
{
    static void FillStack(byte value)
    {
        Span<byte> bytes = stackalloc byte[1024 * 16];
        bytes.Fill(value);
    }

    static void Main(string[] args)
    {
        Console.WriteLine($"Attach to PID {Process.GetCurrentProcess().Id} and press enter.");
        Console.ReadLine();
        if (args.Length != 0)
        {
            byte fillValue = byte.Parse(args[0], NumberStyles.HexNumber);
            AppDomain.CurrentDomain.UnhandledException += (_,_) => FillStack(fillValue);
        }
        throw new Exception();
    }
}