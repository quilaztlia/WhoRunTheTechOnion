using Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation;

[ApiController]
[Route("api/commande")]
public class CommandeController: ControllerBase
{
    private readonly ICommandeService _commandeService;

	public CommandeController(ICommandeService commandeService)
	{
		_commandeService = commandeService;
	}

	[HttpGet]
	public async Task<IActionResult> GetCommandes(CancellationToken cancellationToken)
	{
        var commandes = await _commandeService.GetAllAsync(cancellationToken);		
		return Ok(commandes);
	}

	[HttpGet("{commandeId:guid}")]
	public async Task<IActionResult> GetCommandeById(Guid commandeId, CancellationToken cancellationToken)
	{
        var commande = await _commandeService.GetByIdAsync(commandeId);
		return Ok(commande);
	}

	[HttpPost]
	public async Task<IActionResult> CreateCommande([FromBody]CommandeCreationDto commandeToCreate, CancellationToken cancellationToken)
	{
        var commandeDto = await _commandeService.CreateAsync(commandeToCreate);
		//return Ok(commandeDto);
		return CreatedAtAction(nameof(GetCommandeById), new { commandeId = commandeDto.Id }, commandeDto);
	}

	//[HttpPut("{commandeId:Guid}")]
	//public async Task<IActionResult> UpdateCommande(Guid idCommande, CancellationToken cancellationToken)
	//{
	//}

	//Delete
}
