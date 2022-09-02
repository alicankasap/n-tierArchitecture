using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.UserRepository.Constants
{
    public class UserMessages
    {
        public static string UpdatedUser = "Kullanıcı güncelleme işlemi başarıyla gerçekleştirildi";

        public static string DeletedUser = "Kullanıcı silme işlemi başarıyla gerçekleştirildi";

        public static string WrongCurrentPassword = "Mevcut şifrenizi yanlış tuşladınız";

        public static string PasswordChanged = "Şifreniz başarıyla değiştirildi";
    }
}
