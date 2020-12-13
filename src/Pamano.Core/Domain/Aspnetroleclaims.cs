using System;
using System.Collections.Generic;

namespace Pamano.Core.Domain
{
    public partial class Aspnetroleclaims
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public virtual Aspnetroles Role { get; set; }
    }
}
