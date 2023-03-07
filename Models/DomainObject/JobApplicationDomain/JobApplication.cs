namespace formProject.Models.DomainObject.JobApplicationDomain
{
    public class JobApplication
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserMailId { get; set; }
        public string UserPhoneNo { get; set; }
        public int UserInterestId { get; set; }
        public string UserHobbies { get; set; }
        public string UserProjectDescription { get; set; }
        public int UserGraduationYear { get; set; }
        public string UserInstitueName { get; set; }
        public int JobId { get; set; }
        public int JobLocationId { get; set; }
        public int JobTypeId { get; set; }
    }
}
