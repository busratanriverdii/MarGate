using MarGate.Catalog.Api.Requests.Category;
using MarGate.Catalog.Application.Handlers.Categories.Commands.CreateCategory;
using MarGate.Catalog.Application.Handlers.Categories.Commands.DeleteCategory;
using MarGate.Catalog.Application.Handlers.Categories.Commands.UpdateCategory;
using MarGate.Catalog.Application.Handlers.Categories.Queries.GetAllCategories;
using MarGate.Catalog.Application.Handlers.Categories.Queries.GetCategoryById;
using MarGate.Core.Api.Controllers;
using MarGate.Core.Api.Responses.Results;
using MarGate.Core.CQRS.Processor;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSample.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICQRSProcessor cqrsProcessor) : BaseController
    {
        private readonly ICQRSProcessor _cqrsProcessor = cqrsProcessor;

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to cancel the request</param>
        /// <returns>A list of all categories</returns>
        [HttpGet]
        public async Task<Result<List<GetAllCategoriesQueryResponse>>> GetAllCategories(CancellationToken cancellationToken)
        {
            var response = await _cqrsProcessor.ProcessAsync(new GetAllCategoriesQueryRequest(), cancellationToken);
            return new Result<List<GetAllCategoriesQueryResponse>>(ResultStatus.Success, response);
        }

        /// <summary>
        /// Get a category by its ID
        /// </summary>
        /// <param name="id">The ID of the category</param>
        /// <param name="cancellationToken">Cancellation token to cancel the request</param>
        /// <returns>The category matching the given ID</returns>
        [HttpGet("{id}")]
        public async Task<Result<GetCategoryByIdQueryResponse>> GetCategoryById(
            [FromRoute] long id,
            CancellationToken cancellationToken)
        {
            var response = await _cqrsProcessor.ProcessAsync(new GetCategoryByIdQueryRequest { Id = id }, cancellationToken);
            return new Result<GetCategoryByIdQueryResponse>(ResultStatus.Success, response);
        }

        /// <summary>
        /// Create a new category
        /// </summary>
        /// <param name="request">The details of the category to be created</param>
        /// <param name="cancellationToken">Cancellation token to cancel the request</param>
        /// <returns>The response after creating the category</returns>
        [HttpPost]
        public async Task<Result<CreateCategoryCommandResponse>> CreateCategory(
            [FromBody] CreateCategoryRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _cqrsProcessor.ProcessAsync(new CreateCategoryCommandRequest
            {
                Name = request.Name,
                Description = request.Description
            }, cancellationToken);

            return new Result<CreateCategoryCommandResponse>(ResultStatus.Success, response);
        }

        /// <summary>
        /// Update an existing category
        /// </summary>
        /// <param name="id">The ID of the category to update</param>
        /// <param name="request">The updated details of the category</param>
        /// <param name="cancellationToken">Cancellation token to cancel the request</param>
        /// <returns>The response after updating the category</returns>
        [HttpPut("{id}")]
        public async Task<Result<UpdateCategoryCommandResponse>> UpdateCategory(
            [FromRoute] long id,
            [FromBody] UpdateCategoryRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _cqrsProcessor.ProcessAsync(new UpdateCategoryCommandRequest
            {
                Id = id,
                Name = request.Name,
                Description = request.Description
            }, cancellationToken);

            return new Result<UpdateCategoryCommandResponse>(ResultStatus.Success, response);
        }

        /// <summary>
        /// Delete a category by its ID
        /// </summary>
        /// <param name="id">The ID of the category to delete</param>
        /// <param name="cancellationToken">Cancellation token to cancel the request</param>
        /// <returns>The response after deleting the category</returns>
        [HttpDelete("{id}")]
        public async Task<Result<DeleteCategoryCommandResponse>> DeleteCategory(
            [FromRoute] long id,
            CancellationToken cancellationToken)
        {
            var response = await _cqrsProcessor.ProcessAsync(new DeleteCategoryCommandRequest { Id = id }, cancellationToken);
            return new Result<DeleteCategoryCommandResponse>(ResultStatus.Success, response);
        }
    }
}
