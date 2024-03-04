using Ecommerce.API.DTO;

namespace Ecommerce.WebAssembly.Servicios.Contrato
{
    public interface IVentaServicio
    {
        Task<ResponseDTO<VentaDTO>> Registrar(VentaDTO modelo);
    }
}
