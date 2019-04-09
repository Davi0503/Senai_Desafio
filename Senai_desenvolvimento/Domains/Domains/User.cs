using System;
using System.Collections.Generic;

namespace Infra.Data.Domains
{
    public partial class User
    {
        //public Usuarios()
        //{
        //    Wish = new HashSet<Wish>();
        //}

        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }

        //public ICollection<Wish> Wish { get; set; }
    }
}
