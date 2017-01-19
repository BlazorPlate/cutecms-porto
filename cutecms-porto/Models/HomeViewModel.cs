using cutecms_porto.Areas.CMS.Models.DBModel;
using System.Collections.Generic;
namespace cutecms_porto.Models
{
    public class HomeViewModel
    {
        #region Properties
        public List<ImageFile> HomeGallery { get; set; }
        //public List<Event> Events { get; set; }
        public List<Content> Contents { get; set; }
        public List<ContentList> ContentLists { get; internal set; }
        #endregion Properties
    }
}