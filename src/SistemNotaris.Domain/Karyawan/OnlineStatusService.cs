namespace SistemNotaris.Domain.Karyawan;

public class OnlineStatusService
{
    public static string GetOnlineStatus(Karyawans karyawan)
    {
        var lastLogin = karyawan.LoginStatus.LastOnline;
        var currentTime = DateTime.Now;
        var timeDifference = currentTime - lastLogin;
        var status = "";
        if (timeDifference.TotalMinutes < 1)
            status = "Baru Saja Aktif";
        else if (timeDifference.TotalMinutes < 60)
            status = "Last seen {Math.Floor(timeDifference.TotalMinutes)} minutes ago";
        else if (timeDifference.TotalHours < 24)
            status = $"Last seen {Math.Floor(timeDifference.TotalHours)} hours ago";
        else if (timeDifference.TotalDays < 7)
            status = $"Last seen {Math.Floor(timeDifference.TotalDays)} Hari Yang Lalu";
        return status;
    }
}