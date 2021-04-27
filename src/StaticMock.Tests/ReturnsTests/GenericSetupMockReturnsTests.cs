﻿using NUnit.Framework;

namespace StaticMock.Tests.ReturnsTests
{
    [TestFixture]
    public class GenericSetupMockReturnsTests
    {
        [Test]
        public void TestGenericSetupReturnsWithTestMethodReturn1WithoutParameters()
        {
            var originalResult = TestStaticClass.TestMethodReturn1WithoutParameters();
            var expectedResult = 2;

            Mock.Setup(
                    () => TestStaticClass.TestMethodReturn1WithoutParameters(),
                    () =>
                    {
                        var actualResult = TestStaticClass.TestMethodReturn1WithoutParameters();

                        Assert.AreNotEqual(originalResult, actualResult);
                        Assert.AreEqual(expectedResult, actualResult);
                    })
                .Returns(expectedResult);
        }

        [Test]
        public void TestGenericSetupReturnsWithTestMethodReturnParameter()
        {
            var originalResult = TestStaticClass.TestMethodReturnParameter(10);
            var expectedResult = 2;

            Mock.Setup(
                    () => TestStaticClass.TestMethodReturnParameter(10),
                    () =>
                    {
                        var actualResult = TestStaticClass.TestMethodReturnParameter(10);

                        Assert.AreNotEqual(originalResult, actualResult);
                        Assert.AreEqual(expectedResult, actualResult);
                    })
                .Returns(expectedResult);
        }

        [Test]
        public void TestGenericSetupReturnsWithTestMethodReturnInstanceObject()
        {
            var originalResult = TestStaticClass.TestMethodReturnReferenceObject();
            var expectedResult = new TestInstance
            {
                IntProperty = 1,
                ObjectProperty = new object()
            };

            Mock.Setup(
                    () => TestStaticClass.TestMethodReturnReferenceObject(),
                    () =>
                    {
                        var actualResult = TestStaticClass.TestMethodReturnReferenceObject();

                        Assert.AreNotEqual(originalResult, actualResult);
                        Assert.AreEqual(expectedResult, actualResult);
                    })
                .Returns(expectedResult);
        }

        [Test]
        public void TestGenericSetupReturnsWithTestMethodOutParameter()
        {
            var originalResult = TestStaticClass.TestMethodReturn1WithOutParameter(out _);
            var expectedResult = 2;

            var x = 1;
            Mock.Setup(
                    () => TestStaticClass.TestMethodReturn1WithOutParameter(out x),
                    () =>
                    {
                        var actualResult = TestStaticClass.TestMethodReturn1WithOutParameter(out _);

                        Assert.AreNotEqual(originalResult, actualResult);
                        Assert.AreEqual(expectedResult, actualResult);
                    })
                .Returns(expectedResult);
        }

        [Test]
        public void TestGenericSetupReturnsWithTestMethodRefParameter()
        {
            var x = 1;
            var originalResult = TestStaticClass.TestMethodReturn1WithRefParameter(ref x);
            var expectedResult = 2;

            Mock.Setup(
                    () => TestStaticClass.TestMethodReturn1WithRefParameter(ref x),
                    () =>
                    {
                        var y = 1;
                        var actualResult = TestStaticClass.TestMethodReturn1WithRefParameter(ref y);

                        Assert.AreNotEqual(originalResult, actualResult);
                        Assert.AreEqual(expectedResult, actualResult);
                    })
                .Returns(expectedResult);
        }

        [Test]
        public void TestInstanceMethodReturns()
        {
            var testInstance = new TestInstance();
            Assert.AreEqual(1, testInstance.TestMethodReturn1WithoutParameters());
            var expectedResult = 2;

            Mock.Setup(() => testInstance.TestMethodReturn1WithoutParameters(), () =>
            {
                var actualResult = testInstance.TestMethodReturn1WithoutParameters();
                Assert.AreEqual(expectedResult, actualResult);
            }).Returns(expectedResult);
        }
    }
}
