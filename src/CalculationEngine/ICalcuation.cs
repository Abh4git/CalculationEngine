using System;
using System.Collections.Generic;
using System.Text;

namespace CalculationEngine
{
    /// <summary>
    /// Interface for Calculations
    /// </summary>
    public interface ICalcuation
    {
        double Result { get; set; }
        
        bool Execute();


    }
}
