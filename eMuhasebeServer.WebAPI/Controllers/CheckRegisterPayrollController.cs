﻿using eMuhasebeServer.Application.Features.CheckRegisterPayrolls.CreateCheckRegisterPayroll;
using eMuhasebeServer.Application.Features.CheckRegisterPayrolls.DeleteChecRegisterPayrollById;
using eMuhasebeServer.Application.Features.CheckRegisterPayrolls.GetAllCheckRegisterPayroll;
using eMuhasebeServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eMuhasebeServer.WebAPI.Controllers;

public sealed class CheckRegisterPayrollController: ApiController
{
    public CheckRegisterPayrollController(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllCheckRegisterPayrollQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
    
    [HttpPost]
    public async Task<ActionResult> Create(CreateCheckRegisterPayrollCommand createCheckRegisterPayrollCommand, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(createCheckRegisterPayrollCommand, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
    
   
    
    [HttpPost]
<<<<<<< HEAD
    public async Task<ActionResult> DeleteCheckRegisterPayrollById(DeleteChecRegisterPayrollByIdCommand deleteChecRegisterPayrollByIdCommand, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(deleteChecRegisterPayrollByIdCommand, cancellationToken);
=======
    public async Task<ActionResult> DeleteCheckRegisterPayrollById(DeleteChecRegisterPayrollByIdCommand deleteBankCommand, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(deleteBankCommand, cancellationToken);
>>>>>>> f5ce1916f9f2464a550c86c2634782668fce3af3
        return StatusCode(response.StatusCode, response);
    }

}