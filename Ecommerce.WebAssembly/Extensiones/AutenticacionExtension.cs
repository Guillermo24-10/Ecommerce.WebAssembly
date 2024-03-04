

using Blazored.LocalStorage;
using Ecommerce.API.DTO;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Ecommerce.WebAssembly.Extensiones
{
    public class AutenticacionExtension : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private ClaimsPrincipal _principal = new ClaimsPrincipal(new ClaimsIdentity());

        public AutenticacionExtension(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task ActualizarEstadoAutenticacion(SesionDTO sesionUsuario)
        {
            ClaimsPrincipal claims;

            if (sesionUsuario != null)
            {
                claims = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, sesionUsuario.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Name, sesionUsuario.NombreCompleto!.ToString()),
                    new Claim(ClaimTypes.Email, sesionUsuario.Correo!.ToString()),
                    new Claim(ClaimTypes.Role, sesionUsuario.Rol!.ToString()),
                }, "JwtAuth"));

                await _localStorageService.SetItemAsync("sesionUsuario", sesionUsuario);
            }
            else
            {
                claims = _principal;
                await _localStorageService.RemoveItemAsync("sesionUsuario");
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claims)));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var sesionUsuario = await _localStorageService.GetItemAsync<SesionDTO>("sesionUsuario");

            if (sesionUsuario == null)
                return await Task.FromResult(new AuthenticationState(_principal));

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, sesionUsuario.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Name, sesionUsuario.NombreCompleto!.ToString()),
                    new Claim(ClaimTypes.Email, sesionUsuario.Correo!.ToString()),
                    new Claim(ClaimTypes.Role, sesionUsuario.Rol!.ToString()),
                }, "JwtAuth"));

            return await Task.FromResult(new AuthenticationState(claimsPrincipal));
        }
    }
}
