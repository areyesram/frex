using System;

namespace Aryes.Helper
{
    /// <summary>
    /// 
    /// </summary>
    internal static class Config
    {
        /// <summary>
        /// Adds a recent item to a list.
        /// </summary>
        /// <param name="list">The list of items.</param>
        /// <param name="value">The value to be added.</param>
        /// <returns></returns>
        internal static BE.RecentList AddRecent(BE.RecentList list, string value)
        {
            if (list == null)
                list = new BE.RecentList();

            var item = list.Find(o => o.Value.CompareTo(value) == 0);
            if (item == null)
                list.Add(new BE.RecentItem { Value = value, LastUsed = DateTime.Now });
            else
                item.LastUsed = DateTime.Now;

            list.Sort();

            return list;
        }
    }
}
