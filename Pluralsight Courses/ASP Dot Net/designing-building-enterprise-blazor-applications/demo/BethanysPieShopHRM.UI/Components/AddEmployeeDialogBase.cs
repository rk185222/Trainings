﻿using System;
using System.Threading.Tasks;
using BethanysPieShopHRM.UI.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.UI.Components
{
    public class AddEmployeeDialogBase : ComponentBase
    {
        public bool ShowDialog { get; set; }

        public Employee Employee { get; set; } = new Employee { JobCategoryId = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now };

        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        [Inject] 
        public IEmployeeDataService EmployeeDataService { get; set; }

      

        public void Show()
        {
            ResetDialog();
            ShowDialog = true;
            StateHasChanged();
        }

        private void ResetDialog()
        {
            Employee = new Employee { JobCategoryId = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now };
        }

        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }

        protected async Task HandleValidSubmit()
        {
            await EmployeeDataService.AddEmployee(Employee);
            ShowDialog = false;

            await CloseEventCallback.InvokeAsync(true);
            StateHasChanged();
        }
    }
}
