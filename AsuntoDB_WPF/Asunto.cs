//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AsuntoDB_WPF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Asunto
    {
        public Asunto()
        {
            this.Henkilo = new HashSet<Henkilo>();
        }
    
        public int Avain { get; set; }
        public string Asuntonumero { get; set; }
        public string Osoite { get; set; }
        public int Pinta_ala { get; set; }
        public int Huonelukumaara { get; set; }
        public int AsuntotyyppiKoodi { get; set; }
        public bool Omistusasunto { get; set; }
    
        public virtual Asuntotyyppi Asuntotyyppi { get; set; }
        public virtual ICollection<Henkilo> Henkilo { get; set; }
    }
}
