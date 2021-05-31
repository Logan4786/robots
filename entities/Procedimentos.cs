namespace PjeApplication.entities
{
    public class Procedimentos
    {
        public string Estado { get; set; }
        public string Tribunal { get; set; }
        public int Tipo { get; set; }
        public int Caminho { get; set; }
        public string Status { get; set; }

        public Procedimentos(){}

        public Procedimentos(string estado, string tribunal, int tipo, int caminho, string status){
            Estado = estado;
            Tribunal = tribunal;
            Tipo = tipo;
            Caminho = caminho;
            Status = status;
        }
    }
}