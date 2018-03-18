using System;
using ComponentCouplingMetric.Core.Metrics;

namespace ComponentCouplingMetric
{
    public class ComponentStabilityMetric : IComponentMetric<double>
    {
        public ComponentStabilityMetric(int incomingDependencies, int outgoingDepencendies)
        {
            if (incomingDependencies < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(incomingDependencies), incomingDependencies, nameof(incomingDependencies));
            }

            if (outgoingDepencendies < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(outgoingDepencendies), outgoingDepencendies, nameof(outgoingDepencendies));
            }

            if (outgoingDepencendies == 0 && incomingDependencies == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(outgoingDepencendies) + nameof(incomingDependencies), outgoingDepencendies, message: "Both parameter are 0");
            }

            IncomingDependencies = incomingDependencies;
            OutgoingDepencendies = outgoingDepencendies;
        }

        public int IncomingDependencies { get; private set; }
        public int OutgoingDepencendies { get; private set; }

        public double CaculateMetric()
        {
            var result = (double)OutgoingDepencendies / ((double)IncomingDependencies + OutgoingDepencendies);

            return Math.Round(result, 2);
        }
    }
}
