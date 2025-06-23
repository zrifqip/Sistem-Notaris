namespace SistemNotaris.Domain.Karyawan;

public class OnlineStatusService
{
    public static string GetOnlineStatus(Karyawans karyawan)
    {
        var lastLogin = karyawan.LoginStatus.LastOnline;
        var currentTime = DateTime.Now;
        var timeDifference = currentTime - lastLogin;
        var status = "";
        // Beberapa detik yang lalu
        if (timeDifference.TotalMinutes < 1)
            status = "Baru Saja Aktif";
        // Beberapa Menit yang lalu
        else if (timeDifference.TotalMinutes < 60)
            status = "Last seen {Math.Floor(timeDifference.TotalMinutes)} minutes ago";
        // Beberapa Jam yang lalu
        else if (timeDifference.TotalHours < 24)
            status = $"Last seen {Math.Floor(timeDifference.TotalHours)} hours ago";
        // Beberapa Hari yang lalu
        else
            status = $"Last seen {Math.Floor(timeDifference.TotalDays)} Hari Yang Lalu";
        return status;
    }
}