using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TestSolution.Tasks.Second;

namespace TestSolution.Tests
{
    [TestFixture]
    class SecondTaskTest
    {
        private static readonly List<Patient> Patients = new() 
        {
            new("Alex", "Mitchel", 21, "critical"),
            new("Kate", "Pupsvel", 18, "critical"),
            new("Georgy", "Robbinson", 42, "normal"),
            new("LG", "Company", 120, "normal"),
            new("Mickey", "Mouse", 30, "critical"),
        };
        private static readonly PatientsRepository Repository = new (Patients);

        [Test]
        public void CriticalTest()
        {
            Assert.True(
                Repository.Critical().SequenceEqual(new Patient[] {
                    Patients[0], Patients[1], Patients[4]
                })
            );
        }

        [Test]
        public void LessThanTest()
        {
            Assert.True(
                Repository.YoungerThan(22).SequenceEqual(new Patient[] {
                    Patients[0], Patients[1]
                })
            );
        }

        [Test]
        public void FindByNameTest()
        {
            Assert.True(
                Repository.FindByName("LG").SequenceEqual(new Patient[] {
                    Patients[3]
                })
            );
        }

        [Test]
        public void FindBySurnameTest()
        {
            Assert.True(
                Repository.FindBySurname("Mouse").SequenceEqual(new Patient[] {
                    Patients[4]
                })
            );
        }
    }
}
