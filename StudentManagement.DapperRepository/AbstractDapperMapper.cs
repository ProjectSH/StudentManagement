using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace StudentManagement.DapperRepository
{
    public abstract class AbstractDapperMapper<T>
    {
        protected abstract string TableName { get; }

        protected IDbConnection Connection
        {
            get
            {
                return  new SqlConnection( SqlHelper.GetSqlConnection());
            }
        }

        public virtual T FindSingle(string query, dynamic param)
        {
            dynamic item = null;

            using (IDbConnection cn = Connection)
            {
                cn.Open();
                var result = cn.Query(query, (object)param).SingleOrDefault();

                if (result != null)
                {
                    item = Map(result);
                }
            }

            return item;
        }

        
        public virtual IEnumerable<T> Query()
        {
            var  items = new List<T>();

            using (IDbConnection cn = Connection)
            {
                cn.Open();
                var results = cn.Query("SELECT * FROM " + TableName).ToList();

                for (int i = 0; i < results.Count(); i++)
                {
                    items.Add(Map(results.ElementAt(i)));
                }
            }

            return items;
        }
        
        public virtual void Delete(int id)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                cn.Execute("DELETE FROM " + TableName + " WHERE ID=@ID", new { ID = id });
            }
        }

        public abstract T Map(dynamic result);
    }
}