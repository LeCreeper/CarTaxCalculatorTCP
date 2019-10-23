using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tax;

namespace TaxTest
{
    [TestClass]
    public class UnitTest1
    {

        CarFeeClass carFeeClass = new CarFeeClass();

        [TestMethod]
        public void CarFeeWithNegativePrice()
        {
            //Arrange
            double price = -8000;

            //Act
            try
            {
                carFeeClass.CarFee(price);

                //Assert
                Assert.Fail();
                
            }
            catch (ArgumentOutOfRangeException e)
            {
                
                
            }
            
        }

        [TestMethod]
        public void CarFeeWithPriceOver200000()
        {

            //Arrange
            double price = 210000;

            //Act
            double expectedFee = 185000;
            double actualFee = carFeeClass.CarFee(price);

            //Assert
            Assert.AreEqual(expectedFee, actualFee);
        }

        [TestMethod]
        public void CarFeeWithPriceUnder200000()
        {
            //Arrange
            double price = 190000;

            //Act
            double expectedFee = 161500;
            double actualFee = carFeeClass.CarFee(price);

            //Assert
            Assert.AreEqual(expectedFee, actualFee);


        }

        [TestMethod]
        public void ElectricCarFeeWithNegativePrice()
        {

            //Arrange 
            double price = -80000;

            //Act
            try
            {

                carFeeClass.ElectricCarFee(price);

                //Assert
                Assert.Fail();

            }
            catch (ArgumentOutOfRangeException e)
            {
                
            }
        }

        [TestMethod]
        public void ElectricCarFeeWithPriceOver200000()
        {
            //Arrange
            double price = 210000;

            //Act
            double expectedFee = 37000;
            double actualFee = carFeeClass.ElectricCarFee(price);

            //Assert
            Assert.AreEqual(expectedFee, actualFee);
        }

        
    }
}
