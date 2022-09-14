﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MotorolaExam.Services.Models.DTOs.MotorolaProject;
using MotorolaExam.Services.Services.Interfaces;

namespace MotorolaExam.API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class MotorolaProjectsController : ControllerBase
   {
      private readonly IMotorolaProjectService _motorolaProjectService;

      public MotorolaProjectsController(IMotorolaProjectService motorolaProjectService)
      {
         _motorolaProjectService = motorolaProjectService;
      }

      [HttpGet]
      public async Task<IActionResult> GetAllMotorolaProjects()
         => Ok(await _motorolaProjectService.GetAllAsync());

      [HttpGet("{id}", Name = "GetSingleMotorolaProject")]
      public async Task<IActionResult> GetSingleMotorolaProject(int id)
         => Ok(await _motorolaProjectService.GetSingleAsync(mp => mp.Id == id));

      [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
      [HttpPost]
      public async Task<IActionResult> CreateNewMotorolaProject(MotorolaProjectCreateDto motorolaProjectCreateDto)
      {
         var newMotorolaProject = await _motorolaProjectService.CreateNewAsync(motorolaProjectCreateDto);
         return Ok(newMotorolaProject);
      }

      [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteMotorolaProject(int id)
      {
         await _motorolaProjectService.DeleteAsync(mp => mp.Id == id);
         return NoContent();
      }

      [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
      [HttpPut("{id}")]
      public async Task<IActionResult> PutMotorolaProject(int id, MotorolaProjectUpdateDto motorolaProjectUpdateDto)
      {
         await _motorolaProjectService.PutAsync(mp => mp.Id == id, motorolaProjectUpdateDto);
         return NoContent();
      }

      [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
      [HttpPatch("{id}")]
      public async Task<IActionResult> PatchMotorolaProject(int id, JsonPatchDocument motorolaProjectPatch)
      {
         await _motorolaProjectService.PatchAsync(mp => mp.Id == id, motorolaProjectPatch);
         return NoContent();
      }
   }
}
