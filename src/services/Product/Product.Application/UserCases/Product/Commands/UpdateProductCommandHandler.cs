using AutoMapper;
using Contracts.Abstractions.Message;
using Contracts.Abstractions.Shared;
using Product.Persistence.Repositories.Abstractions;
using Shared.Dtos.Product;
using Entities = Product.Domain.Entities;
using static Shared.Services.Product.Command;
using Microsoft.EntityFrameworkCore;
using Product.Domain.Exceptions;

namespace Product.Application.UserCases.Product.Commands;

public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, Response.ProductResponse>
{
    private readonly IRepositoryWrapper _repoWrapper;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(IRepositoryWrapper repoWrapper, IMapper mapper)
    {
        _repoWrapper = repoWrapper;
        _mapper = mapper;
    }

    public async Task<Result<Response.ProductResponse>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repoWrapper.Product
            .FindByCondition(x => x.Id == request.Id)
            .FirstOrDefaultAsync();

        if(product is null)
        {
            throw new ProductNotFoundException(request.Id);
        }    

        _mapper.Map<UpdateProductCommand, Entities.Product>(request, product);

        _repoWrapper.Product.Update(product);
        await _repoWrapper.SaveAsync();

        return Result.Success(_mapper.Map<Response.ProductResponse>(product));
    }
}