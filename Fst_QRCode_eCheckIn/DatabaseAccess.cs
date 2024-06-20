using System.Configuration;
using System.Data.SqlClient;
using Fst_QRCode_eCheckIn.Models;

namespace Fst_QRCode_eCheckIn.Data
{
    public class DatabaseAccess
    {
        private readonly string _connectionString;

        public DatabaseAccess()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void SaveRegistration(RegistrationMdl model)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Registrations (Name, Department, QRCodeImageUrl, TOTP) VALUES (@Name, @Department, @QRCodeImageUrl, @TOTP)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", model.empName);
                    command.Parameters.AddWithValue("@Department", model.empDepartment);
                    command.Parameters.AddWithValue("@QRCodeImageUrl", model.qrCodeImgUrl);
                    command.Parameters.AddWithValue("@TOTP", model.QRCodeTotp);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
