using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConNhaNong.Models
{
    public static class Status
    {
        public enum Status_Contact 
        {
            E_Waitting,
            E_Confirm,
            E_Delete
        }
    }
}