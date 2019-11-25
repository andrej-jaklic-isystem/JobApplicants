using System;
using System.Collections.Generic;

namespace Test01.Data.Models.Ident
{
    public partial class AppUsers
    {
        public AppUsers()
        {
            AppSettings = new HashSet<AppSettings>();
            AppSyslog = new HashSet<AppSyslog>();
            AppTokens = new HashSet<AppTokens>();
            AppUserRoles = new HashSet<AppUserRoles>();
        }

        public int Id { get; set; }
        public int? Idcontact { get; set; }
        public string Osusername { get; set; }
        public string Displayname { get; set; }
        public bool? Isactive { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public DateTime? Cdate { get; set; }
        public string Cuser { get; set; }
        public int? Idsecuritytype { get; set; }
        public string Appusername { get; set; }
        public string Apppassword { get; set; }
        public string Winusername { get; set; }
        public string Email { get; set; }
        public string Emailsignature { get; set; }
        public string Passwordhash { get; set; }
        public int? Accessfailedcount { get; set; }
        public string Concurrencystamp { get; set; }
        public bool? Emailconfirmed { get; set; }
        public bool? Lockoutenabled { get; set; }
        public DateTime? Lockoutend { get; set; }
        public string Normalizedemail { get; set; }
        public string Normalizedusername { get; set; }
        public string Phonenumber { get; set; }
        public bool? Phonenumberconfirmed { get; set; }
        public string Securitystamp { get; set; }
        public bool? Twofactorenabled { get; set; }
        public string Username { get; set; }

        public virtual AppSecuritytypes IdsecuritytypeNavigation { get; set; }
        public virtual ICollection<AppSettings> AppSettings { get; set; }
        public virtual ICollection<AppSyslog> AppSyslog { get; set; }
        public virtual ICollection<AppTokens> AppTokens { get; set; }
        public virtual ICollection<AppUserRoles> AppUserRoles { get; set; }
    }
}
