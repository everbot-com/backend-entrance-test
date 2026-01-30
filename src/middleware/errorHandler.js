/**
 * 錯誤處理 Middleware
 * 
 * Status Codes:
 * - 500: 伺服器內部錯誤 (預設)
 * - 或使用 err.statusCode 自訂錯誤碼
 */
const errorHandler = (err, req, res, next) => {
  console.error('Error:', err.message);

  // 500: 伺服器錯誤 (預設)
  const statusCode = err.statusCode || 500;
  const message = err.message || '伺服器內部錯誤';

  res.status(statusCode).json({
    success: false,
    message: message,
    data: {
      status: statusCode
    }
  });
};

module.exports = errorHandler;
