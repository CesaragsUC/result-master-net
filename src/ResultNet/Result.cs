﻿namespace ResultNet;

/// <summary>
///  https://learn.microsoft.com/pt-br/nuget/quickstart/create-and-publish-a-package-using-visual-studio?tabs=netcore-cli
/// </summary>
/// <typeparam name="T"></typeparam>

public class Result<T> : IResult<T>
{
    public List<string>? Messages { get; set; } = new List<string>();

    public bool Succeeded { get; set; }

    public T? Data { get; set; }


    public Exception Exception { get; set; }

    public int? Code { get; set; }

    #region Non Async Methods 

    #region Success Methods 

    public static Result<T> Success()
    {
        return new Result<T>
        {
            Succeeded = true,
            Data = default(T),
            Code = 200
        };
    }

    public static Result<T> Success(string message)
    {
        return new Result<T>
        {
            Succeeded = true,
            Messages = new List<string> { message },
            Code = 200
        };
    }

    public static Result<T> Success(T data)
    {
        return new Result<T>
        {
            Succeeded = true,
            Data = data,
            Code = 200
        };
    }

    public static Result<T> Success(T data, string message)
    {
        return new Result<T>
        {
            Succeeded = true,
            Messages = new List<string> { message },
            Data = data,
            Code = 200
        };
    }

    #endregion

    #region Failure Methods 

    public static Result<T> Failure()
    {
        return new Result<T>
        {
            Succeeded = false,
            Code = 400
        };
    }
    public static Result<T> FailureDb(T data, string message)
    {
        return new Result<T>
        {
            Succeeded = false,
            Messages = new List<string> { message },
            Code = 500
        };
    }
    public static Result<T> Failure(int code, string message)
    {
        return new Result<T>
        {
            Succeeded = false,
            Messages = new List<string> { message },
            Code = code
        };
    }

    public static Result<T> Failure(int code, List<string> messages)
    {
        return new Result<T>
        {
            Succeeded = false,
            Messages = messages,
            Code = code
        };
    }

    public static Result<T> Failure(string message)
    {
        return new Result<T>
        {
            Succeeded = false,
            Messages = new List<string> { message }
        };
    }

    public static Result<T> Failure(List<string> messages)
    {
        return new Result<T>
        {
            Succeeded = false,
            Messages = messages,
            Code = 400
        };
    }

    public static Result<T> Failure(T data)
    {
        return new Result<T>
        {
            Succeeded = false,
            Code = 400
        };
    }

    public static Result<T> Failure(T data, string message)
    {
        return new Result<T>
        {
            Succeeded = false,
            Messages = new List<string> { message },
            Code = 400
        };
    }

    public static Result<T> Failure(T data, List<string> messages)
    {
        return new Result<T>
        {
            Succeeded = false,
            Messages = messages,
            Code = 400
        };
    }

    public static Result<T> Failure(Exception exception)
    {
        return new Result<T>
        {
            Succeeded = false,
            Exception = exception,
            Code = 400
        };
    }

    #endregion

    #endregion

    #region Async Methods 

    #region Success Methods 

    public static Task<Result<T>> SuccessAsync()
    {
        return Task.FromResult(Success());
    }

    public static Task<Result<T>> SuccessAsync(string message)
    {
        return Task.FromResult(Success(message));
    }

    public static Task<Result<T>> SuccessAsync(T data)
    {
        return Task.FromResult(Success(data));
    }

    public static Task<Result<T>> SuccessAsync(T data, string message)
    {
        return Task.FromResult(Success(data, message));
    }

    #endregion

    #region Failure Methods 

    public static Task<Result<T>> FailureAsync()
    {
        return Task.FromResult(Failure());
    }

    //somente para falha de conexão com o banco
    public static Task<Result<T>> FailureDbAsync(T data, string message)
    {
        return Task.FromResult(FailureDb(data, message));
    }

    public static Task<Result<T>> FailureAsync(int code, string message)
    {
        return Task.FromResult(Failure(code, message));
    }

    public static Task<Result<T>> FailureAsync(int code, List<string> messages)
    {
        return Task.FromResult(Failure(code, messages));
    }


    public static Task<Result<T>> FailureAsync(string message)
    {
        return Task.FromResult(Failure(message));
    }

    public static Task<Result<T>> FailureAsync(List<string> messages)
    {
        return Task.FromResult(Failure(messages));
    }

    public static Task<Result<T>> FailureAsync(T data)
    {
        return Task.FromResult(Failure(data));
    }

    public static Task<Result<T>> FailureAsync(T data, string message)
    {
        return Task.FromResult(Failure(data, message));
    }

    public static Task<Result<T>> FailureAsync(T data, List<string> messages)
    {
        return Task.FromResult(Failure(data, messages));
    }

    public static Task<Result<T>> FailureAsync(Exception exception)
    {
        return Task.FromResult(Failure(exception));
    }

    #endregion

    #endregion
}