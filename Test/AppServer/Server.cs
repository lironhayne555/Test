using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Linq;
using System.Data;
using Test.Module;

namespace Test.AppServer
{
    public class Server
    {
        private SqlConnection cn;
        private SqlCommand cmd;
        private SqlDataReader da;
        private SqlDataAdapter dr;
        private DataTable dt;

        public void InsertCity(int ID, string CityName)
        {
            try
            {

                this.cn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\liron\\c:\\Test\\DataBase.mdf;Integrated Security=True");
                this.dr = new SqlDataAdapter(Query.InsertCity, cn);
                this.dr.SelectCommand.Parameters.Add(new SqlParameter { ParameterName = "@ID", Value = ID, SqlDbType = SqlDbType.Int });
                this.dr.SelectCommand.Parameters.Add(new SqlParameter { ParameterName = "@City", Value = CityName, SqlDbType = SqlDbType.VarChar });
                DataTable dt = new DataTable();
                this.dr.Fill(dt);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void DeleteCity(int ID)
        {
            try
            {

                this.cn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\liron\\c:\\Test\\DataBase.mdf;Integrated Security=True");
                this.dr = new SqlDataAdapter(Query.DeleteCity, cn);
                this.dr.SelectCommand.Parameters.Add(new SqlParameter { ParameterName = "@ID", Value = ID, SqlDbType = SqlDbType.Int });
                DataTable dt = new DataTable();
                this.dr.Fill(dt);
    
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public List<Street> GetStreets(int IDCity) {
            List<Street> list = new List<Street>();
            try
            {
                this.cn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\liron\\c:\\Test\\DataBase.mdf;Integrated Security=True");
                this.dr = new SqlDataAdapter(Query.GetStreets, cn);
                this.dr.SelectCommand.Parameters.Add(new SqlParameter { ParameterName = "@IDCity", Value = IDCity, SqlDbType = SqlDbType.Int });
                DataTable dt = new DataTable();
                this.dr.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    Street s = new Street();
                    s.ID = (int)row["ID"];
                    s.Name = row["Street_Name"].ToString();
                    s.ID_City = (int)row["ID_City"];
                    list.Add(s);

                }
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
