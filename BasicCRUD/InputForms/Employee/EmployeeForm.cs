namespace BasicCRUD.InputForms.Employee
{
    public class EmployeeForm
    {
        public string EmpId { get; set; }
        public string Fname { get; set; }
        public string Minit { get; set; }
        public string Lname { get; set; }
        public short JobId { get; set; }
        public byte JobLvl { get; set; }
        public string PubId { get; set; }
        public int HireYear { get; set; }
        public int HireMonth { get; set; }
        public int HireDay { get; set; }
    }
}
