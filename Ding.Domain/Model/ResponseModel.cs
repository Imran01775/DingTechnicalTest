using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ding.Domain
{
    [Serializable]
    public class ResponseModel : GeneralModel//, IContentModel
    {
        public string Result { set; get; }
        public int TransactionID { set; get; }
        public int TransactionNumber { set; get; }
        public string PhoneNumber { set; get; }
        public string Amount { set; get; }
    }

    public class ResponseModelValidator : AbstractValidator<ResponseModel>
    {
        public ResponseModelValidator()
        {
            RuleFor(x => x.PhoneNumber).Matches("^[0-9]+$").NotNull().Length(1, 10);
            RuleFor(x => x.Result).Matches("^[0-9]+$").NotNull().Length(1, 2);
            RuleFor(x => x.Amount).Matches("^[0-9]+$").NotNull().Length(1, 12);
        }
    }

}
