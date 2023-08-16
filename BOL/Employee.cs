namespace BOL_poco_
{
    public class Employee
    {
        private int id;
        private string name;
        private double salary;
        public Employee() { }
        public Employee(int id, string name, double salary)
        {
            this.id = id;
            this.name = name;
            this.salary = salary;
        }
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public double Salary
        {
            get { return this.salary; } set { this.salary = value; }
        }
        public override string ToString()
        {
            string data=String.Format("Id={0},Name={1},Salary={2}",this.id,this.name,this.salary);
            return data;
        }
    }
}