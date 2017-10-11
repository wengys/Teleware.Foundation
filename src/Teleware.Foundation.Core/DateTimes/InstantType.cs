namespace Teleware.Foundation.DateTimes
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释

    /// <summary>
    /// 时间点类型
    /// </summary>
    public enum InstantType
    {
        Jan = 1, Feb = 2, Mar = 3, Apr = 4, May = 5, Jun = 6, Jul = 7, Aug = 8, Sep = 9, Oct = 10, Nov = 11, Dec = 12,
        Q1 = 21, Q2 = 22, Q3 = 23, Q4 = 24,
        FirstHalfYear = 31, LastHalfYear = 32,
        FullYear = 91
    }

    /// <summary>
    /// 时间点类型组
    /// </summary>
    public enum InstantTypeGroup
    {
        Unknown = 0,
        Daily = 1,
        Monthy = 2,
        Quarterly = 3,
        HalfYearly = 4,
        Yearly = 5,
    }

#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
}