using System;
using System.Collections.Generic;

/// <summary>
/// Список пользователей.
/// </summary>
[Serializable]
public sealed class UsersData
{
    public List<User> Users;
}

/// <summary>
/// Запись о пользователе.
/// </summary>
[Serializable]
public sealed class User
{
    public string Login;

    public string Password;
}
