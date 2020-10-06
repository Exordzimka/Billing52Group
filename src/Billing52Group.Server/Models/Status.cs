﻿using System.Collections.Generic;

namespace Billing52Group.Server.Models
{
    public class Status
    {
        public Status() => Contractstatus = new HashSet<ContractStatus>();

        public int Id { get; set; }

        public string Title { get; set; }

        public string Comment { get; set; }

        public virtual ICollection<ContractStatus> Contractstatus { get; set; }
    }
}
