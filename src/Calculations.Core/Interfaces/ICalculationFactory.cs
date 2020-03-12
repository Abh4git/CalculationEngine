using System;
using System.Collections.Generic;
using System.Text;
using Calculations.Core.Enums;
using Calculations.Core.Entities;
namespace Calculations.Core.Interfaces
{
    public interface  ICalculationFactory
    {
        ICalcuation GetCalculation(CalculationTypeEnum typeEnum, FinancialReturnInputs finROIInputs);
    }
}
