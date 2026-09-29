using System;
using System.IO;
using System.Collections.Generic;

namespace EmptyFinderPractice;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("用法: EmptyFinderPractice <文件夹路径>");
            return;
        }

        string path = args[0];
        List<string> emptyFiles = FindEmptyFiles(path);

        Console.WriteLine();
        foreach (string file in emptyFiles)
        {
            Console.WriteLine(file);
        }
        Console.WriteLine($"共找到 {emptyFiles.Count} 个空文件");

        if (emptyFiles.Count == 0)
        {
            return;
        }

        Console.WriteLine();
        Console.Write("是否删除这些空文件？(y/n): ");
        string input = Console.ReadLine();

        if (input != null && input.ToLower() == "y")
        {
            int deleted = 0;
            int failed = 0;

            foreach (string file in emptyFiles)
            {
                try
                {
                    File.Delete(file);
                    deleted++;
                    Console.WriteLine($"已删除: {file}");
                }
                catch (Exception ex)
                {
                    failed++;
                    Console.WriteLine($"删除失败: {file}");
                    Console.WriteLine($"原因: {ex.Message}");
                }
            }

            Console.WriteLine();
            Console.WriteLine($"成功删除 {deleted} 个，失败 {failed} 个");
        }
        else
        {
            Console.WriteLine("已取消。");
        }
    }

    static List<string> FindEmptyFiles(string path)
    {
        List<string> result = new List<string>();

        if (Directory.Exists(path))
        {
            string[] files;
            try
            {
                var options = new EnumerationOptions
                {
                    RecurseSubdirectories = true,
                    IgnoreInaccessible = true
                };
                files = Directory.GetFiles(path, "*", options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"无法遍历文件夹: {path}");
                Console.WriteLine($"原因: {ex.Message}");
                return result;
            }

            foreach (string file in files)
            {
                result.AddRange(FindEmptyFiles(file));
            }
            return result;
        }

        if (File.Exists(path))
        {
            try
            {
                if (new FileInfo(path).Length == 0)
                {
                    result.Add(path);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"跳过: {path}（{ex.Message}）");
            }
            return result;
        }

        return result;
    }
}