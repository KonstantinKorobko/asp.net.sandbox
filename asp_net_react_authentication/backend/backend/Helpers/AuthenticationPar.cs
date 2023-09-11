namespace backend.Helpers
{
    public class AuthenticationPar
    {
        public const string Authentication = "Authentication";

        public string Issuer { get; set; } = String.Empty;
        public string Audience { get; set; } = String.Empty;
        public string IssuerSigningKey { get; set; } = String.Empty;
        public string JWTExpire { get; set; } = String.Empty;
    }
}
