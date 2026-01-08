# 後端工程師實作測驗 — 插件式訊息處理系統

目標是評估架構設計、TypeScript 熟練度、API 設計和擴展性思維。

---

## 概述

請使用 **TypeScript** 實作一個**插件式訊息處理系統**。  
系統應該接受不同類型的訊息，並根據訊息類型將其分發到正確的處理器。

**注意事項：**

- 可使用任何套件管理器（npm、yarn、bun、pnpm 等）
- 若真的不會 TypeScript，不勉強使用 TypeScript，可使用 JavaScript（但建議使用 TypeScript）

範例訊息：

```json
{
  "type": "email",
  "payload": {
    "to": "test@example.com",
    "subject": "Hello",
    "body": "World"
  }
}
```

範例響應：

```json
{
  "success": true,
  "message": "Email sent successfully",
  "data": {
    "messageId": "msg-123",
    "status": "sent"
  }
}
```

系統必須至少支援：

- email
- sms

未來的訊息類型（例如：LINE、Slack、Webhook）應該能夠輕鬆添加，而無需修改核心邏輯。

---

## 需求

### 1. API

實作一個 POST 端點：

#### POST /messages

請求體：

```json
{
  "type": "email" | "sms",
  "payload": { ... }
}
```

- 接受 { type, payload }
- 分發到正確的處理器
- 返回處理器的結果
- 應返回適當的 HTTP 狀態碼（200 表示成功，400 表示錯誤請求，404 表示未知訊息類型，500 表示伺服器錯誤）

框架可自由選擇：

- Express
- Fastify
- NestJS
- 或原生 Node.js HTTP

---

### 2. 插件架構

您必須實作：

#### MessageHandler 介面（或抽象類別）

定義：

- `type: string`
- `handle(payload: any): Promise<any> | any`

#### 處理器

至少實作：

- EmailHandler
- SmsHandler

每個處理器必須實作 MessageHandler 介面。

#### MessageProcessor

負責：

- 註冊處理器
- 映射 type → handler
- 分發訊息
- 處理未知類型

---

### 3. 代碼結構

您的代碼應該組織成模組，例如：

```text
src/
  handlers/
    email.handler.ts
    sms.handler.ts
  processor/
    message-processor.ts
  routes/
    messages.route.ts
  index.ts
```

不需要資料庫。
所有資料可以儲存在記憶體中。

---

## 提交

**請以 fork 的方式 fork 此儲存庫，待實作完畢後發 Pull Request (PR)。**

請提供：

- GitHub 儲存庫連結（確保它是公開的或可訪問的）
- 清晰的項目運行說明（包括 Node.js 版本要求，如有）
- `package.json`，包含所有必要的腳本（例如：`bun start`、`bun run dev`）
- （可選）設計決策和權衡的說明
- （可選）架構選擇的簡要解釋

---

## 時間限制

您有 **1 小時** 完成實作。

**重要注意事項：**

- 您可以使用 AI 工具協助，但您應該理解並能夠解釋您的代碼
- 首先專注於核心功能，然後如果時間允許，再添加加分功能
- 代碼質量和架構比功能完整性更重要
- 確保代碼能夠編譯並運行，沒有錯誤

---

祝您好運，實作愉快！
