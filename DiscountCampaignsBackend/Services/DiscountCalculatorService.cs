using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DiscountCampaignsBackend.Services
{
    public class DiscountCalculator
    {
        private readonly IEnumerable<IDiscountCategory> _discountSteps;

        public DiscountCalculator(IEnumerable<IDiscountCategory> discountSteps)
        {
            _discountSteps = discountSteps;
        }

        public decimal CalculateTotal(DiscountRequestDto request)
        {
            decimal originalTotal = request.SelectedProduct.Sum(p => p.Product.Price * p.Quantity);
            decimal currentTotal = originalTotal;

            foreach (var step in _discountSteps)
            {
                currentTotal = step.Apply(currentTotal, request);
            }

            return currentTotal;
        }
    }
}
