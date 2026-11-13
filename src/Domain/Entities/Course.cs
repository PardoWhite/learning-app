namespace Domain.Entities;

public class Course
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }

    public Course(Guid id, string title, string description)
    {
        Id = id;
        Title = title;
        Description = description;
    }
}