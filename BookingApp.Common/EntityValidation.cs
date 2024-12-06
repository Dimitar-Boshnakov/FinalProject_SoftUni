namespace BookingApp.Common
{
    public class EntityValidation
    {
        public class PropertyValidation
        {
            public const int PropertyNameMinLength = 2;
            public const int PropertyNameMaxLength = 80;

            public const int LocationMinLength = 3;
            public const int LocationMaxLength = 80;

            public const decimal PricePerNightMinValue = 0.0m;
            public const decimal PricePerNightMaxValue = decimal.MaxValue;

            public const int DescriptionMinLength = 0;
            public const int DescriptionMaxLength = 500; 
        }

        public class PaymentValidation
        {
            public const decimal TotalPriceMinValue = 0.0m;
            public const decimal TotalPriceMaxValue = decimal.MaxValue;
        }
    }
}
