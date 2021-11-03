using System;
using System.Collections.Generic;
using System.Linq;

namespace TestSolution.Tasks.Second
{
    class PatientsRepository : IPatientsRepository
    {
        private readonly IEnumerable<Patient> _patients;

        public PatientsRepository(IEnumerable<Patient> patients) =>
            _patients = patients;

        public PatientsRepository(params Patient[] patients) : 
            this(patients.ToList())
        {  
        }

        public IEnumerable<Patient> FindByName(string name)
        {
            return _patients.Where(patient => patient.Name == name);
        }

        public IEnumerable<Patient> FindBySurname(string surname)
        {
            return _patients.Where(patient => patient.Surname == surname);
        }

        public IEnumerable<Patient> Critical()
        {
            return _patients.Where(patient => patient.Status == "critical");
        }

        public IEnumerable<Patient> YoungerThan(int age)
        {
            if (age <= 0) 
            {
                throw new ArgumentException($"{nameof(age)} must be positive");
            }
            return _patients.Where(patient => patient.Age < age);
        }
    }
}
