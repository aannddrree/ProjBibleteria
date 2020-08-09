using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class BilheteriaDB
    {
        private static SQLiteConnection sqliteConnection;

        public BilheteriaDB(){
            sqliteConnection = ConnectionSQLite.DbConnection();
        }

        public bool Save(Bilheteria bilheteria)
        {
            try
            {
                string sql = "INSERT INTO tb_bilheteria (descricao, dt_evento, local, qtd_pessoas) values (@Descricao, @DataEvento, @Local, @QtdPessoas)";

                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@Descricao", bilheteria.Descricao);
                    cmd.Parameters.AddWithValue("@DataEvento", bilheteria.DataEvento);
                    cmd.Parameters.AddWithValue("@Local", bilheteria.Local);
                    cmd.Parameters.AddWithValue("@QtdPessoas", bilheteria.QtdPessoas);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public bool Update(Bilheteria bilheteria)
        {
            try
            {
                string sql = "UPDATE tb_bilheteria set descricao = @Descricao, " +
                                                      "dt_evento = @DataEvento, " +
                                                      "local = @Local, " +
                                                      "qtd_pessoas = @QtdPessoas " +
                                                      "WHERE id = @Id ";

                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@Id", bilheteria.Id);
                    cmd.Parameters.AddWithValue("@Descricao", bilheteria.Descricao);
                    cmd.Parameters.AddWithValue("@DataEvento", bilheteria.DataEvento);
                    cmd.Parameters.AddWithValue("@Local", bilheteria.Local);
                    cmd.Parameters.AddWithValue("@QtdPessoas", bilheteria.QtdPessoas);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                string sql = "DELETE FROM tb_bilheteria WHERE id = @Id";

                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public DataTable FindAll()
        {
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = null;

            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT id, descricao, dt_evento, local, qtd_pessoas");
            sb.Append("   FROM tb_bilheteria");

            using (var cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = sb.ToString();
                da = new SQLiteDataAdapter(cmd.CommandText, sqliteConnection);
                da.Fill(dt);
            }
            return dt;
        }

        public Bilheteria FindById(int id)
        {
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = null;

            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT id, descricao, dt_evento, local, qtd_pessoas");
            sb.Append("   FROM tb_bilheteria");
            sb.Append("   WHERE id = " + id);

            using (var cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = sb.ToString();
                da = new SQLiteDataAdapter(cmd.CommandText, sqliteConnection);
                da.Fill(dt);
            }
            return ConvertDataTableToList(dt)[0];
        }

        private List<Bilheteria> ConvertDataTableToList(DataTable dt)
        {
            var data = (from d in dt.AsEnumerable()
                        select new Bilheteria()
                        {
                            Id = Convert.ToInt32(d["id"]),
                            Descricao = Convert.ToString(d["descricao"]),
                            DataEvento = Convert.ToDateTime(d["dt_evento"]),
                            Local = Convert.ToString(d["local"]),
                            QtdPessoas = Convert.ToInt32(d["qtd_pessoas"])
                        }).ToList();
            return data;
        }
    }
}
