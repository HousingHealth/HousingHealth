using HH.DB.Models;
using System.Collections.Generic;
using System.Linq;

namespace HH.DBQueries
{
    public class AddressQuery
    {
        HousingHealthDB db = new HousingHealthDB();

        public List<string> GetAddressInfo()
        {
            List<string> addrList = (from prop in db.Properties
                                     select prop.number + " " + prop.street + " " + prop.MAIL_CITY + " "+ prop.MAIL_STATE
                                     ).ToList();

            return addrList;

        }

    }
}
