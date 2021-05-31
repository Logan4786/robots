namespace PjeApplication.entities
{
    public class Processos
    {
        public string Procedimento { get; set; }
        public int ListaForum { get; set; }

        public Processos(){}
        
        public Processos(string procedimento, int listaForum){
            Procedimento = procedimento;
            ListaForum = listaForum;
        }
    }
}