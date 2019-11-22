using System;
using System.Collections.Generic;
using System.Text;

namespace TitansAPI.Command.Models
{
    public class CartModel
    {
        public Guid CartGuid { get; set; }
        public int UserId { get; set; }
        public int CartStatusId { get; set; }
        public int SeasonId{ get; set; }
        public int AssociationId{ get; set; }
        public DateTime CartDate{ get; set; }
        public List<CartListModel> CartList{ get; set; }
        public CartModel()
        {
            CartList = new List<CartListModel>();
        }

    }

    public class CartListModel
    {
        public int MemberId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int DivisionId{ get; set; }
        public string DivisionName{ get; set; }

    }
}
