using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fst_QRCode_eCheckIn.Models
{
    public class RegistrationMdl
    {
        public string qrCodeImgUrl { get; set; }
        public int QRCodeTotp { get; set; }
        public string empName { get; set; }
        public string empDepartment { get; set; }
        public int Id { get; set; }
    }
}