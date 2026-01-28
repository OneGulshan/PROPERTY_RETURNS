using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Telerik.Web.UI;
using System.Globalization;
using System.Text.RegularExpressions;

namespace PROPERTY_RETURNS
{
    public class GLB_FNS
    {
        public int FnValidateDate(string value)
        {
            int flag = 0;
            DateTimeFormatInfo info = new DateTimeFormatInfo();
            CultureInfo culture;
            culture = CultureInfo.CreateSpecificCulture("en-US");
            info.ShortDatePattern = "dd/MM/yyyy";
            DateTime value_d;
            if (DateTime.TryParse(value, info, DateTimeStyles.None, out value_d))
            {
                flag = 1;
            }
            return flag;
        }

        public int FnValidateInt(string value)
        {
            int flag = 0;
            int value_i;
            if (int.TryParse(value, out value_i))
            {
                flag = 1;
            }
            return flag;
        }

        public int FnValidateFloat(string value)
        {
            
            string updatevalue = value;
            //alert(value);

            Regex charsToDestroy = new Regex(@"[^\d|\.\-]");

            value = charsToDestroy.Replace(updatevalue, "");
            
            int flag = 0;
            decimal value_f;
            if (decimal.TryParse(value, out value_f))
            {
                flag = 1;
            }
            return flag;
        }
    }
}