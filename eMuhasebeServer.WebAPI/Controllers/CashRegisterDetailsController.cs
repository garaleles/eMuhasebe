using eMuhasebeServer.Application.Features.CashRegisterDetails.CreateCashRegisterDetails;
using eMuhasebeServer.Application.Features.CashRegisterDetails.DeleteCashRegisterDetailById;
using eMuhasebeServer.Application.Features.CashRegisterDetails.GetAllCashRegisterDetails;
using eMuhasebeServer.Application.Features.CashRegisterDetails.UpdateCashRegisterDetail;
using eMuhasebeServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eMuhasebeServer.WebAPI.Controllers;

public class CashRegisterDetailsController: ApiController
{
    public CashRegisterDetailsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> GetAll(
        GetAllCashRegisterDetailsQuery request,
        CancellationToken cancellationToken
    )
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<ActionResult> Create(
        CreateCashRegisterDetailsCommand createCashRegisterDetailCommand,
        CancellationToken cancellationToken
    )
    {
        var response = await _mediator.Send(createCashRegisterDetailCommand, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<ActionResult> Update(
        UpdateCashRegisterDetailCommand updateCashRegisterDetailCommand,
        CancellationToken cancellationToken
    )
    {
        var response = await _mediator.Send(updateCashRegisterDetailCommand, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<ActionResult> DeleteCashRegisterDetailById(
        DeleteCashRegisterDetailByIdCommand deleteCashRegisterDetailByIdCommand,
        CancellationToken cancellationToken
    )
    {
        var response = await _mediator.Send(deleteCashRegisterDetailByIdCommand, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}