namespace SistemNotaris.Domain.Karyawan;

public sealed record LoginStatus
{
    public bool IsOnline { get; init; }
    public DateTime LastOnline { get; init; }

    public static LoginStatus Create()
    {
        return new LoginStatus
        {
            IsOnline = false,
            LastOnline = DateTime.MinValue
        };
    }

    public LoginStatus SetOnline(DateTime lastOnline, bool isOnline = true)
    {
        return this with
        {
            IsOnline = isOnline,
            LastOnline = lastOnline
        };
    }
}