using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using StreamVerse.CRM.Domain.Model.Queries;
using StreamVerse.CRM.Domain.Services;
using StreamVerse.CRM.Interfaces.REST.Resources;
using StreamVerse.CRM.Interfaces.REST.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace StreamVerse.CRM.Interfaces.REST;



[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available User Endpoints")]
public class UserController(IUserQueryService userQueryService, IUserCommandService userCommandService) : ControllerBase
{
    
    //=========== GET USER BY ID
    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "Get User by ID", Description = "Retrieve a user by their unique identifier.")]
    [SwaggerResponse(StatusCodes.Status200OK, "The user was successfully retrieved", typeof(UserResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserById(int id)
    {
        var getUserByIdQuery = new GetUserByIdQuery(id);
        
        var user = await userQueryService.Handle(getUserByIdQuery);
        
        if (user == null)
        {
            return NotFound(); // Si no se encuentra el usuario, devolver 404
        }
        
        // Mapear user a UserResource
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);

        return Ok(userResource); // <-- asegúrate de que user ya esté en formato UserResource o mapea si es necesario
    }
    
    
    //=========== POST CREATE USER
    [HttpPost]
    [SwaggerOperation(Summary = "Create a new User", Description = "Create a new user in the system.")]
    [SwaggerResponse(StatusCodes.Status201Created, "The user was successfully created", typeof(UserResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data")]
    public async Task<IActionResult> CreateUser([FromBody] CreateCommandResource resource)
    {

        var createdUserCommand = CreateUserCommandFromResourceAssembler.ToCommandFromResource(resource);
        
        var user = await userCommandService.Handle(createdUserCommand);
        
        if (user == null)
        {
            return BadRequest("User creation failed. Please check the input data.");
        }
      
        // Mapear el usuario creado a UserResource
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);

        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, userResource);
    }
    
}