using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace GigHub.ViewModels
{
    public class FutureTimeValidation : ValidationAttribute
    {
        public override bool IsValid(object time)
        {
            DateTime outputTime;
            bool isFutueTime = false;
            //is valid date format
            #region Parsing Date
            bool isValid = DateTime.TryParseExact(Convert.ToString(time),//passed date parameter
                "HH:mm", //dateformat
                CultureInfo.CurrentCulture, //culture
                DateTimeStyles.None,//style
                out outputTime);//out parameter 
            #endregion
            //is future time
            #region Future Time
            if (isValid)
            {
                isFutueTime = outputTime > DateTime.Now;
            }
            #endregion
            return isValid && isFutueTime;

        }

    }

}