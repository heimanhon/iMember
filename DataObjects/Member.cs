using Microsoft.WindowsAzure.Mobile.Service;
using System;

namespace csdataserviceService.DataObjects
{
    public class Member : EntityData
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Store { get; set; }
        public string MemberId { get; set; }
        public string MemberName { get; set; }
        public DateTime MemberExpiry { get; set; }        
    }
}