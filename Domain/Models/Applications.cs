namespace Domain.Models;


public class Application
{
    public int ApplicationId { get; set; }
    public int JobId { get; set; }
    public int UserId { get; set; }
    public string? Resue { get; set; }
    public string? Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdateddAt { get; set; }
}