using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using WebAPITest.DAL;
using WebAPITest.DAL.Entities;
using WebAPITest.Domain.Interfaces;

namespace WebAPITest.Domain.Services
{
    public class StateService : IStateService
    {
        private readonly DataBaseContext _context;
        public StateService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<State>> GetStatesAsync()
        {
            try
            {
                var state = await _context.States.ToListAsync();
                return state;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }
        public async Task<State> GetStateByIdAsync(Guid Id)
        {
            try
            {
                var state = await _context.States.FirstOrDefaultAsync(s => s.ID == Id);
                return state;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }
        public async Task<State> GetStateAsync(State state)
        {
            try
            {
                state.ID = Guid.NewGuid();
                state.CreatedDate = DateTime.Now;
                _context.States.Add(state);
                await _context.SaveChangesAsync();
                return state;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }
        public async Task<State> CreateStateAsync(State state)
        {
            try
            {
                state.ID = Guid.NewGuid();
                state.CreatedDate = DateTime.Now;
                _context.States.Add(state);
                await _context.SaveChangesAsync();
                return state;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }
        public async Task<State> EditStateAsync(State state)
        {
            try
            {
                state.ModifiedDate = DateTime.Now;
                _context.States.Update(state); //Virtualizo mi objeto
                await _context.SaveChangesAsync();
                return state;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }
        public async Task<State> DeleteStateAsync(Guid Id)
        {
            try
            {
                var state = await GetStateByIdAsync(Id);
                if (state == null)
                {
                    return null;
                }
                _context.States.Remove(state);
                await _context.SaveChangesAsync();
                return state;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }
    }
}