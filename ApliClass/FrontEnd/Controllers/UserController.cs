using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly UserService _UserService;

    public UserController(UserService UserService, ILogger<UserController> logger)
    {
        _UserService = UserService;
        _logger = logger;
    }

    [HttpGet]
    public ActionResult Index()
    {
        _logger.LogInformation("Retrieving all categories.");
        return View(_UserService.GetAll());
    }

    [HttpGet]
    public ActionResult Details(int Id)
    {
        _logger.LogInformation($"Retrieving details for User with Id: {Id}.");
        return View(_UserService.Get(Id));
    }

    [HttpGet]
    public ActionResult Create()
    {
        _logger.LogInformation("Rendering User create form.");
        return View();
    }

    [HttpPost]
    //[ValIdateAntiForgeryToken]
    public ActionResult Create(UserViewModel User)
    {
        try
        {
            _logger.LogInformation("Attempting to create a new User.");
            UserViewModel createdUser = _UserService.Create(User);
            _logger.LogInformation($"Created User with Id: {createdUser.Id}");
            return RedirectToAction("Details", new { createdUser.Id });
        }
        catch
        {
            _logger.LogError("An error occurred while creating a new User.");
            return View();
        }
    }

    [HttpGet]
    public ActionResult Edit(int Id)
    {
        _logger.LogInformation($"Rendering User edit form for User with Id: {Id}.");
        return View(_UserService.Get(Id));
    }

    [HttpPost]
    //[ValIdateAntiForgeryToken]
    public ActionResult Edit(UserViewModel User)
    {
        try
        {
            _logger.LogInformation($"Attempting to update User with Id: {User.Id}.");
            _UserService.Edit(User);
            _logger.LogInformation($"Updated User with Id: {User.Id}.");
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            _logger.LogError($"An error occurred while updating User with Id: {User.Id}.");
            return View();
        }
    }

    [HttpGet]
    public ActionResult Delete(int Id)
    {
        _logger.LogInformation($"Rendering User delete form for User with Id: {Id}.");
        return View(_UserService.Get(Id));
    }

    [HttpPost]
    //[ValIdateAntiForgeryToken]
    public ActionResult Delete(UserViewModel User)
    {
        try
        {
            _logger.LogInformation($"Attempting to delete User with Id: {User.Id}.");
            _UserService.Delete(User.Id);
            _logger.LogInformation($"Deleted User with Id: {User.Id}.");
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            _logger.LogError($"An error occurred while deleting User with Id: {User.Id}.");
            return View();
        }
    }
}