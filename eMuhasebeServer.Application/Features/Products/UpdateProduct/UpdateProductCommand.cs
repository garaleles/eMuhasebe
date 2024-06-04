﻿using MediatR;
using TS.Result;

namespace eMuhasebeServer.Application.Features.Products.UpdateProduct;

public sealed record UpdateProductCommand(
    Guid Id,
    string Name,
    string Description,
    Guid CategoryId,
    Guid UnitId,
    decimal PurchasePrice,
    decimal SellingPrice
    ) : IRequest<Result<string>>;