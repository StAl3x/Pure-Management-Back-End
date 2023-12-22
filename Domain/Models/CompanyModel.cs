using Domain.DTOs;
namespace Domain.Models;

public class CompanyModel
{
    public int userId { get; set; }

    public PutCompanyDTO company { get; set; }
}
