using System;
using System.Collections.Generic;
using System.Text;

namespace Calculations.Core.Entities
{
    public class FinancialReturnInputs
    {
        public double InitialInvestment 
        { get; set;}
        public double DiscountRate
        { get; set; }

        public double FixedCashinFlow
        { get; set; }

        public bool IsCashinFlowFixed
        { get; set; }

        public double MaxDiscountRate
        { get; set; }

        public double NumberofYears
        { get; set; }
        public List<double> CashInFlows
        { get; set; }
    }

}
