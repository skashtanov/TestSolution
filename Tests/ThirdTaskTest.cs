using NUnit.Framework;
using TestSolution.Tasks.Third;

namespace TestSolution.Tests
{
    [TestFixture]
    class ThirdTaskTest
    {
        private static readonly InterpretedAssembly SimpleCode = new ( 
            new[] { "mov a 5", "inc a", "dec a", "dec a", "jnz a -1", "inc a" }
        );

        private static readonly InterpretedAssembly HardCode = new (
            new[] { "mov a 3", "mov b 4", "dec b", "inc a", "jnz b -2", "inc b", "inc b", "dec a" }
        );

        [Test]
        public void SimpleParsingExampleTest()
        {
            Assert.AreEqual(
                SimpleCode.Result()["a"],
                1
            );
        }

        [Test]
        public void HardParsingExampleTest()
        {
            var result = HardCode.Result();
            Assert.True(
                result["a"] == 6
                &&
                result["b"] == 2
            );
        }
    }
}
