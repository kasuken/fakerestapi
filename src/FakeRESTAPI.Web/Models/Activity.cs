namespace FakeRESTAPI.Web.Models;

public class Activity
{
    public int ID { get; set; }

    public string Title { get; set; }

    public DateTime DueDate { get; set; }

    public bool Completed { get; set; }
}
