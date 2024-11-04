namespace WebAtendeCidadao.Models
{
    public class SolicitacaoModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public int Status { get; set; }
    }
}

