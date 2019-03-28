using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;

namespace FileAccessPolyFill
{
    namespace WindowsR.System
    {
        [AllowForWeb]
        public sealed class User
        {
            public User() { }
            public User(Windows.System.User user)
            {
                _user = user;
            }
            private Windows.System.User _user;
        }
    }
}
