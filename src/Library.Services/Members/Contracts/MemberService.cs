using Library.Services.Members.Contracts;

namespace Library.Services.Members
{
    public interface MemberService
    {
        int Add(AddMemberDto dto);
    }
}