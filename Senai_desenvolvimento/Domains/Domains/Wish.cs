using System;
using System.Collections.Generic;

namespace Infra.Data.Domains
{
    public partial class Wish
    {
        public int Id { get; set; }
        public DateTime Creationdt { get; set; }
        public string Descwish { get; set; }
        public bool Ativo { get; set; }
        public int IdUsuario { get; set; }

        //public Usuarios IdUsuarioNavigation { get; set; }
    }
}
