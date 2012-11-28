using System.Web.Script.Serialization;
using EasyArchitecture.Internal;
using NUnit.Framework;

namespace EasyArchitecture.Tests.Internals.Internal
{
    [TestFixture]
    public class JsonSerializerTest
    {

        //http://www.w3schools.com/json/json_syntax.asp
        //http://msdn.microsoft.com/en-us/library/system.web.script.serialization.javascriptserializer.aspx
        [Test]
        public void SerializeTest()
        {
            var s = "123";
            var actual = JsonSerializer.Serialize(s);
            var expected = new JavaScriptSerializer().Serialize(s);

            Assert.That(actual,Is.EqualTo(expected));

            var s1 = 'c';
            actual = JsonSerializer.Serialize(s1);
            expected = new JavaScriptSerializer().Serialize(s1);

            Assert.That(actual, Is.EqualTo(expected));

            var s2 = true;
            actual = JsonSerializer.Serialize(s2);
            expected = new JavaScriptSerializer().Serialize(s2);

            Assert.That(actual, Is.EqualTo(expected));

            var s3 = 15;
            actual = JsonSerializer.Serialize(s3);
            expected = new JavaScriptSerializer().Serialize(s3);

            Assert.That(actual, Is.EqualTo(expected));

            //var s4 = DateTime.Now;
            //actual = JsonSerializer.Serialize(s4);
            //expected = new JavaScriptSerializer().Serialize(s4);

            //Assert.That(actual, Is.EqualTo(expected));

        }
    }
}
