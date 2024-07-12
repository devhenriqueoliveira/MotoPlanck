namespace MotoPlanck.Domain.Utils
{
    public class JwtSettings
    {
        public string Key { get; set; } = string.Empty;
        public string GetKey() => Key;
    }
}
