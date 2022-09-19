using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MotorolaExam.Services.Models.DTOs.MotoTechStack;
using MotorolaExam.Services.Services.Interfaces;

namespace MotorolaExam.API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class MotoTechStacksController : ControllerBase
   {
      private readonly IMotoTechStackService _motoTechStackService;

      public MotoTechStacksController(IMotoTechStackService motoTechStackService)
      {
         _motoTechStackService = motoTechStackService;
      }

      [HttpGet]
      public async Task<IActionResult> GetAllMotoTechStacks()
         => Ok(await _motoTechStackService.GetAllAsync());

      [HttpGet("{id}", Name = "GetSingleMotoTechStack")]
      public async Task<IActionResult> GetSingleMotoTechStack(int id)
      {
         MotoTechStackReadDto motoTechStack;
         try
         {
            motoTechStack = await _motoTechStackService.GetSingleAsync(mts => mts.Id == id);
         }
         catch (ArgumentNullException e)
         {
            return NotFound();
         }
         return Ok(motoTechStack);
      }

      [HttpPost]
      public async Task<IActionResult> CreateNewMotoTechStack(MotoTechStackCreateDto motoTechStackCreateDto)
      {
         var newMotoTechStack = await _motoTechStackService.CreateNewAsync(motoTechStackCreateDto);
         return Ok(newMotoTechStack);
      }

      [HttpPut("{id}")]
      public async Task<IActionResult> PutMotoTechStack(int id, MotoTechStackUpdateDto motoTechStackUpdateDto)
      {
         try
         {
            await _motoTechStackService.PutAsync(mts => mts.Id == id, motoTechStackUpdateDto);
         }
         catch (ArgumentNullException e)
         {
            return NotFound();
         }
         return NoContent();
      }

      [HttpPatch("{id}")]
      public async Task<IActionResult> PatchMotoTechStack(int id, JsonPatchDocument motoTechStackPatch)
      {
         try
         {
            await _motoTechStackService.PatchAsync(mts => mts.Id == id, motoTechStackPatch);
         }
         catch (ArgumentNullException e)
         {
            return NotFound();
         }
         return NoContent();
      }
   }
}