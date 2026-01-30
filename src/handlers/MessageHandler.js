/**
 * Message Handler
 * 檢查 message API 的輸入型別
 * 
 * 檢查邏輯:
 * - type: string
 * - handle(payload: any): Promise<any> | any
 */
const emailHandler = require('./emailHandler');
const smsHandler = require('./smsHandler');

// 類型對應的 handler 映射
const handlers = {
  email: emailHandler,
  sms: smsHandler
};

/**
 * 驗證輸入型別
 * @param {any} type 
 * @param {any} payload 
 * @returns {Object} { valid, error?, statusCode? }
 */
const validateInput = (type, payload) => {
  // 檢查 type 是否為 string
  if (typeof type !== 'string') {
    return { 
      valid: false, 
      statusCode: 400, 
      error: 'type 必須是字串' 
    };
  }

  // 檢查 type 是否為支援的類型
  if (!handlers[type]) {
    return { 
      valid: false, 
      statusCode: 404, 
      error: `未知類型: ${type}` 
    };
  }

  // 檢查 payload 是否存在
  if (payload === undefined || payload === null) {
    return { 
      valid: false, 
      statusCode: 400, 
      error: '缺少 payload 欄位' 
    };
  }

  return { valid: true };
};

/**
 * 處理請求
 * @param {string} type 
 * @param {any} payload 
 * @returns {Promise<any> | any}
 */
const handle = async (type, payload) => {
  // 驗證輸入型別
  const validation = validateInput(type, payload);
  if (!validation.valid) {
    return {
      success: false,
      message: validation.error,
      data: {
        status: validation.statusCode
      }
    };
  }

  // 取得對應的 handler
  const handler = handlers[type];

  // 驗證該類型的 payload 格式
  const payloadValidation = handler.validatePayload(payload);
  if (!payloadValidation.valid) {
    return {
      success: false,
      message: payloadValidation.error,
      data: {
        status: 400
      }
    };
  }

  // 執行對應的 send 方法 (支援 Promise)
  const result = await handler.send(payload);
  return result;
};

/**
 * 取得支援的類型列表
 * @returns {string[]}
 */
const getSupportedTypes = () => {
  return Object.keys(handlers);
};

module.exports = {
  validateInput,
  handle,
  getSupportedTypes
};
