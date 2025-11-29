using UnityEngine;
using System;

public static class UnixTime
{
    // Mốc thời gian Unix (01/01/1970 UTC)
    private static readonly DateTimeOffset UnixEpoch = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);

    // Hàm này lấy thời gian hiện tại (UTC), trừ đi mốc Unix 1970, và chuyển số ticks thu được sang microseconds bằng cách chia cho 10
    public static long GetUnixTimeMicro()
    {
        TimeSpan duration = DateTimeOffset.UtcNow - UnixEpoch;
        return duration.Ticks/10;
    }

    // Tính thời gian đã trôi qua (giây) bằng cách chi cho float 1000000 tức 10^6 ứng với đơn vị microsecond sẽ ra second
    public static float GetTimeDiffToNow(long startMicro)
    {
        long nowMicro = GetUnixTimeMicro();
        return (nowMicro - startMicro) / 1_000_000f;
    }
}

