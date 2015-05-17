using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace STVM.Helper
{
    /// <summary>
    /// Contains approximate string matching
    /// </summary>
    static class LevenshteinDistance
    {
        /// <summary>
        /// Compute the distance between two strings in percent of the longer string.
        /// </summary>
        public static float Percent(string s, string t)
        {
            int dist = LevenshteinDistance.Compute(s, t);
            float percent = 1 - (float)dist / (float)Math.Max(s.Length, t.Length);
            return percent;
        }

        /// <summary>
        /// Accept two strings with threshold but minimum 5 identical characters
        /// </summary>
        public static bool Accept(string s, string t, float Threshold)
        {
            int dist = LevenshteinDistance.Compute(s, t);
            float percent = 1 - (float)dist / (float)Math.Max(s.Length, t.Length);
            return ((dist <= 5) & (percent >= Threshold));
        }

        /// <summary>
        /// Compute the distance between two strings.
        /// </summary>
        public static int Compute(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }
    }

    static class DirectoryHelper
    {
        public static string GetRealPath(string path)
        {
            if (string.IsNullOrEmpty(path)) { return path; }
            else
            {
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                DirectoryInfo parentDirInfo = dirInfo.Parent;

                if (parentDirInfo == null)
                {
                    return dirInfo.Name;
                }
                else
                {
                    string realDirName;
                    if (Directory.Exists(path))
                        realDirName = parentDirInfo.GetDirectories(dirInfo.Name)[0].Name;
                    else
                        realDirName = Path.GetFileName(path);

                    return Path.Combine(GetRealPath(parentDirInfo.FullName), realDirName);
                }
            }
        }
    }

    static class FileEx
    {
        public static void Move(string sourceFileName, string destFileName, bool Replace)
        {
            if (File.Exists(destFileName))
                if (Replace) { File.Delete(destFileName); }
                else
                {
                    int i = 0;
                    while (File.Exists(destFileName + i.ToString())) { i++; }
                    destFileName = destFileName + i.ToString();
                }
            File.Move(sourceFileName, destFileName);
        }

        public static bool Move(string sourceFileName, string destFileName, string MessageTitle)
        {
            if (!File.Exists(destFileName) ||
                MessageBox.Show("Datei " + destFileName + " ist bereits vorhanden.\r\nSoll die Datei ersetzt werden?", MessageTitle,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                File.Delete(destFileName);
                File.Move(sourceFileName, destFileName);
                return true;
            }
            else return false;
        }
    }


}