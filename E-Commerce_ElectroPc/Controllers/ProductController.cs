using AutoMapper;
using ElectroPc_Models;
using ElectroPc_Models.Dtos;
using ElectroPc_Services.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_ElectroPc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
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

    }
}
