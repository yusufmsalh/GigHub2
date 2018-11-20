﻿using System;
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
            DateTime outputDateTime;
            bool isFutueDate = false;
            //is valid date format
            #region Parsing Date
            bool isValid = DateTime.TryParseExact(Convert.ToString(date),//passed date parameter
              "d MM yyyy", //dateformat
              CultureInfo.CurrentCulture, //culture
              DateTimeStyles.None,//style
              out outputDateTime);//out parameter 
            #endregion
            //is future date
            #region Future Date
            if (isValid)
            {
                isFutueDate = outputDateTime > DateTime.Now;
            } 
            #endregion
            return isValid && isFutueDate;

       }

    }
}