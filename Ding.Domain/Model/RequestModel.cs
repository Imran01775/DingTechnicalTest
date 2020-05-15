using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Ding.Domain
{

    public class RequestModel : GeneralModel, ICompmany, IContentModel
    {
        public RequestModel()
        {
        }
        public RequestModel(int messageId)
        {
            this.MessageID = messageId;
        }
        public int MessageID { set; get; }
        [StringLength(3, ErrorMessage = "Maximum Length 3 ")]
        public string Identifier { get{ return "EZE"; } }
        [MaxLength(12)]
        [MinLength(1)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number must be digit")]
        public string PhoneNumber { set; get; }
        [Required]
        [MaxLength(10)]
        [MinLength(1)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Amount must be digit")]
        public string Amount { set; get; }
    }
    [XmlRoot("RequestModelRoot")]
    [Serializable]
    public class RequestToXmlModel
    {
        [XmlElement("Header")]
        public Header Header { set; get; }
        [XmlElement("Body")]
        public Body Body { set; get; }
    }


    public class Header : GeneralModel, ICompmany
    {
        public string Identifier { set; get; }
    }
    public class Body : IContentModel
    {
        public int MessageID { set; get; }
        public string PhoneNumber { set; get; }
        public string Amount { set; get; }
    }
}
