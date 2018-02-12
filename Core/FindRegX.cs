using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Aryes.Core
{
    /// <summary>
    /// This is the description.
    /// </summary>
    public static class FindRegX
    {
        /// <summary>
        /// 
        /// </summary>
        internal static BE.ReplacementInfo[] Replacements { get; set; }

        /// <summary>
        /// 
        /// </summary>
        internal static int Matches { get; private set; }

        private static string _pattern = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        internal static string Pattern
        {
            set
            {
                _pattern = string.IsNullOrEmpty(value) ? "*" : value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal static bool Recursive { private get; set; }

        private static Regex _regex;
        /// <summary>
        /// 
        /// </summary>
        internal static string Regex
        {
            set
            {
                var regexOptions = RegexOptions.Compiled | RegexOptions.Singleline;
                if (!CaseSensitive)
                    regexOptions |= RegexOptions.IgnoreCase;
                _regex = new Regex(value, regexOptions);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal static string Replace { private get; set; }

        /// <summary>
        /// 
        /// </summary>
        internal static bool Trim { private get; set; }

        private static Hashtable _results;
        /// <summary>
        /// 
        /// </summary>
        internal static string[] Results
        {
            get
            {
                var array = new string[_results.Count];
                _results.Values.CopyTo(array, 0);
                return array;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal static bool CaseSensitive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public enum FailReason
        {
            /// <summary>
            /// 
            /// </summary>
            None,
            /// <summary>
            /// 
            /// </summary>
            Binary,
            /// <summary>
            /// 
            /// </summary>
            TooBig
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="r"></param>
        public delegate void TraverseEventHandler(string file, FailReason r);

        /// <summary>
        /// 
        /// </summary>
        public static event TraverseEventHandler FileProcessed = null;

        /// <summary>
        /// 
        /// </summary>
        public static event TraverseEventHandler FileSkipped = null;

        /// <summary></summary>
        /// <param name="path"></param>
        /// <param name="clearResults"> </param>
        internal static void Start(string path, bool clearResults)
        {
            Matches = 0;
            if (_results == null || clearResults)
                _results = new Hashtable();
            _basePath = path;
            StartInternal(path);
        }

        private static void StartInternal(string path)
        {
            IEnumerable<string> files;
            try
            {
                files = Directory.EnumerateFiles(path, _pattern);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}: {1}", path, ex.Message);
                return;
            }
            foreach (var file in files)
            {
                var dir = ".\\" + (Path.GetDirectoryName(file) ?? string.Empty).Replace(_basePath, string.Empty);
                try
                {
                    if (FileIsBinary(file))
                    {
                        if (FileSkipped != null)
                            FileSkipped(file, FailReason.Binary);
                    }
                    else if (FileTooBig(file))
                    {
                        if (FileSkipped != null)
                            FileSkipped(file, FailReason.TooBig);
                    }
                    else
                    {
                        var reader = File.OpenText(file);
                        foreach (Match match in _regex.Matches(reader.ReadToEnd()))
                        {
                            var s = match.Value;
                            if (Replace.Length != 0)
                                s = _regex.Replace(s, Replace);

                            s = s.Replace("$p", file);
                            s = s.Replace("$n", Path.GetFileNameWithoutExtension(file));
                            s = s.Replace("$f", Path.GetFileName(file));
                            s = s.Replace("$d", dir);
                            s = s.Replace("$x", Path.GetExtension(file));

                            foreach (var info in Replacements)
                                s = s.Replace(info.TextToFind, info.ReplaceWith);

                            if (Trim)
                                s = s.Trim();

                            if (!_results.ContainsValue(s))
                            {
                                _results.Add(s, s);
                                Matches++;
                            }
                        }
                        reader.Close();
                        if (FileProcessed != null)
                            FileProcessed(file, FailReason.None);
                        Application.DoEvents();
                    }

                    Application.DoEvents();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0}: {1}", file, ex.Message);
                }
            }
            if (!Recursive) return;
            try
            {
                foreach (var dir in Directory.EnumerateDirectories(path))
                    StartInternal(dir);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}: {1}", path, ex.Message);
            }
        }

        private static bool FileTooBig(string file)
        {
            var fi = new FileInfo(file);
            return fi.Length > Settings.Default.MaxFileSize;
        }

        const int BufLen = 512;

        private static readonly byte[] Buffer = new byte[BufLen];
        private static FileStream _stream;
        private static string _basePath;
        //private static string _dirFilter;

        static FindRegX()
        {
            Trim = false;
            Replace = null;
            Replacements = new BE.ReplacementInfo[0];
            Matches = 0;
        }

        private static bool FileIsBinary(string file)
        {
            try
            {
                _stream = File.OpenRead(file);
                var n = _stream.Read(Buffer, 0, BufLen);
                var minPrn = n * 70 / 100;  // ~70%
                _stream.Close();
                var m = 0;
                for (var i = 0; i < n; i++)
                {
                    var c = Buffer[i];
                    if (c == 0)
                        return true;
                    if ((c == '\n') || (c == '\r') || ((c >= ' ') && (c <= 'z')))
                        m++;
                }
                return m < minPrn;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
