using System;
using System.Collections.Generic;

[Serializable]
public sealed class UsersData
{
    public List<User> Users;
}

[Serializable]
public sealed class User
{
    public string Login;

    public string Password;
}
