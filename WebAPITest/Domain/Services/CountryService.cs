using Microsoft.EntityFrameworkCore;
using WebAPITest.DAL;
using WebAPITest.DAL.Entities;
using WebAPITest.Domain.Interfaces;
using System.Diagnostics.Metrics;

namespace WebAPITest.Domain.Services
{
    public class CountryService : ICountryService
    {
        private readonly DataBaseContext _context;
        public CountryService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Country>> GetContriesAsync()
        {
            try
            {
                var contries = await _context.Countries.ToListAsync();
                return contries;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }
        public async Task<Country> GetCountryByIdAsync(Guid Id)
        {
            try
            {
                var country = await _context.Countries.FirstOrDefaultAsync(c => c.ID == Id);
                return country;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }
        public async Task<Country> CreateCountryAsync(Country country)
        {
            try
            {
                country.ID = Guid.NewGuid();
                country.CreatedDate = DateTime.Now;
                _context.Countries.Add(country); //El método Add() permite crear el objeto en el contexto de la BD
                await _context.SaveChangesAsync(); //Este método guarda el país en la tabla Country
                return country;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }
        public async Task<Country> EditCountryAsync(Country country)
        {
            try
            {
                country.ModifiedDate = DateTime.Now;
                _context.Countries.Update(country); //Virtualizo mi objeto
                await _context.SaveChangesAsync();
                return country;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }
        public async Task<Country> DeleteCountryAsync(Guid Id)
        {
            try
            {
                var country = await GetCountryByIdAsync(Id);
                if (country == null)
                {
                    return null;
                }
                _context.Countries.Remove(country);
                await _context.SaveChangesAsync();
                return country;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }
    }
}