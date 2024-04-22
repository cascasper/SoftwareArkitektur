public class DummyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    // Antag at disse er hash-værdierne for "password123" og "cake123"
    private const string Password123Hash = "hash_for_password123";
    private const string Cake123Hash = "hash_for_cake123";

    // ... Resten af klassen ...

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        // ... Kode for at hente Authorization header ...

        if (authHeader != null && authHeader.StartsWith("Password", StringComparison.OrdinalIgnoreCase))
        {
            var password = authHeader.Substring("Password ".Length).Trim();
            var passwordHash = ComputeHash(password); // Antag at ComputeHash er en metode til at generere hashen

            if (passwordHash == Password123Hash)
            {
                // ... Opret ClaimsPrincipal for "Admin" ...
            }
            else if (passwordHash == Cake123Hash)
            {
                // ... Opret ClaimsPrincipal for "CakeLover" ...
            }
        }

        // ... Resten af koden ...
    }

    private string ComputeHash(string password)
    {
        // Implementer logikken til at generere hash-værdien her
        // I en rigtig applikation bør du bruge en sikker hash-funktion og en salt
    }
}
