using System.Collections.Generic;

namespace TestSolution.Tasks.Second
{
    interface IPatientsRepository
    {
        IEnumerable<Patient> FindByName(string name);
        IEnumerable<Patient> FindBySurname(string surname);
        IEnumerable<Patient> Critical();
        IEnumerable<Patient> YoungerThan(int age);
    }
}
