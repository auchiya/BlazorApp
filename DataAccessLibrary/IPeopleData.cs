using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface IPeopleData
    {
        Task<List<PersonModel>> GetPeople();
        Task InsertPerson(PersonModel person);
    }
}
