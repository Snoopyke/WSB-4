using Workers.Data;
using Workers.Enum;

namespace Workers.Gui
{
    public sealed class MainScreen
    {
        #region Properties And Ctor
        /// <summary>
        /// Props
        /// </summary>
        private Company? Company { get; set; } = new Company();

        #endregion Properties And Ctor

        #region Public Methods

        /// <inheritdoc/>
        public void Show()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine();
                Console.WriteLine("Your available choices are:");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. List employees");
                Console.WriteLine("2. Add employee");
                Console.WriteLine("3. Remove employee");
                Console.WriteLine("4. Modify employee");
                Console.WriteLine("5. Calculate salary employee");
                Console.Write("Please enter your choice: ");

                string? choiceAsString = Console.ReadLine();

                // Validate choice
                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    MainScreenChoices choice = (MainScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case MainScreenChoices.ListEmployee:
                            Company?.ListEmployee();
                            break;
                        case MainScreenChoices.AddEmployee:
                            AddEmployee();
                            break;
                        case MainScreenChoices.RemoveEmployee:
                            RemoveEmployee();
                            break;
                        case MainScreenChoices.ModifyEmployee:
                            ModifyEmployee();
                            break;
                        case MainScreenChoices.CalculateSalary:
                            CalculateSalary();
                            break;
                        case MainScreenChoices.Exit:
                            Console.WriteLine("Goodbye.");
                            return;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }

        #endregion // Public Methods

        #region Private Methods

        /// Creating a request for the class Company
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
                    Company?.AddEmployee(new Manager(name, position, hourlyRate, bonus));
                    return;
                }
                Company?.AddEmployee(new Employee(name, position, hourlyRate));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }

        /// Creating a request for the class Company
        private void RemoveEmployee()
        {
            try
            {
                Console.Write("Write employee id: ");
                string? EmpIdAsString = Console.ReadLine();
                if (EmpIdAsString is null) { throw new NullReferenceException(); }
                long EmpId = long.Parse(EmpIdAsString);
                Company?.RemoveEmployee(EmpId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// Creating a request for the class Company
        private void ModifyEmployee()
        {
            try
            {
                Console.Write("Write employee id: ");
                string? EmpIdAsString = Console.ReadLine();
                if (EmpIdAsString is null) { throw new NullReferenceException(); }
                long EmpId = long.Parse(EmpIdAsString);
                Company?.ModifyEmployee(EmpId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// Creating a request for the class Company
        private void CalculateSalary()
        {
            try
            {
                Console.Write("Write employee id: ");
                string? empIdAsString = Console.ReadLine();
                Console.Write("Write hours: ");
                string? hoursAsString = Console.ReadLine();
                if (hoursAsString == null || empIdAsString == null) { throw new NullReferenceException(); }
                long EmpId = long.Parse(empIdAsString);
                int hours = int.Parse(hoursAsString);
                Company?.CalculateSalary(EmpId, hours);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion // Private Methods 
    }
}