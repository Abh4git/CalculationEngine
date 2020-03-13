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
    /// Author: Abhilash
    /// </summary>
    public class IRRCalculation : ICalcuation
    {
        private double _result;
        private double _initialInvestment;
        private double _mindiscountRate;
        private double _maxdiscountRate;
        private double _cashInFlow;
        private List<double> _cashInFlows;
        private double _numberofyears;

        public IRRCalculation(double initalInvestment, double initialdiscountRate, double maxdiscountRate,double cashInFlow, double numberOfYears)
        {
            _initialInvestment = initalInvestment;
            _mindiscountRate = initialdiscountRate;
            _maxdiscountRate = maxdiscountRate;
            _cashInFlow = cashInFlow;
            _numberofyears = numberOfYears;
        }
        public IRRCalculation(double initalInvestment, double initialdiscountRate, double maxdiscountRate, List<double> cashInFlows)
        {
            _initialInvestment = initalInvestment;
            _mindiscountRate = initialdiscountRate;
            _maxdiscountRate = maxdiscountRate;
            _cashInFlows = cashInFlows;
            _numberofyears = cashInFlows.Count ;
        }

        public IRRCalculation(FinancialReturnInputs finROIInputs)
        {
            _initialInvestment = finROIInputs.InitialInvestment;
            _mindiscountRate = finROIInputs.DiscountRate;
            _maxdiscountRate = finROIInputs.MaxDiscountRate;
            _cashInFlows = finROIInputs.CashInFlows;
            if (_cashInFlows != null)
            {
                _numberofyears = _cashInFlows.Count;
            }
            else
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
            double npv = -1;
            double discountRate=0;
            for (double i = _mindiscountRate; i <= _maxdiscountRate; i=i+.05)
            {
                npv = CalculateNPV(i);
                if (npv <= 0)
                {
                    discountRate = i;
                    break;
                }
            }
            //double resultInital = nominator / denominator;
            _result = discountRate;
            return true;
        }
        public double CalculateNPV(double currentDiscountrate)
        {

            double npv = 0;
            double nominator = _cashInFlow;
            double denominator = 1;
            double resultInital = 0;

            if (_cashInFlows==null)
            { 
                for (int i = 1; i <= _numberofyears; i++)
                {
                    denominator = Math.Pow((1 + currentDiscountrate), i);
                    resultInital += nominator / denominator;
                }
            } else
            {
                for (int i = 1; i <= _numberofyears; i++)
                {
                    nominator = _cashInFlows[i - 1];
                    denominator = Math.Pow((1 + currentDiscountrate), i);
                    resultInital += nominator / denominator;
                }
            }

            //double resultInital = nominator / denominator;
            npv = resultInital - _initialInvestment;
            return npv;
        }
    }
}
