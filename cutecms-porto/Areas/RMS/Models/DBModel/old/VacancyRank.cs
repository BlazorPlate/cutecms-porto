//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cutecms_porto.Areas.RMS.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class VacancyRank
    {
        public int Id { get; set; }
        [Display(Name = "Vacancy", ResourceType = typeof(Resources.Resources))]
        public int VacancyId { get; set; }
        [Display(Name = "Rank", ResourceType = typeof(Resources.Resources))]
        public int RankId { get; set; }

        public virtual RMSRank Rank { get; set; }
        public virtual Vacancy Vacancy { get; set; }
    }
}
