using Microsoft.VisualStudio.TestTools.UnitTesting;
using JSTest;
using JSTest.ScriptLibraries;

namespace WebPaintAutoTests
{
    [TestClass]
    public class UnitLogicTestJS
    {
        static private readonly TestScript _commonTestScript = new TestScript();

        [ClassInitialize]
        static public void CommonJavaScriptTests(TestContext tc)
        {
            _commonTestScript.AppendFile(@"E:\XAMPP\htdocs\Tables\PHPDBServer\Reader.js");
            _commonTestScript.AppendBlock(new JsAssertLibrary());
        }

        [DataTestMethod]
        [DataRow("JSON", "[{\"id\":\"1\",\"fn\":\"A\",\"ln\":\"B\",\"age\":\"12\"}]")]
        [DataRow("XML", "<Persons><Person><Id>1</Id><FirstName>A</FirstName><LastName>B</LastName><Age>12</Age></Person></Persons>")]
        [DataRow("HTML", "<tr><td>1</td><td>A</td><td>B</td><td>12</td></tr></table>")]
        [DataRow("XSLT", "<Persons><Person><Id>1</Id><FirstName>A</FirstName><LastName>B</LastName><Age>12</Age></Person></Persons>")]
        [DataRow("YAML", "Persons:\n- Id: 1\n\tFirstName: A\n\tLastName: B\n\tAge: 12")]
        public void TestCalcJs(string method, string input)
        {
            string output = "<tr><td>1</td><td>A</td><td>B</td><td>12</td></tr></table>";
            _commonTestScript.RunTest($"assert.equal('{output}', Factory.getReader('{method}').Read('{input}'));");
        }
    }
}