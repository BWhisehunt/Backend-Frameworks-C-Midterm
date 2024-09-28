using midterm_project.Models;
using midterm_project.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace midterm_project.Controllers;

public class PetController : Controller
{
    private readonly ILogger<PetController> _logger;
    private readonly IPetRepository _petRepository;

    public PetController(ILogger<PetController> logger, IPetRepository repository)
    {
        _logger = logger;
        _petRepository = repository;
    }

    public IActionResult Index() {
        return RedirectToAction("List");
    }

    public IActionResult List()
    {
        return View(_petRepository.GetAllPets());
    }

public IActionResult Detail(int id)
{
    // Retrieve the pet by its ID
    var pet = _petRepository.GetPetById(id);

    if (pet == null) 
    {
        return NotFound();
    }

    return View(pet);
}

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var pet = _petRepository.GetPetById(id);
        if (pet == null)
        {
            return NotFound();
        }
        return View(pet);
    }

    [HttpPost]
    public IActionResult Edit(Pet pet)
    {
        if (ModelState.IsValid)
        {
            _petRepository.UpdatePet(pet);
            return RedirectToAction("List");
        }

        return View(pet);
    }

    [HttpGet]
    public IActionResult New() 
    {
        return View();
    }

    [HttpPost]
    public IActionResult New(Pet pet) 
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        
        _petRepository.CreatePet(pet);

        return RedirectToAction("List");
    }

    public IActionResult Delete(int id) 
    {
        _petRepository.DeletePetById(id);

        return RedirectToAction("List");
    }
}