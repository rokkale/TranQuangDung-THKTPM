﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.Model.BaseTypes
{
    public static  class Constants
    {
    }
    public enum Roles
    {
        Admin, Engineer, User
    }
    public enum MasterKeys
    {
        VehicleName, VehicleTypes
    }
    public enum Status
    {
        New, Denied, Pending, Initiated, InProgress, PendingCustomerApproval,
        RequestForInformation, Completed
    }
}
