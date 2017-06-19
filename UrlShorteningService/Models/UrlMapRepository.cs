using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace UrlShorteningService.Models
{
    public class UrlMapRepository : IUrlMapRepository
    {
        public async Task<int> InsertAsync(string longUrl)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["azuresqldb"].ConnectionString))
            {
                using (var commInsert = conn.CreateCommand())
                {
                    commInsert.CommandText = "Insert";
                    commInsert.CommandType = System.Data.CommandType.StoredProcedure;

                    var paramUrl = new SqlParameter()
                    {
                        Direction = System.Data.ParameterDirection.Input,
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        ParameterName = "@Url",
                        Value = longUrl
                    };

                    var paramId = new SqlParameter()
                    {
                        Direction = System.Data.ParameterDirection.Output,
                        SqlDbType = System.Data.SqlDbType.Int,
                        ParameterName = "@Id"
                    };

                    commInsert.Parameters.AddRange(new SqlParameter[] { paramUrl, paramId });

                    await conn.OpenAsync().ConfigureAwait(false);

                    await commInsert.ExecuteNonQueryAsync().ConfigureAwait(false);

                    return Convert.ToInt32(commInsert.Parameters["@Id"].Value);
                }
            }
        }

        async Task<string> IUrlMapRepository.GetByIdAsync(int id)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["azuresqldb"].ConnectionString))
            {
                using (var commSelect = conn.CreateCommand())
                {
                    commSelect.CommandText = "Select";
                    commSelect.CommandType = System.Data.CommandType.StoredProcedure;

                    var paramId = new SqlParameter()
                    {
                        Direction = System.Data.ParameterDirection.Input,
                        SqlDbType = System.Data.SqlDbType.Int,
                        ParameterName = "@Id",
                        Value = id
                    };
                    commSelect.Parameters.Add(paramId);

                    await conn.OpenAsync().ConfigureAwait(false);

                    var longUrl = await commSelect.ExecuteScalarAsync().ConfigureAwait(false);
                    
                    return longUrl.ToString();
                }
            }
        }
    }
}