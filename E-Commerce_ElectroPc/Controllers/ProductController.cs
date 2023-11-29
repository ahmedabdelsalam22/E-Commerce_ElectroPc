using AutoMapper;
using ElectroPc_Models;
using ElectroPc_Models.Dtos;
using ElectroPc_Services.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            if (ModelState.IsValid) 
            {
                Product product = _mapper.Map<Product>(productDto);
                await _unitOfWork.productRepository.CreateAsync(product);
                
            }
            return RedirectToAction("Index");
        }
    }
}
