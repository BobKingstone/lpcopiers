using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LPCopiers.Helpers
{
    public class DateRange : ValidationAttribute
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public DateRange()
        {
            this.Min = 7;
            this.Max = 90;
        }

        public override bool IsValid(object value)
        {
            var dt = (DateTime)value;
            var NowPlusSevenDays = DateTime.Now.AddDays(Min);
            var NowPlusNinetyDays = DateTime.Now.AddDays(Max);
            if (dt > NowPlusSevenDays && dt < NowPlusNinetyDays)
            {
                return true;
            }
            return false;
        }
    }
}