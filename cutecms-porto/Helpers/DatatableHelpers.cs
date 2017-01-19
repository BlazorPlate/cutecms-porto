using cutecms_porto.Areas.CMS.Models;
using cutecms_porto.Areas.RMS.Models;
using cutecms_porto.Areas.RMS.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace cutecms_porto.Helpers
{
    public class DatatableHelpers
    {
        #region Enums
        /// <summary>
        /// Sort orders of jQuery DataTables.
        /// </summary>
        public enum DTOrderDir
        {
            ASC,
            DESC
        }
        #endregion Enums
        #region Classes
        /// <summary>
        /// A full result, as understood by jQuery DataTables.
        /// </summary>
        /// <typeparam name="T">The data type of each row.</typeparam>
        public class DTResult<T>
        {
            #region Properties
            /// <summary>
            /// The draw counter that this object is a response to - from the draw parameter sent as
            /// part of the data request. Note that it is strongly recommended for security reasons
            /// that you cast this parameter to an integer, rather than simply echoing back to the
            /// client what it sent in the draw parameter, in order to prevent Cross Site Scripting
            /// (XSS) attacks.
            /// </summary>
            public int draw { get; set; }

            /// <summary>
            /// Total records, before filtering (i.e. the total number of records in the database)
            /// </summary>
            public int recordsTotal { get; set; }

            /// <summary>
            /// Total records, after filtering (i.e. the total number of records after filtering has
            /// been applied - not just the number of records being returned for this page of data).
            /// </summary>
            public int recordsFiltered { get; set; }

            /// <summary>
            /// The data to be displayed in the table. This is an array of data source objects, one
            /// for each row, which will be used by DataTables. Note that this parameter's name can
            /// be changed using the ajaxDT option's dataSrc property.
            /// </summary>
            public List<T> data { get; set; }
            #endregion Properties
        }

        /// <summary>
        /// The additional columns that you can send to jQuery DataTables for automatic processing.
        /// </summary>
        public abstract class DTRow
        {
            #region Properties
            /// <summary>
            /// Set the ID property of the dt-tag tr node to this value
            /// </summary>
            public virtual string DT_RowId
            {
                get { return null; }
            }

            /// <summary>
            /// Add this class to the dt-tag tr node
            /// </summary>
            public virtual string DT_RowClass
            {
                get { return null; }
            }

            /// <summary>
            /// Add this data property to the row's dt-tag tr node allowing abstract data to be added
            /// to the node, using the HTML5 data-* attributes. This uses the jQuery data() method to
            /// set the data, which can also then be used for later retrieval (for example on a click event).
            /// </summary>
            public virtual object DT_RowData
            {
                get { return null; }
            }
            #endregion Properties
        }

        /// <summary>
        /// The parameters sent by jQuery DataTables in AJAX queries.
        /// </summary>
        public class DTParameters
        {
            #region Properties
            /// <summary>
            /// Draw counter. This is used by DataTables to ensure that the Ajax returns from
            /// server-side processing requests are drawn in sequence by DataTables (Ajax requests
            /// are asynchronous and thus can return out of sequence). This is used as part of the
            /// draw return parameter (see below).
            /// </summary>
            public int Draw { get; set; }

            /// <summary>
            /// An array defining all columns in the table.
            /// </summary>
            public DTColumn[] Columns { get; set; }

            /// <summary>
            /// An array defining how many columns are being ordering upon - i.e. if the array length
            /// is 1, then a single column sort is being performed, otherwise a multi-column sort is
            /// being performed.
            /// </summary>
            public DTOrder[] Order { get; set; }

            /// <summary>
            /// Paging first record indicator. This is the start point in the current data set (0
            /// index based - i.e. 0 is the first record).
            /// </summary>
            public int Start { get; set; }

            /// <summary>
            /// Number of records that the table can display in the current draw. It is expected that
            /// the number of records returned will be equal to this number, unless the server has
            /// fewer records to return. Note that this can be -1 to indicate that all records should
            /// be returned (although that negates any benefits of server-side processing!)
            /// </summary>
            public int Length { get; set; }

            /// <summary>
            /// Global search value. To be applied to all columns which have searchable as true.
            /// </summary>
            public DTSearch Search { get; set; }

            /// <summary>
            /// Custom column that is used to further sort on the first Order column.
            /// </summary>
            public string SortOrder
            {
                get
                {
                    return Columns != null && Order != null && Order.Length > 0
                        ? (Columns[Order[0].Column].Data + (Order[0].Dir == DTOrderDir.DESC ? " " + Order[0].Dir : string.Empty))
                        : null;
                }
            }
            #endregion Properties
        }

        /// <summary>
        /// A jQuery DataTables column.
        /// </summary>
        public class DTColumn
        {
            #region Properties
            /// <summary>
            /// Column's data source, as defined by columns.data.
            /// </summary>
            public string Data { get; set; }

            /// <summary>
            /// Column's name, as defined by columns.name.
            /// </summary>
            public string Code { get; set; }

            /// <summary>
            /// Flag to indicate if this column is searchable (true) or not (false). This is
            /// controlled by columns.searchable.
            /// </summary>
            public bool Searchable { get; set; }

            /// <summary>
            /// Flag to indicate if this column is orderable (true) or not (false). This is
            /// controlled by columns.orderable.
            /// </summary>
            public bool Orderable { get; set; }

            /// <summary>
            /// Specific search value.
            /// </summary>
            public DTSearch Search { get; set; }
            #endregion Properties
        }

        /// <summary>
        /// An order, as sent by jQuery DataTables when doing AJAX queries.
        /// </summary>
        public class DTOrder
        {
            #region Properties
            /// <summary>
            /// Column to which ordering should be applied. This is an index reference to the columns
            /// array of information that is also submitted to the server.
            /// </summary>
            public int Column { get; set; }

            /// <summary>
            /// Ordering direction for this column. It will be dt-string asc or dt-string desc to
            /// indicate ascending ordering or descending ordering, respectively.
            /// </summary>
            public DTOrderDir Dir { get; set; }
            #endregion Properties
        }
        /// <summary>
        /// A search, as sent by jQuery DataTables when doing AJAX queries.
        /// </summary>
        public class DTSearch
        {
            #region Properties
            /// <summary>
            /// Global search value. To be applied to all columns which have searchable as true.
            /// </summary>
            public string Value { get; set; }

            /// <summary>
            /// true if the global filter should be treated as a regular expression for advanced
            /// searching, false otherwise. Note that normally server-side processing scripts will
            /// not perform regular expression searching for performance reasons on large data sets,
            /// but it is technically possible and at the discretion of your script.
            /// </summary>
            public bool Regex { get; set; }
            #endregion Properties
        }
        #endregion Classes
    }
    public class ResultSet
    {
        #region Methods
        public List<VacancyViewModel> GetVacancyResult(string search, string sortOrder, int start, int length, List<VacancyViewModel> dtResult, List<string> columnFilters)
        {
            if (length == -1)
                return FilterVacancyResult(search, dtResult, columnFilters).SortBy(sortOrder).ToList();
            return FilterVacancyResult(search, dtResult, columnFilters).SortBy(sortOrder).Skip(start).Take(length).ToList();
        }

        public int CountVacancy(string search, List<VacancyViewModel> dtResult, List<string> columnFilters)
        {
            return FilterVacancyResult(search, dtResult, columnFilters).Count();
        }

        public List<SubmissionViewModel> GetSubmissionResult(string search, string sortOrder, int start, int length, List<SubmissionViewModel> dtResult, List<string> columnFilters)
        {
            if (length == -1)
                return FilterSubmissionResult(search, dtResult, columnFilters).SortBy(sortOrder).ToList();
            return FilterSubmissionResult(search, dtResult, columnFilters).SortBy(sortOrder).Skip(start).Take(length).ToList();
        }
        public int CountSubmission(string search, List<SubmissionViewModel> dtResult, List<string> columnFilters)
        {
            return FilterSubmissionResult(search, dtResult, columnFilters).Count();
        }
        private IQueryable<VacancyViewModel> FilterVacancyResult(string search, List<VacancyViewModel> dtResult, List<string> columnFilters)
        {
            IQueryable<VacancyViewModel> results = dtResult.AsQueryable();
            results = results.Where(p => (search == null || (p.Code != null && p.Code.ToLower().Contains(search.ToLower()))
            || p.Title != null && p.Title.ToLower().Contains(search.ToLower())
            || p.PublishedOn != null && p.PublishedOn.ToLower().Contains(search.ToLower())
            || p.ExpiredOn != null && p.ExpiredOn.ToLower().Contains(search.ToLower()))
            && (columnFilters[3] == null || (p.Language != null && p.Language.ToLower().Contains(columnFilters[3].ToLower())))
            && (columnFilters[11] == null || (p.Status != null && p.Status.ToLower().Contains(columnFilters[11].ToLower()))));
            return results;
        }
        private IQueryable<SubmissionViewModel> FilterSubmissionResult(string search, List<SubmissionViewModel> dtResult, List<string> columnFilters)
        {
            IQueryable<SubmissionViewModel> results = dtResult.AsQueryable();
            results = results.Where(p => (search == null || ((p.Id.Contains(search)))
            || p.ApplicantFullName != null && p.ApplicantFullName.ToLower().Contains(search.ToLower()))
            && (columnFilters[3] == null || (p.VacancyTitle != null && p.VacancyTitle.ToLower().Contains(columnFilters[3].ToLower().Trim())))
            && (columnFilters[4] == null || (p.Department != null && p.Department.ToLower().Contains(columnFilters[4].ToLower().Trim()))));
            return results;
        }
        #endregion Methods
    }
}