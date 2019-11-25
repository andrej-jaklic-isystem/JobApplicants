using System;
using System.Collections.Generic;

namespace Test01.Data.Models.Ident
{
    public partial class Customers
    {
        public int Id { get; set; }
        public int? Id1 { get; set; }
        public string Code { get; set; }
        public string Company { get; set; }
        public string Company1 { get; set; }
        public string Description { get; set; }
        public string Street { get; set; }
        public string Street1 { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Post { get; set; }
        public string Homepage { get; set; }
        public string Telefon1 { get; set; }
        public string Telefon2 { get; set; }
        public string Telefax { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public string Email { get; set; }
        public string Vatnumber { get; set; }
        public string Source { get; set; }
        public int? Status { get; set; }
        public string Suppliercode { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public int Version { get; set; }
    }
}
