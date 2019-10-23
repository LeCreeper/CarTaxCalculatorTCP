using System;

namespace Tax
{
    public class CarFeeClass
    {
        /// <summary>
        /// This method returns the fee of a car, based upon the Price parameter. If Price is negative, an exception is thrown. 
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public double CarFee(double price)
        {
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (price <= 200000)
            {
                return (price * 0.85);
            }

            return (price * 1.50 - 130000);
            
            
        }

        /// <summary>
        /// This method returns the fee of an electric car, using the Carfee method, the Price parameter and multiplying it with 0.20. If Price is negative, an exception is thrown.
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public double ElectricCarFee(double price)
        {
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return CarFee(price) * 0.20;
        }

    }
}
