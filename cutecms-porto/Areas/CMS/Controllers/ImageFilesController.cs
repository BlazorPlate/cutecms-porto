using cutecms_porto.Areas.CMS.Models;
using cutecms_porto.Areas.CMS.Models.DBModel;
using cutecms_porto.Helpers;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace cutecms_porto.Areas.CMS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ImageFilesController : BaseController
    {
        #region Fields
        private CMSEntities db = new CMSEntities();
        #endregion Fields

        #region Methods
        // GET: Images
        public ActionResult Index(int? page, int id = 0)
        {
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var imageFiles = db.ImageFiles.Include("Gallery").Where(i => i.TenantId.Trim().Equals(Tenant.TenantId) && (i.GalleryId == id || id == 0)).OrderBy(i => i.GalleryId).ThenBy(i => i.CreatedOn).ToPagedList(pageNumber, 10); // will only contain 25 products max because of the pageSize
            ViewBag.GalleryIdFilter = new SelectList(TermsHelper.Galleries(), "GalleryId", "Value");
            ViewBag.GalleryId = id;
            return View(imageFiles);
        }

        // GET: Images/Create
        public ActionResult Create()
        {
            var imageWithTags = new CreateImageWithTagsViewModel();
            ViewBag.GalleryId = new SelectList(TermsHelper.Galleries(), "GalleryId", "Value");
            return View(imageWithTags);
        }

        // POST: Images/Create To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateImageWithTagsViewModel imageWithTagsVM, int? width, int? height)
        {
            if (ModelState.IsValid)
            {
                if (imageWithTagsVM.ImageFiles.Where(file => file != null).Count() == 0)
                {
                    ModelState.AddModelError("ERROR", Resources.Resources.PleaseUploadImageOfType);
                    ViewBag.GalleryId = new SelectList(TermsHelper.Galleries(), "GalleryId", "Value", imageWithTagsVM.GalleryId);
                    return View(imageWithTagsVM);
                }
                foreach (var file in imageWithTagsVM.ImageFiles)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        Random random = new Random();
                        var imageFile = new ImageFile();
                        if (file.ContentLength == 0) continue;
                        var extension = System.IO.Path.GetExtension(file.FileName).ToLower();
                        imageFile.Code = imageWithTagsVM.ImageFile.Code.Trim();
                        imageFile.Ordinal = imageWithTagsVM.ImageFile.Ordinal;
                        var fileName = imageFile.Code.Replace(" ", "-");
                        fileName = fileName + "-" + random.Next(1, 10000).ToString() + extension;
                        imageFile.MIME = file.ContentType;
                        imageFile.CreatedOn = DateTime.Now;
                        imageFile.GalleryId = imageWithTagsVM.GalleryId;
                        imageFile.ThumbPath = String.Format("/fileman/Uploads/Images/CMS/Images/Thumbs/{0}", fileName);
                        imageFile.FilePath = String.Format("/fileman/Uploads/Images/CMS/Images/{0}", fileName);
                        using (var img = System.Drawing.Image.FromStream(file.InputStream))
                        {
                            if (width == null)
                                width = img.Width;
                            if (height == null)
                                height = img.Height;
                            // Save thumbnail size image, 100 x 100
                            ImageUploaderHelper.SaveThumbToFolder(img, extension, new Size(200, 200), imageFile.ThumbPath);
                            // Save large size image, 800 x 800
                            ImageUploaderHelper.SaveImageToFolder(img, extension, new Size(width.Value, height.Value), imageFile.FilePath);
                        }
                        imageFile.TenantId = Tenant.TenantId;
                        db.ImageFiles.Add(imageFile);
                        db.SaveChanges();
                        foreach (var item in imageWithTagsVM.Tags)
                        {
                            if (item.Selected)
                            {
                                AddTagToFile(imageFile.Id, item.TagId);
                            }
                        }
                    }
                }
                return RedirectToAction("Index");
            }
            ViewBag.GalleryId = new SelectList(TermsHelper.Galleries(), "GalleryId", "Value", imageWithTagsVM.GalleryId);
            return View(imageWithTagsVM);
        }

        // GET: Images/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ImageFile imageFile = db.ImageFiles.Where(i => i.TenantId.Trim().Equals(Tenant.TenantId) && i.Id == id).FirstOrDefault();
            var model = new EditImageWithTagsViewModel(imageFile);
            if (imageFile == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.GalleryId = new SelectList(TermsHelper.Galleries(), "GalleryId", "Value", model.ImageFile.GalleryId);
            return View(model);
        }

        // POST: Images/Edit/5 To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditImageWithTagsViewModel imageWithTagsVM)
        {
            if (ModelState.IsValid)
            {
                imageWithTagsVM.ImageFile.TenantId = Tenant.TenantId;
                db.Entry(imageWithTagsVM.ImageFile).State = EntityState.Modified;
                db.SaveChanges();
                var image = db.ImageFiles.First(u => u.Id == imageWithTagsVM.ImageFile.Id);
                ClearFileTags(image.Id);
                foreach (var tag in imageWithTagsVM.Tags)
                {
                    if (tag.Selected)
                    {
                        AddTagToFile(imageWithTagsVM.ImageFile.Id, tag.TagId);
                    }
                }
                return RedirectToAction("Index");
            }
            ViewBag.GalleryId = new SelectList(TermsHelper.Galleries(), "GalleryId", "Value", imageWithTagsVM.ImageFile.GalleryId);
            return View(imageWithTagsVM);
        }

        // GET: Images/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ImageFile imageFile = db.ImageFiles.Where(i => i.TenantId.Trim().Equals(Tenant.TenantId) && i.Id == id).FirstOrDefault();
            if (imageFile == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(imageFile);
        }

        // POST: Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImageFile imageFile = db.ImageFiles.Find(id);
            foreach (var item in imageFile.ImageTags.ToList())
            {
                db.ImageTags.Remove(item);
            }
            db.ImageFiles.Remove(imageFile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public void AddTagToFile(int imageId, int TagId)
        {
            ImageFile image = db.ImageFiles.Find(imageId);
            Tag tag = db.Tags.First(r => r.Id == TagId);
            var newImageTag = new ImageTag
            {
                ImageFileId = image.Id,
                ImageFile = image,
                TagId = tag.Id,
                Tag = tag
            };

            // make sure the imageTag is not already present
            if (!image.ImageTags.Contains(newImageTag))
            {
                image.ImageTags.Add(newImageTag);
                db.SaveChanges();
            }
        }

        public void ClearFileTags(int imageId)
        {
            List<ImageTag> imageTags = db.ImageTags.Where(it => it.ImageFileId.Equals(imageId)).ToList();
            foreach (var item in imageTags)
            {
                db.ImageTags.Remove(item);
            }
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion Methods
    }
}