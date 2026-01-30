/**
 * Message Controller
 * /message API 入口
 * 
 * Status Codes:
 * - 200: 請求成功
 * - 400: 請求錯誤
 * - 404: 未知類型
 * - 500: 伺服器錯誤
 */
const MessageHandler = require('../handlers/MessageHandler');

/**
 * 處理 POST /message 請求
 */
const handleMessage = async (req, res, next) => {
  try {
    const { type, payload } = req.body;

    // 透過 MessageHandler 檢查並處理請求
    const result = await MessageHandler.handle(type, payload);

    // 根據結果返回對應的狀態碼
    const statusCode = result.success ? 200 : (result.data?.status || 500);
    res.status(statusCode).json(result);
  } catch (error) {
    next(error);
  }
};

module.exports = {
  handleMessage
};
