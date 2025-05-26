using OpenCalligraphy.Core.FileSystem;

namespace OpenCalligraphy.DiffTool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: OpenCalligraphy.DiffTool [oldPakFile] [newPakFile]");
                return;
            }

            try
            {
                PakDiffUtility.Diff(args[0], args[1], Console.Out);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
