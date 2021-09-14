using System;
using Xunit;
using CarsLib;

namespace CarsTests
{
    public class AccelTest
    {   
        Car testCar;
        Car MovingCar;
        public cartest(){
            testCar = new car('GAS-100', 'Toyota', 'AE86',1983, 0)
            MovingCar = new car('SJP-888','Pontiac','Trans Am2000',3000,150)
        }


    

        [Theory]
        [InlineData(1,1)]
        [InlineData(-1,1)]
        [InlineData(151,150)]
        [InlineData(1000000,150)]
        [InlineData(-1000000,150)]
        [InlineData(130,130)]

        public void IncreaseSpeedtest(int input, int expected)
        {
            this.testCar.IncreaseSpeed(input)
            Assert.Equal(expected, this.testCar.Speed)
        }

        [Theory]
        [InlineData(10, 140)]
        [InlineData(0, 150)]
        [InlineData(-10, 140)]
        [InlineData(500, 0)]
        [InlineData(150, 0)]
        public void DecreaseSpeedTest(int expected, int input)
        {
        this.MovingCar.DecreaseSpeed(input);
        Assert.Equal(expected, this.MovingCar.Speed);
        }

        [Fact]
        public void GetageTest()
        {
            int output = this.testCar.GetAge()
            Assert.Equal((DateTime.Now.Year-1983), output)
        }
    }
}
