namespace TodolistApi.Controllers;

public class TodoItem
{
    public long Id { get; init; }

    public bool IsComplete { get; init; }

    public string Name { get; init; }
}