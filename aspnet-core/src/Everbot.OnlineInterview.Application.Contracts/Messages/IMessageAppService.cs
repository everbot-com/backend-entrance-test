using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Everbot.OnlineInterview.Messages;

/// <summary>
/// 訊息服務介面
/// </summary>
public interface IMessageAppService : IApplicationService
{
    /// <summary>
    /// 發送訊息
    /// </summary>
    Task<MessageResponseDto> SendAsync(MessageRequestDto input);
}
