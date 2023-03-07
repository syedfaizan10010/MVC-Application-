namespace formProject.Models.DomainObject
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public int EmpStatus { get; set; }
        public string StatusName { get; set; }

        //public List<EmpStatus> EmpStatusName { get; set; }

        //public int StatusId { get; set; }
        //public string StatusName { get; set; }
    }
}
