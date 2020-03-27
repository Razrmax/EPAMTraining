using System;
using System.Collections.Generic;
using System.Text;

namespace TrapezoidShape.model
{
    /// <summary>
    /// Methods for verification of the Trapezoid's probability of existence based on its shape type
    /// </summary>
    interface IVerifyTrapezoidProbability
    {
        bool VerifyTrapezoidProbability();
        void ModelLastTrapezoidSide(out double d);
    }
}
