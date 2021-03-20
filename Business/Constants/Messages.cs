using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç eklendi!";
        public static string CarUpdated = "Araç güncellendi!";
        public static string CarDeleted = "Araç silindi!";
        public static string CarNameInvalid = "Araç ismi geçersiz!";
        internal static string MaintenanceTime = "Sistem bakımda";
        internal static string CarsListed = "Araçlar listelendi";

        public static string BrandAdded = "Marka eklendi!";
        public static string TypeFailed = "İşlem Başarısız!";
        public static string BrandDeleted = "Marka silindi!";
        public static string BrandUpdated = "Marka güncellendi!";
        internal static string BrandsListed = " Markalar listelendi";

        public static string ColorAdded = "Renk eklendi!";
        public static string ColorDeleted = "Renk silindi!";
        public static string ColorUpdated = "Renk güncellendi!";

        public static string UserUpdated = "Kullanıcı güncellendi!";
        public static string UserAdded = "Kullanıcı eklendi!";
        public static string UserDeleted = "Kullanıcı silindi!";
        internal static string UsersListed = "Kullanıcılar listelendi";

        public static string RentUpdated = "Kiralama güncellendi!";
        public static string RentAdded = "Kiralama eklendi!";
        public static string RentDeleted = "Kiralama silindi!";
        internal static string RentsListed = "Kiralamalar listelendi";

        public static string CustomerUpdated = "Müşteri güncellendi!";
        public static string CustomerAdded = "Müşteri eklendi!";
        public static string CustomerDeleted = "Müşteri silindi!";
        public static string CustomersListed = "Müşteriler listelendi";
        public static string CarCountofError = "Bir markaya ait on araba olabilir";
        public static string CarAlreadyExist = "Böyle bir araç sistemde vardır...";
        public static string BrandLimitExceed = "Bir markaya ait onbeş araç olabilir...";
        internal static string FileAdded;
        public static string CarImageLimitExceeded = "Daha fazla ürün girilemez";
        internal static string CarImageListed;
    }
}
