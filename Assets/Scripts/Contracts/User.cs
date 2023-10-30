using System;

/// <summary>
/// Запись о пользователе.
/// </summary>
[Serializable]
public sealed class User
{
    public string Login;

    public string Password;

    public string FirstName;

    public string LastName;

    public int Points;

    public float SalePersantage;
}