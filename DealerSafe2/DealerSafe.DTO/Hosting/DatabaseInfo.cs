using System;
using System.ComponentModel.DataAnnotations;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Hosting
{
    [Serializable]
    public class DatabaseInfo
    {
        [Required(ErrorMessage = "{0} alaný gereklidir")]
        [Display(Name = "Database Adý")]
        [RegularExpression(@"(^([a-z]){1})+([A-Za-z0-9_\-\.]){5}$", ErrorMessage = "6 karakterden oluþmalý ve harfle baþlamalýdýr. örn: db1234")]
        public string DatabaseName { get; set; }

        [Required(ErrorMessage = "{0} alaný gereklidir")]
        [Display(Name = "Database Kullanýcý Adý")]
        [RegularExpression(@"(^([a-z]){1})+([A-Za-z0-9_\-\.]){5}$", ErrorMessage = "6 karakterden oluþmalý ve harfle baþlamalýdýr. örn: db1234")]
        public string DatabaseUserName { get; set; }

        [Required(ErrorMessage = "{0} alaný gereklidir")]
        [Display(Name = "Database Þifre")]
        [StringLength(20, ErrorMessage = "Þifreniz minimum 8 karakter olmalýdýr", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15}$", ErrorMessage = "Þifrenizde büyük harf,küçük harf ve rakam kullanýnýz. örn: a1B2c3d4")]
        public string DatabasePassword { get; set; }

        [Required(ErrorMessage = "{0} alaný gereklidir")]
        [Display(Name = "Database Tipi")]
        public string DatabaseType { get; set; }

        public EnmDatabaseType EnmDatabaseType
        {
            get
            {
                try
                {
                    if (DatabaseType == "1")
                        return EnmDatabaseType.MSSQL;
                    if (DatabaseType == "2")
                        return EnmDatabaseType.MySQL;
                    return EnmDatabaseType.TANIMSIZ;
                }
                catch
                {
                    return EnmDatabaseType.PostgreSQL;
                }
            }
        }
        public string Manager { get; set; }
        public string Path { get; set; }
        public int Id { get; set; }
        public int ServerId { get; set; }
        public string Port { get; set; }
        public DatabaseDetailsInfo DatabaseDetails { get; set; }
    }

    //public class DropDowns
    //{
    //    public static SelectList DatabaseTypes = new SelectList(new List<SelectListItem>()
    //                                                                {
    //                                                                    new SelectListItem() { Value ="" ,Selected = true, Text = "Database Tipi Seçiniz..." },
    //                                                                    new SelectListItem() { Value = "1", Text = "MS SQL" },
    //                                                                    new SelectListItem() { Value = "2", Text = "My SQL" },
    //                                                                }, "Value", "Text");
    //}
}