using Microsoft.VisualStudio.TestTools.UnitTesting;
using JSTest;
using JSTest.ScriptLibraries;
using System;

namespace WebPaintAutoTests
{
    [TestClass]
    public class UnitLogicTestJS
    {
        static private readonly TestScript script = new TestScript();

        [ClassInitialize]
        static public void CommonJavaScriptTests(TestContext tc)
        {
            script.AppendFile("calculate.js");
            script.AppendBlock(new JsAssertLibrary());
        }

        [DataTestMethod]
        [DataRow(1, 2, "+", 3)]
        [DataRow(2, 3, "-", -1)]
        [DataRow(4, 5, "*", 20)]
        [DataRow(8, 4, "/", 2)]
        public void TestMethod1(int a, int b, string op, int res)
        {
            script.RunTest($"assert.equal({res}, calculate({a}, {b}, '{op}'));");
        }
    }
}