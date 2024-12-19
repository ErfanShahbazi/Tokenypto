namespace Tokenypto.Api.Entities
{
    public record Currency
    {
        internal static readonly Currency None = new("");

        public static readonly Currency UnitedStatesDollar = new("USD");
        public static readonly Currency AustralianDollar = new("AUD");
        public static readonly Currency Euro = new("EUR");
        public static readonly Currency BrazilianReal = new("BRL");
        public static readonly Currency BritishPound = new("GBP");

        private Currency(string sign) => Sign = sign;

        public string Sign { get; init; }

        public static Currency FromCode(string code)
        {
            return All.FirstOrDefault(x => x.Sign.ToLower() == code.ToLower()) ??
                throw new ApplicationException("The currency code is invalid");
        }

        public static readonly IReadOnlyCollection<Currency> All = new[]
        {
            UnitedStatesDollar,
            AustralianDollar,
            Euro,
            BrazilianReal,
            BritishPound,
        };
    }
}