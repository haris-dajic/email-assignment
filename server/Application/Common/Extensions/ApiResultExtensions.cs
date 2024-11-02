using System.Net;
using Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace Application.Common.Extensions;

public static class ApiResultExtensions
{
    public static ObjectResult ToActionResult(this ApiResult result)
    {
        return new ObjectResult(result) { StatusCode = (int)result.HttpStatusCode };
    }
}