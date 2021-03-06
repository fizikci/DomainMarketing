﻿namespace DealerSafe2.DTO.Request
{
    public class ReqLoginWithFacebook : BaseRequest
    {
        public string FacebookId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Avatar { get; set; }
        public string Nick { get; set; }
        public string Gender { get; set; }
    }
}
