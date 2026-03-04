using System;
using API.DTOs;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class BuggyController : BaseAPIController
{
    [HttpGet("unauthorized")]
    public IActionResult GetUnauthorized() => Unauthorized();

    [HttpGet("badrequest")]
    public IActionResult GetBadRequest() => BadRequest("This is a bad request");

    [HttpGet("notfound")]
    public IActionResult GetNotFound() => NotFound();

     [HttpGet("internalerror")]
    public IActionResult GetInternalError() => throw new Exception("This is a test internal error");

    [HttpPost("validationerror")]
    public IActionResult GetValidationError([FromBody] CreatePostDTO post) => Ok();

}
