﻿namespace BackEnd.Dtos
{
    public class ChangePasswordRequest
    {
        public int Id { get; set; }

        public string OldPassword { get; set; }

         public string NewPassword { get; set; }
    }
}
