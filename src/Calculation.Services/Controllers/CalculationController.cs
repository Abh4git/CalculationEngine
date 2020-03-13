using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Calculations.Core.Entities;
using Calculations.Core.Enums;
using Calculations.Core.Interfaces;
using CalculationEngine;
namespace Calculation.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
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

            FinancialReturnInputs finROIInputs = new FinancialReturnInputs();
            finROIInputs.InitialInvestment = initialInvst;
            finROIInputs.CashInFlows = yearlyCashFlows;
            finROIInputs.DiscountRate = discountRate;

            ///Initailizing NPVCalculation class with the parameters of Initail investment, discountrate, yearly cash flow, number of years
            ///then the Execute method is called and result is found in Result property of the class.
            ICalcuation calcuationNPV = CalculationFactory.Instance().GetCalculation(CalculationTypeEnum.NPV, finROIInputs);
            bool executed = calcuationNPV.Execute();
      
            return calcuationNPV.Result.ToString();
        }


    }
}