using LifeCrawler.Models;
using Microsoft.AspNetCore.Mvc;

namespace LifeCrawler.Controllers;

[ApiController]
[Route("[controller]")]
public class HabitController : ControllerBase
{
    private readonly ILogger<HabitController> _logger;

    public HabitController(ILogger<HabitController> logger)
    {
        _logger = logger;
    }

    [HttpPost("{name, description, frequency, isAntiHabit}", Name = "CreateHabit")]
    public ActionResult<Habit> CreateHabit(string name, string? description, float frequency, bool isAntiHabit)
    {
        if (description == "")
            description = null;
        var habit = new Habit(name, description, frequency, isAntiHabit);

        return Created("", habit);
    }
}