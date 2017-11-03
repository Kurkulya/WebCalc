using JSTest;
using JSTest.ScriptLibraries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace UnitLogicTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var script = new TestScript();
            // Arrange: Append the JavaScript code to test.
            string scriptContents = (new AssemblyHelper().GetContentsEmbededResourceFile("calculate.js"));
            script.AppendBlock(scriptContents);
            // Arrange: Append the JSTest asser library, so we can assert the test code.
            script.AppendBlock(new JsAssertLibrary());
            // Append "Act" JavaScript code.
            script.AppendBlock("var calc = calculate(1, 2, '+');");
            // Assert.
            script.RunTest(@"assert.equal(3, calc);");
        }
    }
}
