namespace Kodris.Services
{
    /// <summary>
    /// Service for saving sorting history to the database.
    /// </summary>
    public class SortingService
    {
        private readonly SortingDbContext _context;

        public SortingService(SortingDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Saves the sorting history to the database.
        /// </summary>
        /// <param name="algorithm"> Spesific algorithm name </param>
        /// <param name="input"> Input to the algorithm </param>
        /// <param name="output"> Result from the algorithm </param>
        /// <returns></returns>
        public async Task SaveSortHistory(string algorithm, string input, string output)
        {
            var history = new SortingHistory(algorithm, input, output, DateTime.Now);

            await _context.SortingHistories.AddAsync(history);
            await _context.SaveChangesAsync();
        }
    }
}