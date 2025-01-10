using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApplication.DataAccess.Context;
using QuizApplication.DataAccess.Contracts;
using QuizApplication.DataAccess.Models;

namespace QuizApplication.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionsController(IQuestionRepository repo) : ControllerBase
{
    // GET: api/Questions
    [HttpGet]
    public async Task<IResult> GetQuestions()
    {
        var res = await repo.GetAllAsync();

        return TypedResults.Ok(res);
    }

    // GET: api/Questions/5
    [HttpGet("{id}")]
    public async Task<IResult> GetQuestion(int id)
    {
        var res = await repo.GetSingleAsync(id);

        if (res == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(res);
    }

    // PUT: api/Questions/5
    [HttpPut("{id}")]
    public async Task<IResult> PutQuestion(int id, Question question)
    {
        if (id != question.Id)
        {
            return TypedResults.BadRequest();
        }

        await repo.UpdateAsync(question);

        return TypedResults.Ok();
    }

    // POST: api/Questions
    [HttpPost]
    public async Task<IResult> PostQuestion(Question question)
    {
        var res = await repo.AddAsync(question);

        return TypedResults.Ok(res);
    }

    // DELETE: api/Questions/5
    [HttpDelete("{id}")]
    public async Task<IResult> DeleteQuestion(int id)
    {
        await repo.DeleteAsync(id);

        return TypedResults.Ok();
    }
}
