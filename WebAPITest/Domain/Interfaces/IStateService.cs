using WebAPITest.DAL.Entities;

namespace WebAPITest.Domain.Interfaces
{
    public interface IStateService
    {
        //Métodos CRUD
        Task<IEnumerable<State>> GetStatesAsync();
        Task<State> GetStateByIdAsync(Guid Id);
        Task<State> CreateStateAsync(State state);
        Task<State> EditStateAsync(State state);
        Task<State> DeleteStateAsync(Guid Id);
    }
}
