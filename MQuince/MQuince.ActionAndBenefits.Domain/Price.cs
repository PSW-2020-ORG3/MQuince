using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.ActionAndBenefits.Domain
{
	public class Price
	{
		public double OldPrice { get; private set; }
		public double NewPrice { get; private set; }
		public Price(double oldPrice, double newPrice)
		{
			OldPrice = oldPrice;
			NewPrice = newPrice;
			Validate();
		}
		private void Validate()
		{	
			if (OldPrice < 0 || NewPrice < 0)
				throw new ArgumentOutOfRangeException("Price can't be negative!");
			else if (OldPrice < NewPrice)
				throw new ArgumentOutOfRangeException("New price can't be greater then old price!");
		}
	}
}
