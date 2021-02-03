

using System.Threading.Tasks;

namespace DogImageApiCall.Services
{
        public interface IDogImageClient
        {
        Task<DogImageResponse> GetDogImage(string breed = "clumber");
        }
}
