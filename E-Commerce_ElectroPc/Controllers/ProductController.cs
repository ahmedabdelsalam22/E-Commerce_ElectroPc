using AutoMapper;
using ElectroPc_Models;
using ElectroPc_Models.Dtos;
using ElectroPc_Services.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;

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

        public async Task<IActionResult> Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                // Create 
                return View();
            }
            else
            {
                // Update
                Product product = await _unitOfWork.productRepository.GetAsync(filter: x => x.ProductId == id);

                ProductDto productDto = _mapper.Map<ProductDto>(product);

                return View(productDto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(ProductDto productDto)
        {
            if (productDto.ProductId == 0 || productDto.ProductId == null)
            {
                if (ModelState.IsValid)
                {
                    Product product = _mapper.Map<Product>(productDto);

                    await _unitOfWork.productRepository.CreateAsync(product);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                if (productDto == null)
                {
                    ModelState.AddModelError("", "fill data!");
                }
                Product productToDb = _mapper.Map<Product>(productDto);
               await _unitOfWork.productRepository.Update(productToDb);
                return RedirectToAction("Index");
            }
            return View(productDto);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return BadRequest();
            }
            var obj = await _unitOfWork.productRepository.GetAsync(u => u.ProductId == id);

            await _unitOfWork.productRepository.Remove(obj);
            return RedirectToAction("Index");

        }
    }
}
