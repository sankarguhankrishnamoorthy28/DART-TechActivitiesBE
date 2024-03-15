using EmployeeApp.Model;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace EmployeeApp.Service
{
    public class EmployeeService
    {
        private readonly string _connectionString;
        public EmployeeService() {
            _connectionString = "Server=KANINI-LTP-613;Database=Employee;User Id=sa;Password=Admin@12345;";
        }     
        public List<Employee> GetAllEmployees(int pageNumber, string sortOrder, string sortingColumn)
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

               
                SqlCommand command = new SqlCommand("GetPlayersPagedAndSorted", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Set parameters if needed
                command.Parameters.AddWithValue("@PageNumber", pageNumber);
                command.Parameters.AddWithValue("@SortOrder",sortOrder);
                command.Parameters.AddWithValue("@SortingColumn",sortingColumn);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.Employee_Id = (int)reader["Employee_Id"];
                        employee.Email = reader["Email"].ToString();
                        employee.Address = reader["Address"].ToString();
                        employee.First_Name = reader["First_Name"].ToString();
                        employee.Last_Name = reader["Last_Name"].ToString();
                        employees.Add(employee);
                    }
                    connection.Close();
                }
                return employees;
            }

        }
    }
}
