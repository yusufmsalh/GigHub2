using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace GigHub.ViewModels
{
    public class FutureDateValidation :ValidationAttribute
    {
       public  override bool IsValid(object date)
       {
            DateTime outputDate;
            bool isFutueDate = false;
            //is valid date format
            #region Parsing Date
            bool isValid = DateTime.TryParseExact(Convert.ToString(date),//passed date parameter
              "dd/mm/yyyy", //dateformat
              CultureInfo.CurrentCulture, //culture
              DateTimeStyles.None,//style
              out outputDate);//out parameter 
            #endregion
            //is future date
            #region Future Date
            if (isValid)
            {
                isFutueDate = outputDate < DateTime.Now;
            } 
            #endregion
            return isValid && isFutueDate;

       }

    }

}