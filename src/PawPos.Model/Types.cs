using System;
using System.Collections.Generic;
using System.Text;

namespace PawPos.Model
{
    public class Types
    {
        public enum Response
        {
            Ok = 1,
            Warning = 2,
            Error = 3
        }
        public enum CompanyType
        {
            PawPos = 0,
            AccountOwner = 1,
            Group = 2,
            Company = 3
        }
        public enum UserType
        {
            Person=1,
            App=2
        }
        public enum ServingType
        {
            Table=1,
            Self=2,
            Delivery=3
        }

        public enum AssetType
        {
            Table=1,
            Customer=2
        }

        public enum TicketType
        {
            Addition=1
        }

        public enum CollectType
        {
            Cash=1,
            CreditCard=2,
            Ticket=3
        }

    }
}
