using DogImageApiCall.Models;
using DogImageApiCall.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DogImageApiCall.Controllers
{
    public class DogController : Controller
    {
        private readonly IDogImageClient _dogImageClient;

        public DogController(IDogImageClient dogImageClient)
        {
            _dogImageClient = dogImageClient;

        
        }
        public async Task<IActionResult> DogPics()
        {
            var response = await _dogImageClient.GetDogImage();
            var model = new DogPicsViewModel();
            model.Dogs = response.Message;
            return View(model);
        
        }
    }
}
