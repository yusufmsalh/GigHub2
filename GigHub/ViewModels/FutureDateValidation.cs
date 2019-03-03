using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace GigHub.ViewModels
{
    public class FutureDateValidation : ValidationAttribute
    {
        public override bool IsValid(object date)
        {
            DateTime outputDate;
            bool isFutueDate = false;
            //is valid date format
            #region Parsing Date
            System.Globalization.CultureInfo enUS =
                new System.Globalization.CultureInfo("en-US");
            bool isValid = DateTime.TryParseExact(Convert.ToString(date),//passed date parameter
              "dd/MM/yyyy", //dateformat
                enUS,  //CultureInfo.CurrentCulture Next Phase : Arabic
              DateTimeStyles.None,//style
              out outputDate);//out parameter 
            #endregion
            //is future date
            #region Future Date
            if (isValid)
            {
                isFutueDate = true;
                //  isFutueDate = outputDate > (DateTime.Now.AddDays(-1));
            }
            #endregion
            return isValid && isFutueDate;

        }

    }

}