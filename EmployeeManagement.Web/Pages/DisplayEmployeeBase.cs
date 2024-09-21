using EmployeeManagement.model;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class DisplayEmployeeBase : ComponentBase
    {

        [Parameter]
        public Employee Employee { get; set; }

        [Parameter]
        public bool ShowFooter { get; set; }
        [Parameter]
        public EventCallback<bool> OnEmployeeSelection { get; set; }
        [Parameter]
        public EventCallback<int> OnEmployeeDeleted { get; set; }

        [Inject]
        public IEmployeeServices _EmployeeServices { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected PragimTech.Components.ConfirmBase DeleteConfirmation { get; set; }

        protected async Task Delete_Click()
        {
            //DeleteConfirmation.Show();
            await _EmployeeServices.DeleteEmployee(Employee.EmployeeId);
            await OnEmployeeDeleted.InvokeAsync(Employee.EmployeeId);
        }
        protected async Task ConfirmDelete_Click(bool deleteconfirmed)
        {
            if (deleteconfirmed)
            {
                await _EmployeeServices.DeleteEmployee(Employee.EmployeeId);
                await OnEmployeeDeleted.InvokeAsync(Employee.EmployeeId);
            }
        }
        protected async Task CheckboxChanged(ChangeEventArgs e)
        {
            await OnEmployeeSelection.InvokeAsync((bool)e.Value);
        }
    }
}