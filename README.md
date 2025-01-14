
# FluentResultNet :rocket:

**FluentResultNet** is a .NET library that simplifies the management of standardized returns for methods in applications. This package offers a unified approach to handling successes, failures, error messages, and exceptions, reducing the complexity of response handling in synchronous and asynchronous methods.

## Features

- **Standardized Returns**: Ensures consistency in method returns throughout the application.
- **Detailed Messages**: Supports custom messages in success or failure operations.
- **Exception Handling**: Captures and encapsulates exceptions to maintain error control in the application flow.
- **Support for Asynchronous Operations**: `SuccessAsync` and `FailureAsync` methods make it easier to use in asynchronous scenarios.
- **Response Codes**: Returns HTTP status codes (`200`, `400`, `500`, etc.) to simplify API integration.

## Usage Example


```csharp
public class EmployeeDto
{
	public int Id {get; set;}
	public string Name {get; set;}
	public string Email {get; set;}
}
```

```csharp
public async Task<Result<List<EmployeeDto>>> List()
{
    try
    {
        var employees = await _employeeRepository.List();

        var employeeDtos = _mapper.Map<List<EmployeeDto>>(employees);

        if (employeeDtos is null)
            return Result<List<EmployeeDto>>.Failure("No employees found");

        return await Result<List<EmployeeDto>>.SuccessAsync(employeeDtos);
    }
    catch (Exception ex)
    {
        return await Result<List<EmployeeDto>>.FailureAsync(500, "Service failure.");
    }
}
```
### Controller

```csharp
[HttpGet]
[Route("all")]
public async Task<IActionResult> Get()
{
    var result = await _employeeService.List();
    return result.Succeeded ? Ok(result) : BadRequest(result);
}
```
Output:

```json
{
    "messages": [],
    "succeeded": true,
    "data": {
		[
			{
			   "id": 1,
			   "name": "jhon doe",
			   "email": "jhon@email.com"
			},
			{
			   "id": 2,
			   "name": "lupito lisk",
			   "email": "lupito@email.com"
			}
		]
    },
    "exception": null,
    "code": 200
}
```

### ⚙️ Installation:

```html
Install-Package FluentResultNet
```

🤝 Contribution

Contributions are welcome!

* Fork the repository.
* Create a branch for your feature (git checkout -b feature/NewFeature).
* Commit your changes (git commit -m "Added a new feature X").
* Push to the branch (git push origin feature/NewFeature).
* Open a Pull Request.

⭐ Star the project!

If you found this package useful, don’t forget to give it a ⭐ on GitHub!
