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
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
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
        public async Task<IActionResult> Upsert(ProductDto productDto, IFormFile? file)
        {
            if (productDto.ProductId == 0 || productDto.ProductId == null)
            {
                if (ModelState.IsValid)
                {

                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    if (file != null)
                    {
                        string fileName = Guid.NewGuid().ToString();
                        var uploads = Path.Combine(wwwRootPath, @"images\products");
                        var extension = Path.GetExtension(file.FileName);

                        if (productDto.ImageUrl != null)
                        {
                            var oldImagePath = Path.Combine(wwwRootPath, productDto.ImageUrl.TrimStart('\\'));
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }
                        }

                        using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                        {
                            file.CopyTo(fileStreams);
                        }
                        productDto.ImageUrl = @"\images\products\" + fileName + extension;

                    }

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

            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            await _unitOfWork.productRepository.Remove(obj);
            return RedirectToAction("Index");
        }
    }
}
