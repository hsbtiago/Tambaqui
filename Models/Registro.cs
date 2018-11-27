using System;

namespace Tambaqui.Models
{    
    public abstract class Registro
    {
        public int Id { get; set; }
        public bool Ativo { get; set; } = true;     
        public DateTime DataDeCadastro { get; set; } = new DateTime();
        public DateTime? DataDaUltimaEdicao { get; set; }   
        public void InverterAtivo() => Ativo = !Ativo;
    }
}