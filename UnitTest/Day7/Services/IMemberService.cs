using Day7.Models;
namespace Day7.Services
{
    public interface IMemberService
    {
        MembeModel GetMemberById(int id);
        List<MembeModel> GetAllPeople();
        void CreateMember(MembeModel member);
        void DeleteMember(MembeModel member);
        void EditMember(MembeModel member);
    }
}