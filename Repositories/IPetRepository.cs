using midterm_project.Models;

namespace midterm_project.Repositories;
public interface IPetRepository {
    IEnumerable<Pet> GetAllPets();
    Pet GetPetById(int PetId);
    Pet CreatePet(Pet pet);
    Pet UpdatePet(Pet pet);
    void DeletePetById(int PetId);
}