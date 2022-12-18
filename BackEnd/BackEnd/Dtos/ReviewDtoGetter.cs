using Azure.Identity;

namespace BackEnd.Dtos
{
    public class ReviewDtoGetter
    {
        public ReviewDtoGetter(int idUser, string userName, string userSurname, string comment)
        {
            IDUser = idUser;
            UserName = userName;
            UserSurname = userSurname;
            Comment = comment;
        }

        public int IDUser { get; }
        public string UserName { get; }
        public string UserSurname { get; }
        public string Comment { get; }
    }
}
