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
            _document = new HtmlWeb() { OverrideEncoding = Encoding.UTF8 }
            .Load("https://ru.m.wikipedia.org/wiki/%D0%92%D0%B8%D0%BA%D0%B8%D0%BF%D0%B5%D0%B4%D0%B8%D1%8F", "GET");
        }

        [Test]
        public void TestTitle()
        {
            string expected = "Википедия";
            string actual = _document.DocumentNode.SelectSingleNode("//h1[@id='section_0']").InnerText?.Trim();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestEditButton()
        {
            string expected = "Править";
            string actual = _document.DocumentNode.SelectSingleNode("//a[@id='ca-edit']").InnerText?.Trim();
            Assert.AreEqual(expected, actual);
        }
    }
}
