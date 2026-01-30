/**
 * Email Handler
 * 處理 type: email 的請求
 * 
 * Payload 結構:
 * {
 *   to: string,       // 收件者 email
 *   subject: string,  // 郵件主旨
 *   body: string      // 郵件內容
 * }
 */

/**
 * 驗證 Email payload
 * @param {Object} payload
 * @returns {Object} { valid, error? }
 */
const validatePayload = (payload) => {
  const { to, subject, body } = payload;

  if (!to) {
    return { valid: false, error: '缺少 to 欄位' };
  }

  if (!subject) {
    return { valid: false, error: '缺少 subject 欄位' };
  }

  if (!body) {
    return { valid: false, error: '缺少 body 欄位' };
  }

  return { valid: true };
};

/**
 * 發送 Email
 * @param {Object} payload - Email 內容
 */
const send = (payload) => {
  const { to, subject, body } = payload;

  // TODO: 實作 email 發送邏輯
  console.log('Sending email to:', to);

  // 產生唯一 ID
  const id = `email_${Date.now()}`;

  return {
    success: true,
    message: 'Email 已排入發送佇列',
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
