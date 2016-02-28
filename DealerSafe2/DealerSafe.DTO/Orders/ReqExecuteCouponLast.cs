using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO
{
    public class ReqExecuteCouponLast
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public enmExecutionStatus ExecutionStatus { get; set; }
        public int ExecutedOrderId { get; set; }
        public string ExecutedDate { get; set; }
        public double CouponUnexpendedValue { get; set; }
        public int CouponUsedNumber { get; set; }
        public enmCoupontype CouponType { get; set; }
        public double CouponValue { get; set; }
    }

    public enum enmExecutionStatus
    {
        none = 0, // null olması durumunda
        open = 1, //açık dırımdaki kupon: her türlü siparişte kullanılabilir durumdaki kupon
        used = 2, //kullanılmış kupon birsiparişte kullanılmı kupon
        expired = 3, //Süresi dolmuş kupon: artık kullanılamaz
        canceled = 4, // iptal edilmiş kupon: yönetici tarafından iptal edilmiş kupon
        blocked = 5, // bloke edilmiş kupon: siparişte kullanılan ancak siparişin henüz tmamamalanmadığı durumlarda karşımıza çıkar
        pending = 6, // bekleme drumundaki kupon ilk üretilen kupon beklemede kalır, daha sonra bu kupon açık duruma getirilince tarih aralığı alır.
        granted = 10 // verilmiş fakat henüz kullanılmamış kupon
    }
    public enum enmCoupontype { money = 3, value = 2, percentage = 1, none = 0 }
}
