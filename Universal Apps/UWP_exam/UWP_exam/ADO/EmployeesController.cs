using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_exam.Model;
using MySql.Data.MySqlClient;

namespace UWP_exam.ADO
{
    class EmployeeController
    {
        MySqlConnection conn;

        public EmployeeController()
        {
            string sql = "server=localhost;user=aacc;database=UWP_excam;port=3306;password=";
            conn = new MySqlConnection(sql);
        }

        public List<Employee> GetAllEmployee()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();

            List<Employee> listEmployee = new List<Employee>();
            MySqlCommand mySqlCommand = new MySqlCommand("SELECT ID, Name, Department, Year_of_Birth FROM employee", conn);
            MySqlDataReader dataReader = mySqlCommand.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    Employee employee = new Employee();

                    employee.ID = Convert.ToInt32(dataReader["Id"]);
                    employee.Name = dataReader["Name"].ToString();
                    employee.Department = dataReader["Department"].ToString();
                    employee.Year_of_Birth = dataReader["Year_of_Birth"].ToString();



                    listEmployee.Add(employee);
                }
                dataReader.Close();
                mySqlCommand.Dispose();
            }

            return listEmployee;
        }
    }


}
