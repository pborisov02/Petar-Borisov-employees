namespace SirmaSolutionsProblem
{
    public class Employee
    {
		public Employee(string id,string startDate, string endDate)
		{
			this.id = id;
			this.startDate = DateOnly.Parse(startDate);
            this.endDate = DateOnly.Parse(endDate);
        }
		private string id;
        public string Id
		{
			get { return id; }
			private set { id = value; }
		}
        
		private DateOnly startDate;
        public DateOnly StartDate
		{
			get { return startDate; }
			set { startDate = value; }
		}

		private DateOnly endDate;
		public DateOnly EndDate
		{
			get { return endDate; }
			set { endDate = value; }
		}


	}
}
