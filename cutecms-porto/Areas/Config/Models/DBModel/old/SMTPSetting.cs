//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cutecms_porto.Areas.Config.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class SMTPSetting
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SMTPSetting()
        {
            this.Notifications = new HashSet<Notification>();
        }

        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Code", ResourceType = typeof(Resources.Resources))]
        public string Code { get; set; }
        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "SMTP", ResourceType = typeof(Resources.Resources))]
        public string SMTP { get; set; }
        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Port", ResourceType = typeof(Resources.Resources))]
        public int Port { get; set; }
        [Display(Name = "EnableSsl", ResourceType = typeof(Resources.Resources))]
        public bool EnableSsl { get; set; }
        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "SenderEmail", ResourceType = typeof(Resources.Resources))]
        public string SenderEmail { get; set; }
        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "SenderPassword", ResourceType = typeof(Resources.Resources))]
        public string SenderPasswordHash { get; set; }
        [Display(Name = "RecipientEmail", ResourceType = typeof(Resources.Resources))]
        public string RecipientEmail { get; set; }
        [Display(Name = "Visible", ResourceType = typeof(Resources.Resources))]
        public bool Visible { get; set; }
        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Ordinal", ResourceType = typeof(Resources.Resources))]
        public int Ordinal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}