using System;
using System.Collections.Generic;

namespace WpfApp1.Models;

public partial class Postac
{
    public int IdPostaci { get; set; }

    public int IdKampanii { get; set; }

    public string Imie { get; set; } = null!;

    public string Statystyki { get; set; } = null!;

    public virtual Kampanium IdKampaniiNavigation { get; set; } = null!;
}
