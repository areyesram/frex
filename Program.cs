using System;
using System.Collections.Generic;
using System.IO;
using Aryes.Core;
using Aryes.BE;

namespace Aryes
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0 || args[0] == "--help" || args[0] == "-h")
            {
                PrintHelp();
                return;
            }

            string path = ".";
            bool clearResults = true;

            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "--path":
                    case "-p":
                        if (i + 1 < args.Length) path = args[++i];
                        break;
                    case "--pattern":
                    case "-m":
                        if (i + 1 < args.Length) FindRegX.Pattern = args[++i];
                        break;
                    case "--regex":
                    case "-r":
                        if (i + 1 < args.Length) FindRegX.Regex = args[++i];
                        break;
                    case "--replace":
                    case "-w":
                        if (i + 1 < args.Length) FindRegX.Replace = args[++i];
                        break;
                    case "--recursive":
                    case "-R":
                        FindRegX.Recursive = true;
                        break;
                    case "--casesensitive":
                    case "-c":
                        FindRegX.CaseSensitive = true;
                        break;
                    case "--trim":
                    case "-t":
                        FindRegX.Trim = true;
                        break;
                    case "--script":
                    case "-s":
                        if (i + 1 < args.Length)
                        {
                            var scriptPath = args[++i];
                            LoadScript(scriptPath);
                        }
                        break;
                    default:
                        Console.WriteLine($"Unknown argument: {args[i]}");
                        PrintHelp();
                        return;
                }
            }

            FindRegX.FileProcessed += (file, reason) => {
                Console.WriteLine($"Processed: {file}");
            };
            FindRegX.FileSkipped += (file, reason) => {
                Console.WriteLine($"Skipped: {file} ({reason})");
            };

            Console.WriteLine("Starting Find/Replace...");
            FindRegX.Start(path, clearResults);
            
            Console.WriteLine($"Finished! Matches: {FindRegX.Matches}");
            
            // Output results
            Console.WriteLine("Results found:");
            foreach(var res in FindRegX.Results)
            {
                Console.WriteLine(res);
            }
        }

        static void LoadScript(string scriptPath)
        {
            if (!File.Exists(scriptPath))
            {
                Console.WriteLine($"Script file not found: {scriptPath}");
                return;
            }

            var replacements = new List<ReplacementInfo>();
            var lines = File.ReadAllLines(scriptPath);
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#")) continue;

                var parts = line.Split('\t');
                if(parts.Length == 2)
                {
                    replacements.Add(new ReplacementInfo {
                        TextToFind = parts[0],
                        ReplaceWith = parts[1]
                    });
                }
                else
                {
                    parts = line.Split('|');
                    if(parts.Length >= 2)
                    {
                        replacements.Add(new ReplacementInfo {
                            TextToFind = parts[0],
                            ReplaceWith = parts[1]
                        });
                    }
                }
            }

            FindRegX.Replacements = replacements.ToArray();
            Console.WriteLine($"Loaded {replacements.Count} replacements from script.");
        }

        static void PrintHelp()
        {
            Console.WriteLine("frex - Find RegX (Command Line Version)");
            Console.WriteLine("Usage: frex [options]");
            Console.WriteLine("Options:");
            Console.WriteLine("  -p, --path <path>           Base path to search (default: .)");
            Console.WriteLine("  -m, --pattern <pattern>     File wildcard pattern (e.g., *.cs)");
            Console.WriteLine("  -r, --regex <regex>         Regular expression to find");
            Console.WriteLine("  -w, --replace <replace>     Text to replace matches with");
            Console.WriteLine("  -R, --recursive             Search subdirectories recursively");
            Console.WriteLine("  -c, --casesensitive         Case sensitive search");
            Console.WriteLine("  -t, --trim                  Trim whitespace from matches");
            Console.WriteLine("  -s, --script <file>         Path to replacement script (TSV or Pipe-separated)");
        }
    }
}
