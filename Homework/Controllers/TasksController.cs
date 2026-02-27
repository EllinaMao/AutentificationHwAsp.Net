using Homework.Interfaces;
using Homework.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[Authorize]
public class TasksController : Controller
{
    private readonly ITask _taskRepo;
    public TasksController(ITask taskRepo) => _taskRepo = taskRepo;

    private int CurrentUserId => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

    public async Task<IActionResult> Index(string search)
    {
        var tasks = await _taskRepo.GetTasksAsync(CurrentUserId, search);
        return View(tasks);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TaskItem task)
    {
        task.UserId = CurrentUserId;
        await _taskRepo.AddTaskAsync(task);
        return RedirectToAction("Index");
    }

    [Authorize(Policy = "CompanyEmployee")]
    public IActionResult CorporateDocs() => View();
}