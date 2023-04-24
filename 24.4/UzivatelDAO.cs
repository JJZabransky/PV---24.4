using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24._4
{
    public class UzivatelDAO
    {
        public IEnumerable<Uzivatel> GetAll()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Osoby", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Uzivatel u = new Uzivatel(
                        reader[0].ToString(),
                        reader[1].ToString()
                    );
                    yield return u;
                }
                reader.Close();
            }
        }
    }
}
