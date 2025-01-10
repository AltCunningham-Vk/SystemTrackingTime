using System.Collections.ObjectModel;
using System.Linq;
using App.Data;
using App.Models;

namespace App.ViewModels
{
    public class DataPageViewModel
    {
        public ObservableCollection<Employee> Employees { get; set; }
        public DataPageViewModel()
        {
            Employees = new ObservableCollection<Employee>();
            LoadData();
        }
        private void LoadData()
        {
            using (var context = new TimeTrackingSystemContext())
            {
                var employees = context.Employees.ToList();
                foreach (var employee in employees)
                {
                    Employees.Add(employee);
                }
            }
        }
    }
}
