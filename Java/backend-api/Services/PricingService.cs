using System;
using BackendApi.Models;

namespace BackendApi.Services
{
    public interface IPricingService
    {
        decimal CalculatePrice(int sanId, DateTime bookingDate, TimeSpan startTime);
        decimal ApplyDynamicPricing(decimal basePrice, DateTime dateTime);
    }

    public class PricingService : IPricingService
    {
        // Calculate price based on base price, time of day, and day of week
        public decimal CalculatePrice(int sanId, DateTime bookingDate, TimeSpan startTime)
        {
            decimal basePrice = GetBasePrice(sanId);
            decimal dynamicPrice = ApplyDynamicPricing(basePrice, bookingDate);
            decimal timeBasedPrice = ApplyTimeMultiplier(dynamicPrice, startTime);

            return timeBasedPrice;
        }

        // Dynamic pricing based on demand and day
        public decimal ApplyDynamicPricing(decimal basePrice, DateTime dateTime)
        {
            var dayOfWeek = dateTime.DayOfWeek;
            var multiplier = 1.0m;

            // Weekend pricing
            if (dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday)
            {
                multiplier = 1.2m;
            }

            // Holiday pricing
            if (IsHoliday(dateTime))
            {
                multiplier = 1.5m;
            }

            return basePrice * multiplier;
        }

        // Price multiplier based on time of day
        private decimal ApplyTimeMultiplier(decimal price, TimeSpan startTime)
        {
            if (startTime.Hours >= 18 && startTime.Hours < 22)
            {
                return price * 1.3m; // Peak hours
            }
            else if (startTime.Hours >= 22)
            {
                return price * 1.5m; // Late night
            }

            return price;
        }

        private decimal GetBasePrice(int sanId)
        {
            // Get base price from database
            return 100000; // Default VND
        }

        private bool IsHoliday(DateTime date)
        {
            // Check if date is a public holiday
            return false;
        }
    }
}
