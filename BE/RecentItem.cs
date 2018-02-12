using System;

namespace Aryes.BE
{
    /// <summary>
    /// 
    /// </summary>
    public class RecentItem : IComparable<RecentItem>
    {
        /// <summary>
        /// 
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime LastUsed { get; set; }

        /// <summary>
        /// Ordena descendentemente por fecha
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public int CompareTo(RecentItem o)
        {
            return o.LastUsed.CompareTo(LastUsed);
        }

    }
}
