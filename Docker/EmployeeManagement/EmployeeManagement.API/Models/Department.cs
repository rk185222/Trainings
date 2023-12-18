﻿namespace EmployeeManagement.API.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;
    }

    public enum Dept
    {
        HR,
        IT,
        Admin
    }
}