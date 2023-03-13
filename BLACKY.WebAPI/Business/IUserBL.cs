using BLACKY.WebAPI.Models;

namespace BLACKY.WebAPI.Business
{
    public interface IUserBL
    {
        int CreateUser(UserEntity userEntity);

        List <UserEntity> GetUserByID(int? userID);
        List<UserEntity> GetUserByUsername(string username);
        List<UserEntity> GetUserByEmailID(string emailID);
        List<UserEntity> GetUserByMobileNumber(string mobileNumber);

        bool UpdateUser(UserEntity userEntity);

        bool DeleteUser(UserEntity userEntity);

    }
}
