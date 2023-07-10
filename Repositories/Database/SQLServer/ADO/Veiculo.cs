using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repositories.Database.SQLServer.ADO
{
    public class Veiculo : IRepository<Models.Veiculo>
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private string keyCache;
        public Veiculo(string connectionString) {
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            this.keyCache = "veiculos";
        }
        public List<Models.Veiculo> get()
        {
            List<Models.Veiculo> veiculos = (List<Models.Veiculo>)Cache.get(keyCache);

            if (veiculos != null)
                return veiculos;
            
            veiculos = new List<Models.Veiculo>();

            using (conn)
            {
                conn.Open();

                using(cmd)
                {
                    cmd.Connection = conn;

                    StringBuilder commandText = new StringBuilder();
                    commandText.Append("SELECT id, marca, nome, ano_modelo, data_fabricacao, ");
                    commandText.Append("valor, opcional ");
                    commandText.Append("FROM veiculo;");

                    cmd.CommandText = commandText.ToString();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    while(sdr.Read())
                    {
                        Models.Veiculo veiculo = new Models.Veiculo();

                        veiculo.Id = (int)sdr["id"];
                        veiculo.Marca = sdr["marca"].ToString();
                        veiculo.Nome = sdr["nome"].ToString();
                        veiculo.AnoModelo = (int)sdr["ano_modelo"];
                        veiculo.DataFabricacao = (DateTime)sdr["data_fabricacao"];
                        veiculo.Valor = Convert.ToDouble(sdr["valor"]);

                        if (sdr["opcional"] != DBNull.Value)
                            veiculo.Opcional = sdr["opcional"].ToString();

                        veiculos.Add(veiculo);
                    }
                }
            }

            Cache.add(keyCache, veiculos, 30);

            return veiculos;
        }
        public Models.Veiculo getById(int id)
        {
            List<Models.Veiculo> veiculos = (List<Models.Veiculo>)Cache.get(keyCache);

            if (veiculos != null)
                return veiculos.Find(veiculosCache => veiculosCache.Id == id);

            Models.Veiculo veiculo = null;

            using (conn)
            {
                conn.Open();

                using (cmd)
                {
                    cmd.Connection = conn;

                    StringBuilder commandText = new StringBuilder();
                    commandText.Append("SELECT id, marca, nome, ano_modelo, data_fabricacao,");
                    commandText.Append("valor, opcional ");
                    commandText.Append("FROM veiculo ");
                    commandText.Append("WHERE id = @id;");

                    cmd.CommandText = commandText.ToString();
                    
                    cmd.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.Read())
                    {
                        veiculo = new Models.Veiculo();

                        veiculo.Id = (int)sdr["id"];
                        veiculo.Marca = sdr["marca"].ToString();
                        veiculo.Nome = sdr["nome"].ToString();
                        veiculo.AnoModelo = (int)sdr["ano_modelo"];
                        veiculo.DataFabricacao = (DateTime)sdr["data_fabricacao"];
                        veiculo.Valor = Convert.ToDouble(sdr["valor"]);

                        if(sdr["opcional"] != DBNull.Value)
                            veiculo.Opcional = sdr["opcional"].ToString();
                    }
                }
            }

            return veiculo;
        }

        public void add(Models.Veiculo entity)
        {
            using (conn)
            {
                conn.Open();

                using (cmd)
                {
                    cmd.Connection = conn;

                    StringBuilder commandText = new StringBuilder();
                    commandText.Append("INSERT veiculo(veiculo.marca, veiculo.nome, veiculo.ano_modelo,");
                    commandText.Append("veiculo.data_fabricacao, veiculo.valor, veiculo.opcional) ");
                    commandText.Append("VALUES(@marca, @nome, @ano_modelo, @data_fabricacao, @valor,@opcional);");
                    commandText.Append("SELECT CONVERT(INT, @@IDENTITY) AS id;");

                    cmd.CommandText = commandText.ToString();

                    cmd.Parameters.Add(new SqlParameter("@marca", System.Data.SqlDbType.VarChar)).Value = entity.Marca;
                    cmd.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar)).Value = entity.Nome;
                    cmd.Parameters.Add(new SqlParameter("@ano_modelo", System.Data.SqlDbType.Int)).Value = entity.AnoModelo;
                    cmd.Parameters.Add(new SqlParameter("@data_fabricacao", System.Data.SqlDbType.Date)).Value = entity.DataFabricacao;
                    cmd.Parameters.Add(new SqlParameter("@valor", System.Data.SqlDbType.Decimal)).Value = entity.Valor;

                    if (entity.Opcional == null)
                        cmd.Parameters.Add(new SqlParameter("@opcional", System.Data.SqlDbType.VarChar)).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(new SqlParameter("@opcional", System.Data.SqlDbType.VarChar)).Value = entity.Opcional;

                    int codigoGerado = (int)cmd.ExecuteScalar();
                    entity.Id = codigoGerado;
                }
            }

            Cache.remove(keyCache);
        }
        public int update(Models.Veiculo entity)
        {
            {
                int linhasAfetadas = 0;

                using (conn)
                {
                    conn.Open();

                    using (cmd)
                    {
                        cmd.Connection = conn;

                        StringBuilder commandText = new StringBuilder();
                        commandText.Append("UPDATE veiculo ");
                        commandText.Append("SET marca = @marca, nome = @nome, ano_modelo = @ano_modelo, ");
                        commandText.Append("data_fabricacao = @data_fabricacao, valor = @valor, opcional = @opcional ");
                        commandText.Append("WHERE id = @id;");

                        cmd.CommandText = commandText.ToString();

                        cmd.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.VarChar)).Value = entity.Id;
                        cmd.Parameters.Add(new SqlParameter("@marca", System.Data.SqlDbType.VarChar)).Value = entity.Marca;
                        cmd.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar)).Value = entity.Nome;
                        cmd.Parameters.Add(new SqlParameter("@ano_modelo", System.Data.SqlDbType.Int)).Value = entity.AnoModelo;
                        cmd.Parameters.Add(new SqlParameter("@data_fabricacao", System.Data.SqlDbType.Date)).Value = entity.DataFabricacao;
                        cmd.Parameters.Add(new SqlParameter("@valor", System.Data.SqlDbType.Decimal)).Value = entity.Valor;

                        if (entity.Opcional == null)
                            cmd.Parameters.Add(new SqlParameter("@opcional", System.Data.SqlDbType.VarChar)).Value = DBNull.Value;
                        else
                            cmd.Parameters.Add(new SqlParameter("@opcional", System.Data.SqlDbType.VarChar)).Value = entity.Opcional;

                        linhasAfetadas = cmd.ExecuteNonQuery();
                    }
                }

                if(linhasAfetadas > 0)
                    Cache.remove(keyCache);

                return linhasAfetadas;
            }
        }
        public int delete(int id)
        {
            int linhasAfetadas = 0;

            using (conn)
            {
                conn.Open();

                using (cmd)
                {
                    cmd.Connection = conn;

                    StringBuilder commandText = new StringBuilder();
                    commandText.Append("DELETE veiculo ");
                    commandText.Append("WHERE id = @id;");

                    cmd.CommandText = commandText.ToString();

                    cmd.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                    linhasAfetadas = cmd.ExecuteNonQuery();
                }
            }

            if (linhasAfetadas > 0)
                Cache.remove(keyCache);

            return linhasAfetadas;
        }
    }
}
