using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using CalculationEngine;

namespace CalculationEngineUnitTests
{
    [TestClass]
    public class UnitTestCalculations
    {
        [TestMethod]
        public void TestNPVCalculationFixedCashFlow()
        {
            double initialInvst = 10000;
            double discountRate = .1;
            double yearlycashIn = 3000;
            double noofYears = 5;
            ///Initailizing NPVCalculation class with the parameters of Initail investment, discountrate, yearly cash flow, number of years
            ///then the Execute method is called and result is found in Result property of the class.
            ICalcuation calcuationNPV = new NPVCalculation(initialInvst, discountRate, yearlycashIn, noofYears);
            bool executed = calcuationNPV.Execute();
            Assert.AreEqual( calcuationNPV.Result, 1372.36,2);

        }

        [TestMethod]
        public void TestNPVCalculationDynamicCashFlow()
        {
            double initialInvst = 200000;
            double discountRate = .04;
          
            List<double> yearlyCashFlows = new List<double>();
            yearlyCashFlows.Add(50000);
            yearlyCashFlows.Add(50000);
            yearlyCashFlows.Add(50000);
            yearlyCashFlows.Add(50000);
            yearlyCashFlows.Add(50000);

            yearlyCashFlows.Add(45000);
            yearlyCashFlows.Add(45000);
            yearlyCashFlows.Add(45000);
            yearlyCashFlows.Add(45000);
            yearlyCashFlows.Add(45000);


            ///Initailizing NPVCalculation class with the parameters of Initail investment, discountrate, yearly cash flow, number of years
            ///then the Execute method is called and result is found in Result property of the class.
            ICalcuation calcuationNPV = new NPVCalculation(initialInvst, discountRate, yearlyCashFlows);
            bool executed = calcuationNPV.Execute();
            Assert.AreEqual(calcuationNPV.Result, 187249.42, 2);

        }

        [TestMethod]
        public void TestIRRCalculationDynamicCashFlow()
        {
            double initialInvst = 500000;
            double discountRate = 0.1;
            double maxdiscountRate = .9;


            List<double> yearlyCashFlows = new List<double>();
            yearlyCashFlows.Add(160000);
            yearlyCashFlows.Add(160000);
            yearlyCashFlows.Add(160000);
            yearlyCashFlows.Add(160000);
            yearlyCashFlows.Add(50000);

 


            ///Initailizing NPVCalculation class with the parameters of Initail investment, discountrate, yearly cash flow, number of years
            ///then the Execute method is called and result is found in Result property of the class.
            ICalcuation calculationIRR = new IRRCalculation(initialInvst, discountRate, maxdiscountRate, yearlyCashFlows);
            bool executed = calculationIRR.Execute();
            Assert.AreEqual(calculationIRR.Result, .13, 2);

        }
    }
}
