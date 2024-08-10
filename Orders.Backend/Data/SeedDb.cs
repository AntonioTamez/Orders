using Orders.Shared.Entities;

namespace Orders.Backend.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
            await CheckCategoriesAsync();
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country { Name = "México" });
                _context.Countries.Add(new Country { Name = "Colombia" });
                _context.Countries.Add(new Country { Name = "Estados Unidos" });
            }

            await _context.SaveChangesAsync();
        }

        private async Task CheckStateAsync()
        {
            if (!_context.States.Any())
            { 
                _context.States.Add(new State { Name = "Nuevo León", CountryId = 1 });
                _context.States.Add(new State { Name = "Coahuila", CountryId = 1 });
                _context.States.Add(new State { Name = "Durango", CountryId = 1 });
            }
            await _context.SaveChangesAsync();
        }

        private async Task CheckCityAsync()
        {
            if (!_context.Cities.Any())
            {
                _context.Cities.Add(new City { Name = "China", StateId = 1 });
                _context.Cities.Add(new City { Name = "Apodaca", StateId = 1 });
                _context.Cities.Add(new City { Name = "Cadereyta", StateId = 1 });
            }
            await _context.SaveChangesAsync();
        }

        private async Task CheckCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Category { Name = "Calzado" });
                _context.Categories.Add(new Category { Name = "Tecnología" });
            }

            await _context.SaveChangesAsync();
        }
    }
}
