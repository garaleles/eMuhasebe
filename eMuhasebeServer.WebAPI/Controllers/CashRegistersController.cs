using eMuhasebeServer.Application.Features.CashRegisters.CreateCashRegister;
using eMuhasebeServer.Application.Features.CashRegisters.DeleteCashRegisterById;
using eMuhasebeServer.Application.Features.CashRegisters.GetAllCashRegisters;
using eMuhasebeServer.Application.Features.CashRegisters.UpdateCashRegister;
using eMuhasebeServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eMuhasebeServer.WebAPI.Controllers;

public class CashRegistersController : ApiController
{
    public CashRegistersController(IMediator mediator)
        : base(mediator) { }

    [HttpPost]
    public async Task<IActionResult> GetAll(
        GetAllCashRegistersQuery request,
        CancellationToken cancellationToken
    )
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<ActionResult> Create(
        CreateCashRegisterCommand createCashRegisterCommand,
        CancellationToken cancellationToken
    )
    {
        var response = await _mediator.Send(createCashRegisterCommand, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<ActionResult> Update(
        UpdateCashRegisterCommand updateCashRegisterCommand,
        CancellationToken cancellationToken
    )
    {
        var response = await _mediator.Send(updateCashRegisterCommand, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<ActionResult> DeleteCashRegisterById(
        DeleteCashRegisterByIdCommand deleteCashRegisterByIdCommand,
        CancellationToken cancellationToken
    )
    {
        var response = await _mediator.Send(deleteCashRegisterByIdCommand, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
