/**
 * 請求驗證 Middleware
 * 驗證 POST /message 的請求格式
 * 
 * Status Codes:
 * - 400: 請求錯誤 (缺少必要欄位)
 * - 404: 未知類型錯誤
 */
const Message = require('../models/Message');

const validateMessage = (req, res, next) => {
  const { type, payload } = req.body;

  const validation = Message.validate({ type, payload });
  if (!validation.valid) {
    return res.status(validation.statusCode).json({
      success: false,
      message: validation.error,
      data: {
        status: validation.statusCode
      }
    });
  }

  next();
};

module.exports = {
  validateMessage
};
