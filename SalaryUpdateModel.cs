﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementADO.NET
{
    public class SalaryUpdateModel
    {
        public int SalaryId { get; set; }
        public string Month { get; set; }
        public int EmployeeSalary { get; set; }
        public int EmployeeId { get; set; }

    }
}
