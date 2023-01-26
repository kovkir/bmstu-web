using db_cp.DTO;
using db_cp.ModelsBL;
using db_cp.Services;

namespace db_cp.ModelsConverters
{
    public class UserConverters
    {
        private readonly IUserService userService;

        public UserConverters(IUserService userService)
        {
            this.userService = userService;
        }

        public UserBL convertPatch(int id, UserPasswordDto user)
        {
            var existedUser = userService.GetByID(id);

            return new UserBL
            {
                Id = id,
                Login = user.Login ?? existedUser.Login,
                Password = user.Password ?? existedUser.Password,
                Permission = user.Permission ?? existedUser.Permission
            };
        }
    }
}
