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
        bool VerifyTrapezoidProbability(int a, int b, int c, int d);
        void ModelLastTrapezoidSide(int a, int b, int c, out int d);
    }
}
