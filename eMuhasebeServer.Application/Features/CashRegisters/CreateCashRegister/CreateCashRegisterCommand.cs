﻿using eMuhasebeServer.Domain.Enums;
using MediatR;
using TS.Result;

namespace eMuhasebeServer.Application.Features.CashRegisters.CreateCashRegister;

public sealed record CreateCashRegisterCommand(string Name, int currencyTypeValue)
    : IRequest<Result<string>>;