namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using WebApplication1.Models;

    public partial class UserVM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserVM()
        {
            this.Customers = new HashSet<Customer>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}