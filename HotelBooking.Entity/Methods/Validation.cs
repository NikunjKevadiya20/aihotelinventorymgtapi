using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HotelBooking.Entity.Common.Methods
{
    public class Validation
    {
        public Boolean IsPancardValid(string pancard)
        {

            Regex regex = new Regex("([A-Z]){5}([0-9]){4}([A-Z]){1}$");
            if (!regex.IsMatch(pancard.Trim()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Boolean IsGstValid(string gst)
        {

            Regex regex = new Regex("[0-9]{2}[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}[1-9]{1}[Zz]{1}[0-9A-Z]{1}");
            if (!regex.IsMatch(gst.Trim()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Boolean IsAadharValid(string aadhar)
        {

            Regex regex = new Regex("^[2-9]{1}[0-9]{3}\\s[0-9]{4}\\s[0-9]{4}$");
            if (!regex.IsMatch(aadhar.Trim()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Boolean IsPassportValid(string passport)
        {

            Regex regex = new Regex("^[A-PR-WYa-pr-wy][1-9]\\d\\s?\\d{4}[1-9]$");
            if (!regex.IsMatch(passport.Trim()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Boolean IsMobileValid(string mobile)
        {

            Regex regex = new Regex("(0|91)?[5-9][0-9]{9}");
            if (!regex.IsMatch(mobile.Trim()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
