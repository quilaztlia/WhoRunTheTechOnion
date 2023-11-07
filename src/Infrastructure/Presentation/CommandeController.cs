using Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation;

[ApiController]
[Route("api/commande")]
public class CommandeController: ControllerBase
{
    private readonly IServiceManager _serviceManager;

	public CommandeController(IServiceManager serviceManager)
	{
		_serviceManager = serviceManager;
	}

	[HttpGet]
	public async Task<IActionResult> GetCommandes(CancellationToken cancellationToken)
	{
        var commandes = await _serviceManager.CommandeService.GetAllAsync(cancellationToken);		
		return Ok(commandes);
	}
	
	[HttpGet("{commandeId:guid}")]
	public async Task<IActionResult> GetCommandeById(Guid commandeId, CancellationToken cancellationToken)
	{
        var commande = await _serviceManager.CommandeService.GetByIdAsync(commandeId);
		return Ok(commande);
	}

	[HttpPost]
	public async Task<IActionResult> CreateCommande([FromBody]CommandeCreationDto commandeToCreate, CancellationToken cancellationToken)
	{
        var commandeDto = await _serviceManager.CommandeService.CreateAsync(commandeToCreate);
		//return Ok(commandeDto);
		return CreatedAtAction(nameof(GetCommandeById), new { commandeId = commandeDto.Id }, commandeDto);
	}

	//[HttpPut("{commandeId:Guid}")]
	//public async Task<IActionResult> UpdateCommande(Guid idCommande, CancellationToken cancellationToken)
	//{
	//}

	//Delete
}