using MarGate.Catalog.Api.Requests.Product;
using MarGate.Catalog.Application.Handlers.Products.Commands.CreateCatalog;
using MarGate.Catalog.Application.Handlers.Products.Commands.DeleteCatalog;
using MarGate.Catalog.Application.Handlers.Products.Commands.UpdateCatalog;
using MarGate.Catalog.Application.Handlers.Products.Queries.GetAllCatalogs;
using MarGate.Catalog.Application.Handlers.Products.Queries.GetCatalogById;
using MarGate.Core.Api.Controllers;
using MarGate.Core.Api.Responses.Results;
using MarGate.Core.CQRS.Processor;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSample.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(ICQRSProcessor cqrsProcessor) : BaseController
{
    private readonly ICQRSProcessor _cqrsProcessor = cqrsProcessor;

    /// <summary>
    /// Get all products
    /// </summary>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>A list of all products</returns>
    [HttpGet]
    public async Task<Result<List<GetAllProductsQueryResponse>>> GetAllProducts(CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new GetAllProductsQueryRequest(), cancellationToken);
        return new Result<List<GetAllProductsQueryResponse>>(ResultStatus.Success, response);
    }

    /// <summary>
    /// Get a product by its ID
    /// </summary>
    /// <param name="id">The ID of the product</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>The product matching the given ID</returns>
    [HttpGet("{id}")]
    public async Task<Result<GetProductByIdQueryResponse>> GetProductById(
        [FromRoute] long id,
        CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new GetProductByIdQueryRequest { Id = id }, cancellationToken);
        return new Result<GetProductByIdQueryResponse>(ResultStatus.Success, response);
    }

    /// <summary>
    /// Create a new product
    /// </summary>
    /// <param name="request">The details of the product to be created</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>The response after creating the product</returns>
    [HttpPost]
    public async Task<Result<CreateProductCommandResponse>> CreateProduct(
        [FromBody] CreateProductRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new CreateProductCommandRequest
        {
            Name = request.Name,
            UnitsInStock = request.UnitsInStock,
            Price = request.Price,
            CategoryId = request.CategoryId
        }, cancellationToken);

        return new Result<CreateProductCommandResponse>(ResultStatus.Success, response);
    }

    /// <summary>
    /// Update an existing product
    /// </summary>
    /// <param name="id">The ID of the product to update</param>
    /// <param name="request">The updated details of the product</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>The response after updating the product</returns>
    [HttpPut("{id}")]
    public async Task<Result<UpdateProductCommandResponse>> UpdateProduct(
        [FromRoute] long id,
        [FromBody] UpdateProductRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new UpdateProductCommandRequest
        {
            Id = id,
            Name = request.Name,
            UnitsInStock = request.UnitsInStock,
            Price = request.Price,
            CategoryId = request.CategoryId
        }, cancellationToken);

        return new Result<UpdateProductCommandResponse>(ResultStatus.Success, response);
    }

    /// <summary>
    /// Delete a product by its ID
    /// </summary>
    /// <param name="id">The ID of the product to delete</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>The response after deleting the product</returns>
    [HttpDelete("{id}")]
    public async Task<Result<DeleteProductCommandResponse>> DeleteProduct(
        [FromRoute] long id,
        CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new DeleteProductCommandRequest { Id = id }, cancellationToken);
        return new Result<DeleteProductCommandResponse>(ResultStatus.Success, response);
    }
}
