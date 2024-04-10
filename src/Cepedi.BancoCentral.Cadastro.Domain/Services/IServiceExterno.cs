using Refit;

namespace Cepedi.BancoCentral.Cadastro.Domain.Services;
public interface IServiceExterno
{
    [Post("api/v1/Enviar")]
    Task<ApiResponse<HttpResponseMessage>> EnviarNotificacao([Body] object notificacao);
}
