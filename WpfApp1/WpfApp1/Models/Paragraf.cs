using System;
using System.Collections.Generic;

namespace WpfApp1.Models;

public partial class Paragraf
{
    public int Numer { get; set; }

    public int IdKampanii { get; set; }

    public string Tresc { get; set; } = null!;

    public string? Streszczenie { get; set; }

    public string? Dzialanie { get; set; }

    public virtual Kampanium IdKampaniiNavigation { get; set; } = null!;

    public virtual ICollection<ParagrafPolaczenie> ParagrafPolaczenieIdCeluNavigations { get; set; } = new List<ParagrafPolaczenie>();

    public virtual ICollection<ParagrafPolaczenie> ParagrafPolaczenieIdZrodlaNavigations { get; set; } = new List<ParagrafPolaczenie>();
}
