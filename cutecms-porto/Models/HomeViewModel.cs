using cutecms_porto.Areas.CMS.Models.DBModel;
using System.Collections.Generic;
namespace cutecms_porto.Models
{
    public class HomeViewModel
    {
        #region Properties
        public IEnumerable<ImageFile> HomeGallery { get; set; }
        //public List<Event> Events { get; set; }
        public IEnumerable<Content> Contents { get; set; }
        public IEnumerable<ContentList> ContentLists { get; internal set; }
        #endregion Properties
    }
}