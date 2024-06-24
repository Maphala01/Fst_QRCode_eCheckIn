
using System;
using System.Collections.Generic;
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

        public List<Department> GetDepartments()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT DepartmentName FROM Departments ORDER BY DepartmentName ASC", connection);
                var reader = command.ExecuteReader();

                var departments = new List<Department>();

                while (reader.Read())
                {
                    departments.Add(new Department { DepartmentName = reader["DepartmentName"].ToString() });
                }

                return departments;
            }
        }

        public List<Employee> GetEmployees()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT Name FROM Employees ORDER BY Name ASC", connection);
                var reader = command.ExecuteReader();

                var employees = new List<Employee>();

                while (reader.Read())
                {
                    employees.Add(new Employee { EmployeeName = reader["Name"].ToString() });
                }

                return employees;
            }
        }

        public List<Department> GetDepartmentsByTerm(string term)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT DepartmentName FROM Departments WHERE DepartmentName LIKE @term ORDER BY DepartmentName ASC", connection);
                command.Parameters.AddWithValue("@term", "%" + term + "%");
                var reader = command.ExecuteReader();

                var departments = new List<Department>();

                while (reader.Read())
                {
                    departments.Add(new Department { DepartmentName = reader["DepartmentName"].ToString() });
                }

                return departments;
            }
        }

        public List<Employee> GetEmployeesByTerm(string term)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT Name FROM Employees WHERE Name LIKE @term ORDER BY Name ASC", connection);
                command.Parameters.AddWithValue("@term", "%" + term + "%");
                var reader = command.ExecuteReader();

                var employees = new List<Employee>();

                while (reader.Read())
                {
                    employees.Add(new Employee { EmployeeName = reader["Name"].ToString() });
                }

                return employees;
            }
        }
    }
}
