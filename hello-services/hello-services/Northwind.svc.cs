using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;

namespace hello_services
{
    using Data;
    using DataServicesJSONP;

    [System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    [JSONPSupportBehavior]
    public class Northwind : DataService<NorthwindEntities>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
            // Examples:
            // config.SetEntitySetAccessRule("MyEntityset", EntitySetRights.AllRead);
            // config.SetServiceOperationAccessRule("MyServiceOperation", ServiceOperationRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
            
            // Grant only the rights needed to support the client applications.
            config.SetEntitySetAccessRule("Orders", EntitySetRights.AllRead
                 | EntitySetRights.WriteMerge
                 | EntitySetRights.WriteReplace);
            config.SetEntitySetAccessRule("Order_Details", EntitySetRights.AllRead
                | EntitySetRights.AllWrite);
            config.SetEntitySetAccessRule("Customers", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("Products", EntitySetRights.AllRead
                | EntitySetRights.WriteReplace);
        }
    }
}
