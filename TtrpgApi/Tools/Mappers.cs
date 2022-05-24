using TtrpgApi.Models;
using Model_BLL.Models;

namespace TtrpgApi.Tools
{
    public static class Mappers
    {
        public static Quester toModel(this NewQuesterInfo newQuester)
        {
            return new Quester
            {
                Username = newQuester.Username,
                Email = newQuester.Email,
                Password = newQuester.Password,
                BirthDate = newQuester.BirthDate
            };
        }
    }
}
