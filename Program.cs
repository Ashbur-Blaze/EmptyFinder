using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("用法：EmptyFinder <文件夹路径>");
            return;
        }

        string path = args[0];
        int count = FindEmptyFiles(path);
        Console.WriteLine($"共找到 {count} 个空文件");
    }

    static int FindEmptyFiles(string path)
    {
        if (Directory.Exists(path))
        {
            string[] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            int total = 0;

            foreach (string file in files)
            {
                total += FindEmptyFiles(file);
            }

            return total;
        }

        if (File.Exists(path))
        {
            if (new FileInfo(path).Length == 0)
            {
                Console.WriteLine(path);
                return 1;
            }
            return 0;
        }

        return 0;
    }
}