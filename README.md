# Message API

一個模組化的訊息發送 API，支援多種訊息類型（Email、SMS 等）。

## 專案結構

```
src/
├── controllers/
│   └── messageController.js    # /message API 入口
├── handlers/
│   ├── MessageHandler.js       # 輸入型別檢查 + 分發
│   ├── emailHandler.js         # Email 處理
│   └── smsHandler.js           # SMS 處理
├── middleware/
│   ├── errorHandler.js         # 全域錯誤處理
│   └── validateRequest.js      # 請求格式驗證
├── models/
│   └── Message.js              # 訊息模型驗證
└── routes/
    └── messageRoutes.js        # 路由定義
```

## API 端點

### POST /message

發送訊息請求。

**Request Body:**
```json
{
  "type": "email | sms",
  "payload": { ... }
}
```

## 請求檢查流程

```
Request
    │
    ▼
┌─────────────────────────────┐
│  1. validateRequest.js      │  檢查 type 和 payload 是否存在
│     (Middleware)            │  檢查 type 是否為支援的類型
└─────────────────────────────┘
    │
    ▼
┌─────────────────────────────┐
│  2. messageController.js    │  API 入口，呼叫 MessageHandler
└─────────────────────────────┘
    │
    ▼
┌─────────────────────────────┐
│  3. MessageHandler.js       │  檢查輸入型別：
│                             │  - type 必須是 string
│                             │  - type 必須是支援的類型
│                             │  - payload 必須存在
└─────────────────────────────┘
    │
    ▼
┌─────────────────────────────┐
│  4. emailHandler.js /       │  驗證該類型的 payload 格式
│     smsHandler.js           │  執行 send() 發送訊息
└─────────────────────────────┘
    │
    ▼
Response
```

## Handler 說明

### MessageHandler

輸入型別檢查器，負責：
- 驗證 `type` 為字串
- 驗證 `type` 為支援的類型
- 驗證 `payload` 存在
- 分發請求到對應的 handler

```javascript
// 介面定義
type: string
handle(payload: any): Promise<any> | any
```

### emailHandler

處理 Email 發送請求。

**Payload 結構：**
```json
{
  "to": "收件者 email",
  "subject": "郵件主旨",
  "body": "郵件內容"
}
```

### smsHandler

處理 SMS 發送請求。

**Payload 結構：**
```json
{
  "phone": "收件者電話號碼",
  "message": "簡訊內容"
}
```

## Status Codes

| Status Code | 說明 |
|-------------|------|
| 200 | 請求成功 |
| 400 | 請求錯誤（缺少必要欄位、格式錯誤） |
| 404 | 未知類型錯誤 |
| 500 | 伺服器內部錯誤 |

## Response 格式

**成功：**
```json
{
  "success": true,
  "message": "Email 已排入發送佇列",
  "data": {
    "id": "email_1738252800000",
    "status": 200
  }
}
```

**失敗：**
```json
{
  "success": false,
  "message": "錯誤訊息",
  "data": {
    "status": 400
  }
}
```

## 使用範例

### 發送 Email

```bash
curl -X POST http://localhost:3000/message \
  -H "Content-Type: application/json" \
  -d '{
    "type": "email",
    "payload": {
      "to": "test@example.com",
      "subject": "測試郵件",
      "body": "這是一封測試郵件"
    }
  }'
```

### 發送 SMS

```bash
curl -X POST http://localhost:3000/message \
  -H "Content-Type: application/json" \
  -d '{
    "type": "sms",
    "payload": {
      "phone": "0912345678",
      "message": "這是一則測試簡訊"
    }
  }'
```

## 新增 Handler

1. 在 `src/handlers/` 建立新的 handler 檔案（如 `pushHandler.js`）
2. 實作 `validatePayload()` 和 `send()` 方法
3. 在 `MessageHandler.js` 的 `handlers` 映射加入新類型
4. 在 `src/models/Message.js` 的 `VALID_TYPES` 加入新類型

## 啟動伺服器

```bash
# 開發模式
npm run dev

# 正式環境
npm run start
```
