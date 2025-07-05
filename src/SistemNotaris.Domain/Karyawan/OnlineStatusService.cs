using MediatR;

namespace SistemNotaris.Domain.Karyawan;

public class OnlineStatusService
{
    public static string GetOnlineStatus(Karyawans karyawan)
    {
        var lastLogin = karyawan.LoginStatus.LastOnline;
        var currentTime = DateTime.Now;
        var timeDifference = currentTime - lastLogin;
        var status = "Last seen ";
        if (timeDifference.TotalMinutes < 1)
            status = "Baru Saja Aktif";
        else if (timeDifference.TotalMinutes < 60)
            status += GetMinutes((int)timeDifference.TotalMinutes);
        else if (timeDifference.TotalHours < 24) 
            status += GetHours((int)timeDifference.TotalHours);
        else
            status += GetDays((int)timeDifference.TotalDays);
        return status;
    }
    private static string GetDays(int days)
    {
        if (days == 1) return "Kemarin";
        return $"{days} hari yang lalu";
    }
    private static string GetHours(int hours)
    {
        return $"{hours} Jam Yang Lalu";
    }
    private static string GetMinutes(int minutes)
    {
        return $"{minutes} Menit Yang Lalu";
    }
}