//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cutecms_porto.Areas.Identity.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class IdentityDepartment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IdentityDepartment()
        {
            this.Departments1 = new HashSet<IdentityDepartment>();
            this.EmpInDepts = new HashSet<EmpInDept>();
            this.DepartmentTerms = new HashSet<IdentityDepartmentTerm>();
        }

        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Code", ResourceType = typeof(Resources.Resources))]
        public string Code { get; set; }
        [Display(Name = "Manager", ResourceType = typeof(Resources.Resources))]
        public Nullable<int> ManagerId { get; set; }
        [Display(Name = "Parent", ResourceType = typeof(Resources.Resources))]
        public Nullable<int> ParentId { get; set; }
        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Ordinal", ResourceType = typeof(Resources.Resources))]
        public int Ordinal { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IdentityDepartment> Departments1 { get; set; }
        public virtual IdentityDepartment Department1 { get; set; }
        public virtual Employee Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmpInDept> EmpInDepts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IdentityDepartmentTerm> DepartmentTerms { get; set; }
    }
}