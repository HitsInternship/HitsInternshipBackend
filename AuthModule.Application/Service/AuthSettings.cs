namespace AuthModel.Service.Service;

public class AuthSettings
{
    public static string PrivateKey = Environment.GetEnvironmentVariable("Key");
    public static DateTime GetTokenExpires()
    {
        return DateTime.UtcNow.AddDays(1);
    }
}