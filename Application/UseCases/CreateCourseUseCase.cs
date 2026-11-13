using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases;

public class CreateCourseUseCase
{
    private readonly ICourseRepository _courseRepository;

    public CreateCourseUseCase(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<Guid> ExecuteAsync(string title, string description)
    {
        var course = new Course(Guid.NewGuid(), title, description);
        await _courseRepository.AddAsync(course);
        return course.Id;
    }
}