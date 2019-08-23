using System.Collections.Generic;
using Survey.Models;

namespace Survey.Data.Interfaces
{
    public interface IPersonRepo
    {
        IEnumerable<Person> GetPeople(int? Id = null);
        Person GetPerson(int Id);
    }
}