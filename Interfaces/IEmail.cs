using System.Threading.Tasks;

namespace Tambaqui.Interfaces
{
    public interface IEmail
    {
        Task EnviarAsync(string destino, string assunto, string mensagem);
        Task EnviarEmailParaCriacaoDeSenha(string emailDestino, string hashDeCriacaoDeSenha);
        Task EnviarEmailParaTrocaDeSenha(string emailDestino, string hashDeAlteracaoDeSenha);
    }
}