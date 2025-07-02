using System;
using System.Collections.Generic;

namespace WpfApp1.Models;

public partial class Kampanium
{
    public int IdKampanii { get; set; }

    public string Tytul { get; set; } = null!;

    public string? Opis { get; set; }

    public virtual ICollection<Paragraf> Paragrafs { get; set; } = new List<Paragraf>();

    public virtual ICollection<Postac> Postacs { get; set; } = new List<Postac>();

    public virtual ICollection<Przedmiot> Przedmiots { get; set; } = new List<Przedmiot>();
}
