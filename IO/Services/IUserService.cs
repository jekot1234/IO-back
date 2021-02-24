using IO.Model;
using System.Collections.Generic;

namespace IO.Services
{
    public interface IUserService
    {
        User Create(User user);
        List<User> Get();
        User Get(string id);
        void Remove(string id);
        void Remove(User userIn);
        void Update(string id, User userIn);
    }
}