using System;
using System.Collections.Generic;
using System.Text;

namespace ComponentCouplingMetric.Core.Metrics
{
    public interface IComponentMetric<out TMetric>
    {
        TMetric CaculateMetric();
    }
}
