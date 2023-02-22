namespace SirmaSolutionsProblem
{
    internal class Project
    {
		List<Employee> employees = new List<Employee>();

		public Project(string id)
		{
			ProjId = id;
		}
		private string projId;

		public string ProjId
		{
			get { return projId; }
			set { projId = value; }
		}

		public List<Employee> Employees 
		{
			get { return employees; }
		}

		public void AddEmployee(Employee employee)
		{
			employees.Add(employee);
			employees = employees.OrderBy(e => e.StartDate).ToList();
		}
		
		//Worked the most on this Project  
		public string Id1;
		public string Id2;
		public int Days;
	}
}
