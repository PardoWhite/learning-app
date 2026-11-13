using System.Text.Json;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class JsonCourseRepository : ICourseRepository
{
    private readonly string _filePath;

    public JsonCourseRepository(string filePath)
    {
        _filePath = filePath;
    }

    public async Task<Course?> GetByIdAsync(Guid id)
    {
        var courses = await GetAllAsync();
        return courses.FirstOrDefault(c => c.Id == id);
    }

    public async Task<IEnumerable<Course>> GetAllAsync()
    {
        if (!File.Exists(_filePath)) return new List<Course>();
        var json = await File.ReadAllTextAsync(_filePath);
        return JsonSerializer.Deserialize<List<Course>>(json) ?? new List<Course>();
    }

    public async Task AddAsync(Course course)
    {
        var courses = (await GetAllAsync()).ToList();
        courses.Add(course);
        var json = JsonSerializer.Serialize(courses, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(_filePath, json);
    }
}