using System;
using System.Collections.Generic;
using System.Text;

namespace CalculationEngine
{
    /// <summary>
    /// NPV Calculation. Net Present Value is calculated by
    /// this class. The Class takes InitalInvestment, DiscountRate, CashInFlow, 
    /// Numberof Years and based on these calculate NPV and placed in 
    /// Result  property. The class implements ICalculation interface.
    /// </summary>
    class NPVCalculation : ICalcuation
    {
        private double _result;
        private double _initialInvestment;
        private double _discountRate;
        private double _cashInFlow;
        private double _numberofyears;
                
        public NPVCalculation(double initalInvestment, double discountRate, double cashInFlow,  double numberOfYears)
        {
            _initialInvestment = initalInvestment;
            _discountRate = discountRate;
            _cashInFlow = cashInFlow;
            _numberofyears = numberOfYears;
        }
        public double Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
            }
        }

        public bool Execute()
        {
            double npv = 0;
            double nominator = _cashInFlow;
            double denominator = 1; 
            double resultInital = 0;
            for (int i=1; i<=_numberofyears; i++)
            {
                denominator = Math.Pow((1 + _discountRate), i);
                resultInital += nominator / denominator;
            }
            //double resultInital = nominator / denominator;
            npv = resultInital - _initialInvestment;
            _result = npv;
            return true;
        }
    }
}
