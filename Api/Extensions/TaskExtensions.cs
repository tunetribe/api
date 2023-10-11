﻿namespace QuizAPI.Extensions;

public static class TaskExtensions
{
    public static T WaitForResult<T>(this Task<T> task)
    {
        task.Wait();
        return task.Result;
    }
}