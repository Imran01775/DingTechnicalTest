using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ding.Domain
{
    [Serializable]
    public class GeneralModel
    {
        [StringLength(8, ErrorMessage = "Maximum Length 8 ")]
        public string MessageDate { get { return DateTime.Now.ToString("ddMMyyyy"); } }
        [StringLength(6, ErrorMessage = "Maximum Length 6 ")]
        public string MessageTime { get { return DateTime.Now.ToString("hhmmss"); } }
    }

    public interface ICompmany
    {
        [StringLength(3, ErrorMessage = "Maximum Length 3 ")]
        public string Identifier { get; }
    }

    public interface IContentModel
    {
        [StringLength(12, ErrorMessage = "Maximum Length 12 ")]
        public string PhoneNumber { set; get; }
        [StringLength(10, ErrorMessage = "Maximum Length 10 ")]
        public string Amount { set; get; }
    }
    public class StatusModel
    {
        public string Success = "01";
        public string Failure = "99";
        public string InvalidMessage = "999";
    }

}

