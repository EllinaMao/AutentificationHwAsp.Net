using Homework.Extensions;
using Homework.Interfaces;
using Homework.Models;
using Homework.ViewModels;
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
    public async Task<IActionResult> Create(TaskItemViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Index");
        }

        var task = viewModel.ToTaskItem(CurrentUserId);

        await _taskRepo.AddTaskAsync(task);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _taskRepo.DeleteTaskAsync(id, CurrentUserId);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> ToggleStatus(int id)
    {
        await _taskRepo.ToggleTaskStatusAsync(id, CurrentUserId);
        return RedirectToAction("Index");
    }

    [Authorize(Policy = "CompanyEmployee")]
    public IActionResult CorporateDocs() => View();

    [Authorize(Policy = "AdultOnly")]
    public IActionResult AdultContent() => View();
}