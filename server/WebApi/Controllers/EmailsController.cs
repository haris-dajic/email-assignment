using Application.Common.Extensions;
using Application.Common.Models;
using Application.Domain.Commands;
using Application.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmailsController: ControllerBase
{
    private readonly ISender _sender;

    public EmailsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateEmail([FromBody]SendEmailCommand command)
    {
        return (await _sender.Send(command, HttpContext.RequestAborted)).ToActionResult();
    }

    [HttpGet]
    public async Task<IActionResult> GetEmails(int page = 0, int pageSize = 5)
    {
        var command = new GetEmailsQuery(page, pageSize);
        return (await _sender.Send(command, HttpContext.RequestAborted)).ToActionResult();
    }
}