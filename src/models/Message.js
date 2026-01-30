/**
 * Message Model
 * 定義訊息的結構和驗證
 */

const VALID_TYPES = ['email', 'sms'];

/**
 * 驗證訊息格式
 * @returns {Object} { valid, error?, statusCode? }
 * - 400: 請求錯誤 (缺少必要欄位)
 * - 404: 未知類型錯誤 (type 不存在)
 */
const validate = ({ type, payload }) => {
  if (!type) {
    return { valid: false, statusCode: 400, error: '缺少 type 欄位' };
  }

  if (!VALID_TYPES.includes(type)) {
    return { valid: false, statusCode: 404, error: `未知類型: ${type}，必須是 ${VALID_TYPES.join(' 或 ')}` };
  }

  if (!payload) {
    return { valid: false, statusCode: 400, error: '缺少 payload 欄位' };
  }

  return { valid: true };
};

module.exports = {
  VALID_TYPES,
  validate
};
