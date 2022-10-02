namespace ERYAZ.Service
{
    public interface IFilmService
    {
        Task<bool> CreateAsync(FilmCreateDto dto);
    }
}