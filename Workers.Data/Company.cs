using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers.Data
{
    public class Company
    {
        /// <summary>
        /// Props
        /// </summary>
        public List<Employee>? Employees { get; set; } = new List<Employee>();

        // Method for showing employees
        public void ListEmployee()
        {
            try
            {
                Employees = DataService.Read("Company.json").Employees ?? new List<Employee>();
                if (Employees == null || Employees.Count == 0) { Console.WriteLine("Employees are not found"); return; }
                Console.WriteLine("Worker name: \t Worker Position \t Worker hourly rate \t\t Worker ID \t\t\t Worker bonus");
                foreach (var employee in Employees)
                {
                    if (employee is Manager manager) Console.WriteLine($"{manager.Name} \t\t {manager.Position} \t\t\t {manager.HourlyRate} \t\t\t {manager.EmployeeId} \t\t {manager.Bonus}"); 
                    else Console.WriteLine($"{employee.Name} \t\t {employee.Position} \t\t\t {employee.HourlyRate} \t\t\t {employee.EmployeeId}"); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Method for adding employee
        public void AddEmployee(Employee employee)
        {
            try
            {
                Employees = DataService.Read("Company.json").Employees ?? new List<Employee>();
                if (Employees == null || Employees.Count == 0) { Console.WriteLine("Employees are not found"); return; }
                if (Employees?.FindIndex(emp => emp.Name == employee.Name) == -1) Employees.Add(employee);
                else { Console.WriteLine("An employee with such parameters already exists"); }
                DataService.Write(this);
                Console.WriteLine("Worker succsefully added");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        // Method for removing employee
        public void RemoveEmployee(long employeeId) 
        {
            try
            {
                Employees = DataService.Read("Company.json").Employees ?? new List<Employee>();
                if (Employees == null || Employees.Count == 0) { Console.WriteLine("Employees are not found"); return; }
                if (Employees?.FindIndex(emp => emp.EmployeeId == employeeId) == -1) { Console.WriteLine("An employee with such parameters does not exists"); return; }
                else Employees?.Remove(Employees.Find(emp => emp.EmployeeId == employeeId));
                DataService.Write(this);
                Console.WriteLine("Worker succsefully removed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        // Method for modify employee
        public void ModifyEmployee(long employeeId)
        {
            try
            {
                Employees = DataService.Read("Company.json").Employees ?? new List<Employee>();
                if (Employees == null || Employees.Count == 0) { Console.WriteLine("Employees are not found"); return; }
                if (Employees?.FindIndex(emp => emp.EmployeeId == employeeId) == -1) { Console.WriteLine("An employee with such parameters does not exists"); return; }
                else Employees?.Remove(Employees.Find(emp => emp.EmployeeId == employeeId));
                DataService.Write(this);
                AddEmployee();
                Console.WriteLine("Worker succsefully modifyed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Method for calculating salary employee
        public void CalculateSalary(long employeeId, int hours)
        {
            try
            {
                Employees = DataService.Read("Company.json").Employees ?? new List<Employee>();
                if (Employees == null || Employees.Count == 0) { Console.WriteLine("Employees are not found"); return; }
                if (Employees?.FindIndex(emp => emp.EmployeeId == employeeId) == -1) { Console.WriteLine("An employee with such parameters does not exists"); return; }
                Employee? employee = Employees?.Find(emp => emp.EmployeeId == employeeId);
                if (employee is Manager manager) Console.WriteLine($"Worker salary: {manager?.HourlyRate * hours + manager?.Bonus}");
                else Console.WriteLine($"Worker salary: {employee?.HourlyRate * hours}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        // Method for adding employee
        private void AddEmployee()
        {
            try
            {
                Console.Write("Write employee name: ");
                string? name = Console.ReadLine();
                Console.Write("Write employee position: ");
                string? position = Console.ReadLine();
                Console.Write("Write employee hourly rate: ");
                string? hourlyRateAsString = Console.ReadLine();

                if (hourlyRateAsString == null || name == null || position == null) { throw new NullReferenceException(); }
                int hourlyRate = int.Parse(hourlyRateAsString);

                if (position == "Manager")
                {
                    Console.Write("Write manager bonus: ");
                    string? bonusAsString = Console.ReadLine();
                    if (bonusAsString is null) { throw new NullReferenceException(); }
                    int bonus = int.Parse(bonusAsString);
                    AddEmployee(new Manager(name, position, hourlyRate, bonus));
                    return;
                }

                this.AddEmployee(new Employee(name, position, hourlyRate));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
