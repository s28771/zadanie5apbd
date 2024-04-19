namespace Tutorial4.Models;

public class Visit
{
    public int Id { get; set; }
    public int AnimalId { get; set; }
    public string DateOfVisit { get; set; }
    public string Description { get; set; }
    public decimal VisitCost { get; set; }
}