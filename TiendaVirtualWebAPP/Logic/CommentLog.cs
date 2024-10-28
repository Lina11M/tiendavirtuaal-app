using Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Logic
{
    public class CommentLog
    {
        CommentDat objComment = new CommentDat();

        public DataSet showComment()
        {
            return objComment.showComment();
        }

        
        public bool saveComment(string _comentario, string _fecha, int _pro_id, int _cli_id)
        {
            return objComment.saveComment(_comentario, _fecha, _pro_id, _cli_id);

        }

       
        public bool updateComment(int _idComment, string _comentario, string _fecha, int _pro_id, int _cli_id)
        {
            return objComment.updateComment(_idComment, _comentario, _fecha, _pro_id, _cli_id);

        }

       
        public bool deleteComment(int _idComment)
        {
            return objComment.deleteComment(_idComment);
        }
    }
}