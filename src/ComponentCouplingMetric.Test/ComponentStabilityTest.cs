using ComponentCouplingMetric.Core.Metrics;
using System;
using Xunit;

namespace ComponentCouplingMetric.Test
{
    public class ComponentStabilityTest
    {
        [Fact]
        public void ComponentStatiblity_IncomingDependenciesShouldHaveCorretValue()
        {
            // Arrange
            const int incomingDependencies = 1;
            const int outgoingDepencendies = 2;

            //Act
            ComponentStability stability = new ComponentStability(incomingDependencies, outgoingDepencendies);

            //Assert
            Assert.Equal(incomingDependencies, stability.IncomingDependencies);
            Assert.Equal(outgoingDepencendies, stability.OutgoingDepencendies);
        }

        [Fact]
        public void ComponentStatiblity_IncomingAndOutgoingShouldBeGreaterThanZero()
        {
            // Arrange
            const int negativeParam = -1;
            const int positiveParam = 2;

            //Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => {
                ComponentStability stability = new ComponentStability(negativeParam, positiveParam);
            });

            Assert.Throws<ArgumentOutOfRangeException>(() => {
                ComponentStability stability = new ComponentStability(positiveParam, negativeParam);
            });
        }

        [Theory]
        [InlineData(0, 3, 1)]
        [InlineData(3, 0, 0)]
        [InlineData(3, 3, 0.5)]
        [InlineData(2, 3, 0.6)]
        [InlineData(3, 2, 0.4)]
        [InlineData(10, 20, 0.67)]
        [InlineData(555, 666, 0.55)]
        public void ComponentStatiblity_InstabilityShouldHaveCorrectValues(int incoming, int outgoing, double instability)
        {
            // Arrange
            ComponentStability stability = new ComponentStability(incoming, outgoing);

            // Act
            double result = stability.GetInstability();

            // Assert
            Assert.Equal(instability, result);
        }

        [Theory]
        [InlineData(2, 3)]
        [InlineData(3, 2)]
        [InlineData(20, 30)]
        [InlineData(30, 20)]
        public void ComponentStatiblity_CheckInstabilityValueGreaterThanZeroLessThanOne(int incoming, int outgoing)
        {
            // Arrange
            ComponentStability stability = new ComponentStability(incoming, outgoing);

            // Act
            double result = stability.GetInstability();

            // Assert
            Assert.InRange(result, 0, 1);
        }
    }
}
