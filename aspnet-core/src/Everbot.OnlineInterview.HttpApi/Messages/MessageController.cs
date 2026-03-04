using System.Threading.Tasks;
using Everbot.OnlineInterview.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Everbot.OnlineInterview.Messages;

/// <summary>
/// 訊息控制器
/// </summary>
[Route("messages")]
//[Authorize]
//[Authorize(OnlineInterviewPermissions.Messages.Send)]
[AllowAnonymous]
public class MessageController : OnlineInterviewController
{
    private readonly IMessageAppService _messageAppService;

    public MessageController(IMessageAppService messageAppService)
    {
        _messageAppService = messageAppService;
    }

    /// <summary>
    /// 發送訊息
    /// </summary>
    /// <remarks>
    /// 回應碼說明：
    /// - 200 成功
    /// - 400 請求參數錯誤（缺少必填欄位）
    /// - 404 不支援的訊息類型
    /// - 500 伺服器內部錯誤
    /// </remarks>
    [HttpPost]
    [ProducesResponseType(typeof(MessageResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> SendAsync(MessageRequestDto input)
    {
        var result = await _messageAppService.SendAsync(input);

        if (!result.Success)
        {
            if (result.Data.Status == "404")
            {
                return NotFound(result.Data);
            }
            else if (result.Data.Status == "500")
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
        }

        return Ok(result);
    }
}
