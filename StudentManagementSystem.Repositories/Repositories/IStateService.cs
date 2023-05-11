using StudentManagementSystem.Models;
using StudentManagementSystem.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Repositories.Repositories
{
    public interface IStateService
    {
        int AddState(State data);
        State GetSingleStates(int id);
        List<State> GetAllStates();
        int EditState(State data);
        int DeleteState(int id);
        List<State> GetStateAccordingToCountry(int CountryId);
    }
}
