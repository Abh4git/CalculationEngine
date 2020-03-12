using System;
using System.Collections.Generic;
using System.Text;
using Calculations.Core.Interfaces;
using Calculations.Core.Enums;
using Calculations.Core.Entities;

namespace CalculationEngine
{
    public class CalculationFactory : ICalculationFactory
    {
        private ICalcuation _calculation;
        public ICalcuation GetCalculation(CalculationTypeEnum typeEnum, FinancialReturnInputs finROIInputs )
        {
            
            switch (typeEnum)
            {
                case CalculationTypeEnum.NPV:
                    _calculation = new NPVCalculation(finROIInputs);
                    break;
                case CalculationTypeEnum.IRR:
                    _calculation = new IRRCalculation(finROIInputs);
                    break;
                case CalculationTypeEnum.Other:
                    break;
                default:
                    break;

            }
            return _calculation;
        }
    }
}
