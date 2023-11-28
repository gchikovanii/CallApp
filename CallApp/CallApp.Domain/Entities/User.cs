﻿namespace CallApp.Domain.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
