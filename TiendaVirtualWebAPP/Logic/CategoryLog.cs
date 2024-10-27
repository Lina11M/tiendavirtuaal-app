using Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;

namespace Logic
{
    public class CategoryLog
    {
        CategoryDat objCategory = new CategoryDat();


        public DataSet showCategories()
        {
            return objCategory.showCategories();
        }

      
        public bool saveCategory(string _nombre)
        {
            return objCategory;
        }

  
        public bool updateCategory(int _idCategory, string _nombre)
        {
            return objCategory;
        }


        public bool deleteCategory(int _idCategory)
        {
            return objCategory;
        }
    }
}