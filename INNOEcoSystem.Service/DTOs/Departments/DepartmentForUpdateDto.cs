namespace INNOEcoSystem.Service.DTOs.Departments;

public class DepartmentForUpdateDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public string Description { get; set; }
    public string PhoneNumber { get; set; }
    public string CallCenterNumer { get; set; }
    public long LocationId { get; set; }
    public long CategoryId { get; set; }
}
