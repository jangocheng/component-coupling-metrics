using ComponentCouplingMetric.Core.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComponentCouplingMetric
{
    public class ComponentAbstractionMetric : IComponentMetric<double>
    {
        public ComponentAbstractionMetric(int numberOfClasses, int numberOfAbstractClasses, int numberOfInterfaces)
        {
            if (numberOfClasses <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfClasses), numberOfClasses, nameof(numberOfClasses));
            }

            if (numberOfAbstractClasses < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfAbstractClasses), numberOfAbstractClasses, nameof(numberOfAbstractClasses));
            }

            if (numberOfInterfaces < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfInterfaces), numberOfInterfaces, nameof(numberOfInterfaces));
            }

            if (numberOfClasses < numberOfAbstractClasses)
            {
                throw new ArgumentException("Number of classes should be enquals or greather than number of abstract classes");
            }

            NumberOfClasses = numberOfClasses;
            NumberOfAbstractClasses = numberOfAbstractClasses;
            NumberOfInterfaces = numberOfInterfaces;
        }

        public int NumberOfClasses { get; set; }
        public int NumberOfAbstractClasses { get; set; }
        public int NumberOfInterfaces { get; set; }

        public double CaculateMetric()
        {
            var result = (NumberOfAbstractClasses + NumberOfInterfaces) / (double)NumberOfClasses;

            return Math.Round(result, 2);
        }
    }
}
