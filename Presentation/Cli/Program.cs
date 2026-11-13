using Application.UseCases;
using Domain.Interfaces;
using Infrastructure.Repositories;

namespace Cli;

class Program
{
    static async Task Main(string[] args)
    {
        // Ручне збирання залежностей через Dependency Injection (DI)
        ICourseRepository repository = new JsonCourseRepository("courses.json");
        var createCourseUseCase = new CreateCourseUseCase(repository);

        Console.WriteLine("=== Навчальна платформа (E-Learning Platform) ===");

        // Створення нового курсу як демонстрація роботи
        var newCourseId = await createCourseUseCase.ExecuteAsync("Основи Clean Architecture", "Лабораторна робота №5");
        Console.WriteLine($"Успішно створено курс із ID: {newCourseId}");
    }
}