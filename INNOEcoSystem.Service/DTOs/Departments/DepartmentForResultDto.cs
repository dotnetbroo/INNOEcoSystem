namespace INNOEcoSystem.Service.DTOs.Departments;

public  class DepartmentForResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
    public string Website { get; set; }
    public string License { get; set; }
    public string Description { get; set; }
    public string PhoneNumber { get; set; }
    public string CallCenterNumer { get; set; }
    public long LocationId { get; set; }
    public long CategoryId { get; set; }
}
