using Contracts.Abstractions.Message;
using Contracts.Abstractions.Shared;
using Product.Persistence.Repositories.Abstractions;
using Shared.Dtos.Product;
using Entities = Product.Domain.Entities;
using static Shared.Services.Product.Command;
using AutoMapper;

namespace Product.Application.UserCases.Product.Commands;

internal sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Response.ProductResponse>
{
    private readonly IRepositoryWrapper _repoWrapper;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IRepositoryWrapper repoWrapper, IMapper mapper)
    {
        _repoWrapper = repoWrapper;
        _mapper = mapper;
    }
    public async Task<Result<Response.ProductResponse>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Entities.Product>(request);

        _repoWrapper.Product.Add(product);
        await _repoWrapper.SaveAsync();

        return Result.Success(_mapper.Map<Response.ProductResponse>(product));
    }
}