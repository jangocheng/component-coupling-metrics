using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ComponentCouplingMetric.Test
{
    public class ComponentAbstractionMetricTest
    {
        [Fact]
        public void ComponentAbstractionMetric_NumberOfClassesAndIntercadesShouldHaveValue()
        {
            //Arrange
            const int numberClasses = 20;
            const int numberOfAbstractClasses = 13;
            const int numberOfInterfaces = 14;

            // Act
            ComponentAbstractionMetric abstractionMetric = new ComponentAbstractionMetric(numberClasses, numberOfAbstractClasses, numberOfInterfaces);

            //Assert
            Assert.Equal(numberClasses, abstractionMetric.NumberOfClasses);
            Assert.Equal(numberOfAbstractClasses, abstractionMetric.NumberOfAbstractClasses);
            Assert.Equal(numberOfInterfaces, abstractionMetric.NumberOfInterfaces);
        }

        [Fact]
        public void ComponentAbstractionMetric_PropertiesShouldBeGreaterThanZero()
        {
            // Arrange
            const int negativeParam = -1;
            const int positiveParam = 2;

            //Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => {
                ComponentAbstractionMetric abstractionMetric = new ComponentAbstractionMetric(negativeParam, positiveParam, positiveParam);
            });

            Assert.Throws<ArgumentOutOfRangeException>(() => {
                ComponentAbstractionMetric abstractionMetric = new ComponentAbstractionMetric(positiveParam, negativeParam, positiveParam);
            });

            Assert.Throws<ArgumentOutOfRangeException>(() => {
                ComponentAbstractionMetric abstractionMetric = new ComponentAbstractionMetric(positiveParam, positiveParam, negativeParam);
            });

            Assert.Throws<ArgumentOutOfRangeException>(() => {
                ComponentAbstractionMetric abstractionMetric = new ComponentAbstractionMetric(0, positiveParam, negativeParam);
            });
        }

        [Fact]
        public void ComponentAbstractionMetric_NumberOfClassesShouldBeEqualsOrGreaterThanAbstractClasses()
        {
            // Arrange
            const int numberClasses = 12;
            const int numberOfAbstractClasses = 13;
            const int numberOfInterfaces = 14;

            //Act and Assert
            Assert.Throws<ArgumentException>(() => {
                ComponentAbstractionMetric abstractionMetric = new ComponentAbstractionMetric(numberClasses, numberOfAbstractClasses, numberOfInterfaces);
            });
        }

        [Theory]
        [InlineData(1, 0, 0, 0.0)]
        [InlineData(2, 1, 1, 1.0)]
        [InlineData(1, 1, 0, 1.0)]
        [InlineData(10, 8, 0, 0.8)]
        [InlineData(10, 0, 2, 0.2)]
        [InlineData(20, 10, 2, 0.6)]
        public void ComponentAbstractionMetric_CalculateMetricShouldReturnCorrectValues(int numberOfClasses, int numberOfAbstractClasses, int numberOfInterfaces, double abstractness)
        {
            // Arrange
            ComponentAbstractionMetric abstractionMetric = new ComponentAbstractionMetric(numberOfClasses, numberOfAbstractClasses, numberOfInterfaces);

            // Act
            double result = abstractionMetric.CaculateMetric();

            // Arrange
            Assert.Equal(abstractness, result);
        }
    }
}
