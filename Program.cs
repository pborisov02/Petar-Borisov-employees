namespace SirmaSolutionsProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Project> projects = new List<Project>();
            using (var reader = new StreamReader(@"*file path*"))
            {
                while(true)
                {
                    bool projectExist = false;
                    string input = reader.ReadLine();
                    if (input == null)
                        break;
                    string[] arguments = input.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    string empId = arguments[0];
                    string projId = arguments[1];
                    string startDate = arguments[2];
                    string endDate = arguments[3];
                    if (endDate == "NULL")
                        endDate = DateTime.Today.ToShortDateString();
                    foreach (var project in projects)
                    {
                        if (project.ProjId == projId)
                        {
                            project.AddEmployee(new Employee(empId, startDate, endDate));
                            projectExist = true;
                        }
                    }
                    if(!projectExist)
                    {
                        Project p = new Project(projId);
                        p.AddEmployee(new Employee(empId, startDate, endDate));
                        projects.Add(p);
                    }
                }

            }

            foreach(var project in projects)
            {
                if (project.Employees.Count >= 2)
                {
                    for (int i = 0; i < project.Employees.Count; i++)
                    {

                        for (int j = i + 1; j < project.Employees.Count; j++)
                        {
                            int daysWorked = 0;
                            if (project.Employees[i].EndDate > project.Employees[j].StartDate)
                            {
                                if (project.Employees[i].EndDate <= project.Employees[j].EndDate)
                                {
                                    daysWorked = Math.Abs(project.Employees[j].StartDate.DayNumber  - project.Employees[i].EndDate.DayNumber);
                                }
                                else
                                {
                                    daysWorked = Math.Abs(project.Employees[j].StartDate.DayNumber - project.Employees[j].EndDate.DayNumber);
                                }
                            }
                            if (daysWorked > project.Days)
                            {
                                project.Id1 = project.Employees[i].Id;
                                project.Id2 = project.Employees[j].Id;
                                project.Days = daysWorked;
                            }
                        }
                    }
                }
            }
            var result = projects.OrderByDescending(p => p.Days).First();
            Console.WriteLine($"The pair that has worked together on a project the longest according to the data are employees: {result.Id1} and {result.Id2}, they worked on project {result.ProjId} for total of {result.Days} days.");
        }
    }
}