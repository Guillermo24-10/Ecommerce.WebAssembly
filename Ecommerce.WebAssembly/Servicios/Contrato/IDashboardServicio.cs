using Ecommerce.API.DTO;

namespace Ecommerce.WebAssembly.Servicios.Contrato
{
    public interface IDashboardServicio
    {
        Task<ResponseDTO<DashboardDTO>> Resumen();
    }
}
