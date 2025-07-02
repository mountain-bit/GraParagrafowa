using System;
using System.Collections.Generic;

namespace WpfApp1.Models;

public partial class Przedmiot
{
    public int IdPrzedmiotu { get; set; }

    public int IdKampanii { get; set; }

    public string Nazwa { get; set; } = null!;

    public string Typ { get; set; } = null!;

    public string? Statystyki { get; set; }

    public string? Opis { get; set; }

    public virtual Kampanium IdKampaniiNavigation { get; set; } = null!;
}
