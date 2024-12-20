# Answers to Technical Questions

## 1. How long did you spend on the coding assignment? What would you add to your solution if you had more time?
I spent about 6 hours on the coding assignment. If I had more time,I would:
- Optimize the performance of data retrieval by finding an alternative source api.
- With a better source api , I could retreive more data about crypto currencies, So I would add InMemory/Distrubuted Caching to the project.
- Add rate limit.
- Use circuit breaker pattern for http requests.
- Use a database to store data for further use.

## 2. What was the most useful feature that was added to the latest version of your language of choice?
`field` keyword. This feature makes handling setters simpler and we will have semi automatic properties.

### Example:
```csharp
public string Sign
    {
        get;
        set => field = value ?? field;
    }
```

## 3. How would you track down a performance issue in production? Have you ever had to do this?
I have done tracking with monitoring logs on logging systems we have stablished and unfortunately sometimes remote debugging.And I also have familiarity with elastic. But I prefer using prometheus as monitoring tool.
Also .NET Aspire is a great tool for developers and helps us monitor our project performance during developmnt like a virtual production environment.


## 4. What was the latest technical book you have read or tech conference you have been to? What did you learn?
The latest conference I attended was *.Net 9 Conf* and .Net Aspire new features and development mentioned.
And recently I've started reading `C# 13 and .NET 9 Modern Cross Platform Development Fundamentals by Mark J. Price`.

## 5. What do you think about this technical assessment?
The assessment was cool. It had both technical challenges and challenges with third party sources.
Here I should mention that the project would handle data better if we had access to some other useful APIs.

## 6. Please, describe yourself using JSON.
```json
{
  "name": "Erfan Shahbazi",
  "age": "23",
  "role": ".Net Developer",
  "skills": ["C#", ".NET Core", "SQL", "Problem Solving"],
  "experience": {
    "years": 4,
    "stacks": ["Web Development", "APIs", "System Design"]
  },
  "interests": ["Technology", "Learning", "Collaboration"],
  "location": "Alborz Province, Iran",
  "contact": {
    "email": "dev.erfanshahbazi@gmail.com",
    "github": "https://github.com/ErfanShahbazi"
  }
}
```
