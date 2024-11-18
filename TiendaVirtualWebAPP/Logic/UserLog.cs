using Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Model;

namespace Logic
{
    public class UserLog
    {
        UserDat objUsers = new UserDat();

        
        public DataSet showUsers()
        {
            return objUsers.showUsers();
        }

        
        public bool saveUsers(string _correo, string _contrasena, string _salt, string _estado, string _rol)
        {
            return objUsers.saveUsers(_correo, _contrasena, _salt, _estado, _rol);
        }

        
        public bool updateUsers(int _idUsers, string _correo, string _contrasena, string _salt, string _estado, string _rol)
        {
            return objUsers.updateUsers(_idUsers, _correo, _contrasena, _salt, _estado, _rol);
        }

        
        public bool deleteUsers(int _idUsers)
        {
            return objUsers.deleteUsers(_idUsers);
        }


        public UserMod showUserMail(string mail)
        {
            return objUsers.showUserMail(mail);
        }
    }
}
