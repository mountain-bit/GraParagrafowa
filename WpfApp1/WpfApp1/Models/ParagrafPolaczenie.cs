using System;
using System.Collections.Generic;

namespace WpfApp1.Models;

public partial class ParagrafPolaczenie
{
    public int IdZrodla { get; set; }

    public int IdCelu { get; set; }

    public string? OpisAkcji { get; set; }

    public virtual Paragraf IdCeluNavigation { get; set; } = null!;

    public virtual Paragraf IdZrodlaNavigation { get; set; } = null!;
}
