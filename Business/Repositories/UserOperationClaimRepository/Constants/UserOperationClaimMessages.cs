using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.UserOperationClaimRepository.Constants
{
    public class UserOperationClaimMessages
    {
        public static string Added = "Yetki ataması başarıyla oluşturuldu";
        public static string Updated = "Yetki ataması başarıyla güncellendi";
        public static string Deleted = "Yetki ataması başarıyla silindi";
        public static string OperationClaimSetExist = "Bu kullanıcıya bu yetki daha önce atanmış";
        public static string OperationClaimNotExist = "Seçtiğiniz yetki bilgisi bulunamadı";
        public static string UserNotExist = "Seçtiğiniz kullanıcı bulunamadı";
    }
}
