using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HH.DBQueries;
using HH.DBQueries.DTOs;

namespace HH.Business
{
    public class Calculations
    {

            public string IsleadRisk (int propertyID, int yrBuilt, string Message)
            {

            // QueryMethods qm = new QueryMethods();
            // PropertyDTO propDTO= qm.GetPropertyInfoByID((int)propertyID);
            //  propDTO.Yrbuilt = yrBuilt;
            //    {
            if ((yrBuilt == 1978) || (yrBuilt > 1978))
            {
                Message = "Property has No Lead Risk ";
            }
            else
            {
                Message = "Property has Lead Risk";
            }

            return (Message);

                }

            }
    }
//}