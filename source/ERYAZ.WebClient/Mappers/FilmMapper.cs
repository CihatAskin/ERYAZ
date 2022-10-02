using ERYAZ.Service;
using ERYAZ.WebClient.Models.Film;

namespace ERYAZ.WebClient.Mappers
{
    public class FilmMapper
    {
        public static FilmCreateDto CreateDto( FilmCreateModel model) {
            var dto = new FilmCreateDto();

            dto.Title = model.Title;
            dto.Year = model.Year;
            dto.Rate = model.Rate;

            return dto;
        }
    }
}
