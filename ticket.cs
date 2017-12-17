using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BL;
using DA;

namespace BL
{
    public class ticket:DataAccessLayer
    {
        public int id;
        public string name;
        public string family;
        public string tel;
        public string born;

        public void add()
        {
            base.connect();
            string sql = "insert into ticket (name,family,tel,born) values (N'{0}',N'{1}',N'{2}',N'{3}')";
            sql = string.Format(sql,name,family,tel,born);
            base.docommand(sql);
            base.disconnect();
        }
        public void delete()
        {
            base.connect();
            string sql = "delete from ticket where id={0}";
            sql = string.Format(sql,id);
            base.docommand(sql);
            base.disconnect();
        }

        public void update()
        {
            base.connect();
            string sql = "update ticket SET name=N'{0}',family=N'{1}',tel='{2}',born=N'{3}' where id={4}";
            sql = string.Format(sql, name, family, tel, born,id);
            base.docommand(sql);
            base.disconnect();
        }
        public DataTable select()
        {
            base.connect();
            string sql = "select * from ticket";
            DataTable dt = base.select(sql);
            base.disconnect();
            return dt;
        }
        public DataTable selectone()
        {
            base.connect();
            string sql = "select * from ticket where id={0}";
            sql = string.Format(sql, id);
            DataTable dt = base.select(sql);
            base.disconnect();
            return dt;
        }
    }
}
