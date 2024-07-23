using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RealTimeUsingSockets.Application.Dtos.ProductDtos;
using RealTimeUsingSockets.Application.Features.ProductFeatures.Add;
using RealTimeUsingSockets.Application.Features.ProductFeatures.Buy;
using RealTimeUsingSockets.Application.Features.ProductFeatures.Delete;
using RealTimeUsingSockets.Application.Features.ProductFeatures.GetAll;
using RealTimeUsingSockets.Application.Interfaces;
using RealTimeUsingSockets.Domain.Models;

namespace RealTimeUsingSockets.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IHubContext<ProductUpdatesHub> _hubContext;
        public ProductController(IMediator mediator, IUnitOfWork unitOfWork, IHubContext<ProductUpdatesHub> hubContext)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
            _hubContext = hubContext;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllProductsQuery()));
        }
        public async Task<IActionResult> GetAll()
        {
            return View(await _mediator.Send(new GetAllProductsQuery()));
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddProductDto productDto)
        {
            var result = await _mediator.Send(new AddProductCommand(productDto));
            await _hubContext.Clients.All.SendAsync("AddProduct", result);

            TempData["Message"] = "Your action was successful!";

            return RedirectToAction(nameof(Index), nameof(Product));
        }
        public async Task<IActionResult> Delete(int productId)
        {
            var result = await _mediator.Send(new DeleteProductCommand(productId));
            await _hubContext.Clients.All.SendAsync("DeleteProduct", productId);

            return RedirectToAction(nameof(Index), nameof(Product));
        }
        public async Task<IActionResult> Buy(int productId)
        {
            var result = await _mediator.Send(new BuyProductCommand(productId));
            await _hubContext.Clients.All.SendAsync("BuyProduct", result);

            var mostSoldProduct = await _unitOfWork.Products.GetMostSoldProductAsync();
            await _hubContext.Clients.All.SendAsync("MostSoldProduct", mostSoldProduct);

            return RedirectToAction(nameof(GetAll), nameof(Product));
        }
    }
}
