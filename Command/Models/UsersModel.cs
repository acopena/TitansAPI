using System;
using System.Collections.Generic;
using System.Text;

namespace TitansAPI.Command.Models
{
    public class UsersModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? AssociationId { get; set; }
        public string AssociationName { get; set; }
        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public string AccessCode { get; set; }
        public string CellPhone { get; set; }
        public bool? BlockAccount { get; set; }

        //Season 
        public int SeasonId{ get; set; }
        public string  SeasonName { get; set; }

        //Cart
        public Guid? cartGuid { get; set; }
        
    }

    public class UserUrlModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserUrlUpdateModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public bool? BlockAccount { get; set; }
    }
}
