namespace BackEnd.Dtos
{
    public class UserDtoGetter
    {
        public UserDtoGetter(string name, string surname, string email, string phNumber) 
        { 
            Name = name;
            Surname = surname;
            Email = email;
            PhoneNumber = phNumber;
        }
        public string Name { get; }
        public string Surname { get; }
        public string Email { get; }
        public string PhoneNumber { get; }
    }
}
