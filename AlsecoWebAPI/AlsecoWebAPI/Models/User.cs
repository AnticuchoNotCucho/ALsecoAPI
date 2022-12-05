using System;
using System.Collections.Generic;

namespace AlsecoWebAPI.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Rut { get; set; } = null!;

    public string Address { get; set; } = null!;
}
