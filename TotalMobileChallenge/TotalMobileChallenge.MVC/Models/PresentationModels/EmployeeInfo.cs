﻿namespace TotalMobileChallenge.Client.Models.PresentationModels
{
    public class EmployeeInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public HoursWorkedInfo HoursWorked { get; set; } = null;
    }
}