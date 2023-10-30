using System;
using System.Collections.Generic;

namespace DIENAPPRESTAPI.Models;

public partial class Registration
{
    public int Registrationid { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Phonenumber { get; set; }
}
