﻿using System;
using System.Collections.Generic;

namespace Pamano.Core.Domain
{
    public partial class Aspnetusers
    {
        public Aspnetusers()
        {
            Aspnetuserclaims = new HashSet<Aspnetuserclaims>();
            Aspnetuserlogins = new HashSet<Aspnetuserlogins>();
            Aspnetuserroles = new HashSet<Aspnetuserroles>();
            Aspnetusertokens = new HashSet<Aspnetusertokens>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public virtual ICollection<Aspnetuserclaims> Aspnetuserclaims { get; set; }
        public virtual ICollection<Aspnetuserlogins> Aspnetuserlogins { get; set; }
        public virtual ICollection<Aspnetuserroles> Aspnetuserroles { get; set; }
        public virtual ICollection<Aspnetusertokens> Aspnetusertokens { get; set; }
    }
}
