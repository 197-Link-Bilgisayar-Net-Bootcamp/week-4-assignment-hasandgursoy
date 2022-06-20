using Core.Dtos;
using SharedLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IAuthenticationService
    {
        Task<ResponseDto<TokenDto>> CreateTokenAsync(LoginDto loginDto );
        Task<ResponseDto<TokenDto>> CreateTokenByRefreshToken(string refreshToken);
        // Token'ın Etkinlik kırmak için Dto
        Task<ResponseDto<NoDataDto>> RevokeRefreshToken(string refreshToken);
        Task<ResponseDto<ClientTokenDto>> CreateTokenByClient(ClientLoginDto clientLoginDto);
    }
}
