// <copyright file="HealthCalculatorTest001.cs">Copyright ©  2015</copyright>

using System;
using MercuryHealth.Web.Utilities;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.QualityTools.Testing.Fakes;
using System.IO.Fakes;

namespace MercuryHealth.Web.Utilities.Tests
{
    [TestClass]
    [PexClass(typeof(HealthCalculator))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class HealthCalculatorTest
    {

        [PexMethod]
        [PexAllowedException(typeof(DivideByZeroException))]
        public int WeirdHealthIndex(
            [PexAssumeUnderTest]HealthCalculator target,
            int lhs,
            int rhs
        )
        {
            int result = target.WeirdHealthIndex(lhs, rhs);
            return result;
            // TODO: add assertions to method HealthCalculatorTest.WeirdHealthIndex(HealthCalculator, Int32, Int32)
        }

        [PexMethod]
        [PexAllowedException(typeof(ArgumentNullException))]
        public int GetNumberOfFilesAndFolders([PexAssumeUnderTest]HealthCalculator target, string path)
        {
            using(ShimsContext.Create())
            {
                ShimDirectory.GetFilesString = (directoryPath) => new string[10];
                ShimDirectory.GetDirectoriesString = (directoryPath) => new string[3];

                int result = target.GetNumberOfFilesAndFolders(path);
                return result;

            }
            // TODO: add assertions to method HealthCalculatorTest.GetNumberOfFilesAndFolders(HealthCalculator, String)
        }
    }
}
