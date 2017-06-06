using System;
using System.Configuration;
using System.Data.SqlClient;

namespace UrlShorteningService.Models
{
    public class UrlMapRepository : IUrlMapRepository
    {
        public void Insert(UrlMap entity)
        {
            //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["azuredb"]);
            //conn.Open();

            //SqlCommand comm = new SqlCommand("Insert");
            //comm.Parameters.Add("@Url", System.Data.SqlDbType.VarChar, 2000);
            //comm.CommandType = System.Data.CommandType.StoredProcedure;

            //comm.ExecuteNonQuery();
        }

        public void Delete(UrlMap entity)
        {
            throw new NotImplementedException();
        }

        UrlMap IUrlMapRepository.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}