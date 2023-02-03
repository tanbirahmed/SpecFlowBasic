using System;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace TestSpecFlow.StepDefinitions
{
    [Binding]
    public class CalculatorStepDefinitions
    {
        CalculatorApplication app = new CalculatorApplication();
        int input1, input2;
        double output;

        [Given(@"I have provided (.*) and (.*) as the inputs")]
        public void GivenIHaveProvidedAndAsTheInputs(int p0, int p1)
        {
            input1 = p0;
            input2 = p1;
        }

        [Given(@"I have provided (.*) as input")]
        public void GivenIHaveProvidedAsInput(int p0)
        {
            input1 = p0;
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            output = app.add(input1, input2);
        }

        [When(@"I press subtract")]
        public void WhenIPressSubtract()
        {
            output = app.subtract(input1, input2);
        }

        [When(@"I press multiply")]
        public void WhenIPressMultiply()
        {
            output = app.multiply(input1, input2);
        }

        [When(@"I press divide")]
        public void WhenIPressDivide()
        {
            output = app.divide(input1, input2);
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(double p0)
        {
            Assert.AreEqual(p0, output);
        }

        [When(@"I press squareroot")]
        public void WhenIPressSquareroot()
        {
            output = app.squareRoot(input1);
        }
    }
}
