using System;
using System.Collections.Generic;
using System.Text;
using Calculations.Core.Interfaces;
using Calculations.Core.Entities;
namespace CalculationEngine
{
    /// <summary>
    /// NPV Calculation. Net Present Value is calculated by
    /// this class. The Class takes InitalInvestment, DiscountRate, CashInFlow, 
    /// Numberof Years and based on these calculate NPV and placed in 
    /// Result  property. The class implements ICalculation interface.
    /// </summary>
    public class NPVCalculation : ICalcuation
    {
        private double _result;
        private double _initialInvestment;
        private double _discountRate;
        private double _cashInFlow;
        private double _numberofyears;
        private List<double> _cashInFlows;
                
        public NPVCalculation(double initalInvestment, double discountRate, double cashInFlow,  double numberOfYears)
        {
            _initialInvestment = initalInvestment;
            _discountRate = discountRate;
            _cashInFlow = cashInFlow;
            _numberofyears = numberOfYears;
        }

        public NPVCalculation(double initalInvestment, double discountRate, List<double> cashInFlows)
        {
            _initialInvestment = initalInvestment;
            _discountRate = discountRate;
            _cashInFlows = cashInFlows ;
            _numberofyears = cashInFlows.Count;
        }

        public NPVCalculation(FinancialReturnInputs finROIInputs)
        {
            _initialInvestment = finROIInputs.InitialInvestment;
            _discountRate = finROIInputs.DiscountRate;
            _cashInFlows = finROIInputs.CashInFlows;
            _cashInFlow = finROIInputs.FixedCashinFlow;
            if (!finROIInputs.IsCashinFlowFixed)
            {
                _numberofyears = _cashInFlows.Count;
            } else
            {
                _numberofyears = finROIInputs.NumberofYears;
            }
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
            if (_cashInFlows == null)
            {
                for (int i = 1; i <= _numberofyears; i++)
                {
                    denominator = Math.Pow((1 + _discountRate), i);
                    resultInital += nominator / denominator;
                }
            }
            else
            {
                for (int i = 1; i <= _numberofyears; i++)
                {
                    nominator = _cashInFlows[i - 1];
                    denominator = Math.Pow((1 + _discountRate), i);
                    resultInital += nominator / denominator;
                }
            }
            //double resultInital = nominator / denominator;
            npv = resultInital - _initialInvestment;
            _result = npv;
            return true;
        }
    }
}
