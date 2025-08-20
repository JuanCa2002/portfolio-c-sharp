using Portfolio.Models;

namespace Portfolio.Services
{
    public class ProyectRepository: IProyectRepository
    {
        public List<Proyect> GetProyects()
        {
            return [
                new Proyect
            {
                Title = "Amazon",
                Description = "Un grandioso trabajo jeje",
                ImageUrl = "/images/dotnet_image.png",
                Link = "link"
            },
            new Proyect
            {
                Title = "New York Times",
                Description = "Un grandioso trabajo jeje",
                ImageUrl = "/images/dotnet_image.png",
                Link = "link"
            },
            new Proyect
            {
                Title = "Reddit",
                Description = "Un grandioso trabajo jeje",
                ImageUrl = "/images/dotnet_image.png",
                Link = "link"
            },
            new Proyect
            {
                Title = "Steam",
                Description = "Un grandioso trabajo jeje",
                ImageUrl = "/images/dotnet_image.png",
                Link = "link"
            }

            ];
        }
    }
}
