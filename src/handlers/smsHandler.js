/**
 * SMS Handler
 * 處理 type: sms 的請求
 * 
 * Payload 結構:
 * {
 *   phone: string,   // 收件者電話號碼
 *   message: string  // 簡訊內容
 * }
 */

/**
 * 驗證 SMS payload
 * @param {Object} payload
 * @returns {Object} { valid, error? }
 */
const validatePayload = (payload) => {
  const { phone, message } = payload;

  if (!phone) {
    return { valid: false, error: '缺少 phone 欄位' };
  }

  if (!message) {
    return { valid: false, error: '缺少 message 欄位' };
  }

  return { valid: true };
};

/**
 * 發送 SMS
 * @param {Object} payload - SMS 內容
 */
const send = (payload) => {
  const { phone, message } = payload;

  // TODO: 實作 sms 發送邏輯
  console.log('Sending SMS to:', phone);

  // 產生唯一 ID
  const id = `sms_${Date.now()}`;

  return {
    success: true,
    message: 'SMS 已排入發送佇列',
    data: {
      id,
      status: 200
    }
  };
};

module.exports = {
  validatePayload,
  send
};
