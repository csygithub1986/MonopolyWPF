using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User : ModelBase
    {
        public string Account { get { return _Account; } set { if (_Account != value) { _Account = value; NotifyPropertyChanged(); } } }
        private string _Account;

        public string NickName { get { return _NickName; } set { if (_NickName != value) { _NickName = value; NotifyPropertyChanged(); } } }
        private string _NickName;

        public string Password { get { return _Password; } set { if (_Password != value) { _Password = value; NotifyPropertyChanged(); } } }
        private string _Password;

        public string PhoneNum { get { return _PhoneNum; } set { if (_PhoneNum != value) { _PhoneNum = value; NotifyPropertyChanged(); } } }
        private string _PhoneNum;

    }
}
