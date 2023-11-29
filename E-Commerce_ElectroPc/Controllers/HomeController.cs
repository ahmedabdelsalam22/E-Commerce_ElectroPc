using AutoMapper;
using E_Commerce_ElectroPc.Models;
using ElectroPc_Models.Dtos;
using ElectroPc_Models;
using ElectroPc_Services.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace E_Commerce_ElectroPc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HomeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await _unitOfWork.productRepository.GetAllAsync();

            IEnumerable<ProductDto> productDtos = _mapper.Map<List<ProductDto>>(products);

            return View(productDtos);
        }

        public async Task<IActionResult> ProductDetails(int productId) 
        {
            Product product = await _unitOfWork.productRepository.GetAsync(x=>x.ProductId == productId);

            ProductDto productDto = _mapper.Map<ProductDto>(product);

            return View(productDto);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}