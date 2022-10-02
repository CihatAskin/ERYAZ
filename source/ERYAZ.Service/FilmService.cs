using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;

namespace ERYAZ.Service
{
    public class FilmService : IFilmService
    {
        private IOptions<ConnectionStrings> _con;

        public FilmService(IOptions<ConnectionStrings> con)
        {
            _con = con;
        }

        public async Task<bool> CreateAsync(FilmCreateDto dto)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_con.Value.Postgres))
                {
                    await connection.ExecuteScalarAsync(Queries.INSERT_FILM, dto);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false; ;
            }
        }
    }
}