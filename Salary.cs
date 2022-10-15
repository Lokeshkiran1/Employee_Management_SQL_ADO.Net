using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementADO.NET
{
    public class Salary
    {
        private static SqlConnection ConnectionSetup()
        {
            return new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Payroll_Service;Integrated Security=True");

        }
        public int UpdateEmployeeSalary(SalaryUpdateModel salaryUpdateModel)
        {
            SqlConnection connection=ConnectionSetup();
            int salary = 0;
            try
            {
                using (connection)
                {
                    SalaryDetailModel salaryDetailModel=new SalaryDetailModel();
                    SqlCommand command=new SqlCommand("SpUpdateEmployeeSalary",connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", salaryUpdateModel.SalaryId);
                    command.Parameters.AddWithValue("@month", salaryUpdateModel.Month);
                    command.Parameters.AddWithValue("@salary", salaryUpdateModel.EmployeeSalary);
                    command.Parameters.AddWithValue("@empId", salaryUpdateModel.SalaryId);
                    connection.Open();
                    SqlDataReader reader=command.ExecuteReader();
                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            salaryDetailModel.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                            salaryDetailModel.EmployeeName = reader["EmployeeName"].ToString();
                            salaryDetailModel.JobDescription = reader["JobDescription"].ToString();
                            salaryDetailModel.Month = reader["Month"].ToString();
                            salaryDetailModel.EmployeeSalary = Convert.ToInt32(reader["EmployeeSalary"]);
                            salaryDetailModel.SalaryId = Convert.ToInt32(reader["SalaryId"]);
                            Console.WriteLine("{0}  {1}  {2}  {3}  {4}  {5}  {6}  ",salaryDetailModel.EmployeeId,salaryDetailModel.EmployeeName,salaryDetailModel.JobDescription,salaryDetailModel.Month,salaryDetailModel.EmployeeSalary,salaryDetailModel.SalaryId);

                            salary = salaryDetailModel.EmployeeSalary;



                        }
                    }
                    else
                    {
                        Console.WriteLine("data not found");
                    }
                    connection.Close();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return salary;

        }
    }
}
