using HtmlAgilityPack;
using NUnit.Framework;
using System.Text;
using System.Threading.Tasks;

namespace KPI.UI.Tests
{
    public class Tests
    {
        private HtmlDocument _document;

        [SetUp]
        public void Setup()
        {
            _document = new HtmlWeb() { OverrideEncoding = Encoding.UTF8 }.Load("https://ru.m.wikipedia.org/wiki/%D0%92%D0%B8%D0%BA%D0%B8%D0%BF%D0%B5%D0%B4%D0%B8%D1%8F", "GET");
        }

        [Test]
        public void Test1()
        {
            var expected_h1 = "Википедия";

            var h1 = _document.DocumentNode.SelectSingleNode("//h1[@id='section_0']//h1");

            Assert.AreEqual(expected_h1, h1?.InnerText?.Trim());
        }

        [Test]
        public void Test2()
        {
            var expected_div = "Добро пожаловать в Википедию";

            var div = _document.DocumentNode.SelectSingleNode("//div[@id='description']//div");

            Assert.AreEqual(expected_div, div.InnerText.Trim());
        }
    }
}