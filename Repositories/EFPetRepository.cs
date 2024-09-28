using midterm_project.Migrations;
using midterm_project.Models;

namespace midterm_project.Repositories;

public class EFPetRepository : IPetRepository 
{
    private readonly PetDbContext _context;

    public EFPetRepository(PetDbContext context)
    {
        _context = context;
    }

    public Pet CreatePet(Pet newPet)
    {
        _context.Pets.Add(newPet);
        _context.SaveChanges();
        return newPet;
    }

    public void DeletePetById(int petId)
    {
        var pet = _context.Pets.Find(petId); 
        if (pet != null) {
            _context.Pets.Remove(pet); 
            _context.SaveChanges(); 
        }
    }

    public IEnumerable<Pet> GetAllPets()
    {
        return _context.Pets.ToList();
    }

    public Pet GetPetById(int petId)
    {
        return _context.Pets.SingleOrDefault(c => c.PetId == petId);
    }

    public Pet UpdatePet(Pet newPet)
    {
        var originalPet = _context.Pets.Find(newPet.PetId);
        if (originalPet != null) {
            originalPet.Name = newPet.Name;
            originalPet.ImgUrl = newPet.ImgUrl;
            originalPet.Type = newPet.Type;
            originalPet.Description = newPet.Description;
            originalPet.Age = newPet.Age;
            originalPet.Price = newPet.Price;
            _context.SaveChanges();
        }
        return originalPet;
    }
}