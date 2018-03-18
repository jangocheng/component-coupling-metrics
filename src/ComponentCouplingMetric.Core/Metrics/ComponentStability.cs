using System;
using System.Collections.Generic;
using System.Text;

namespace ComponentCouplingMetric.Core.Metrics
{
    public class ComponentStability
    {
        public ComponentStability(int incomingDependencies, int outgoingDepencendies)
        {
            if (incomingDependencies < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(incomingDependencies), incomingDependencies, nameof(incomingDependencies));
            }

            if (outgoingDepencendies < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(outgoingDepencendies), outgoingDepencendies, nameof(outgoingDepencendies));
            }

            IncomingDependencies = incomingDependencies;
            OutgoingDepencendies = outgoingDepencendies;
        }

        public int IncomingDependencies { get; private set; }
        public int OutgoingDepencendies { get; private set; }

        public double GetInstability()
        {
            var result = (double)OutgoingDepencendies / ((double)IncomingDependencies + OutgoingDepencendies);

            return Math.Round(result, 2);
        }
    }
}
