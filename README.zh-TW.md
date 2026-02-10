# 後端工程師實作測驗 — 插件式訊息處理系統

## 概述

請使用 **TypeScript** 實作一個**插件式訊息處理系統**。
系統應該接受不同類型的訊息，並根據訊息類型將其分發到正確的處理器。

**注意事項：**

- 可使用任何套件管理器（npm、yarn、bun、pnpm 等）
- 若真的不會 TypeScript，可使用 JavaScript（但建議使用 TypeScript）
- 您也可以選擇使用您熟悉的其他後端語言（例如：Python、Go、Java、Rust 等）

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
- 回傳處理器的結果
- 應返回適當的 HTTP 狀態碼（200 表示成功，400 表示錯誤請求，404 表示未知訊息類型，500 表示伺服器錯誤）

框架可自由選擇：

- Elysia.js
- Express
- Fastify
- NestJS
- 或原生 Node.js/Bun HTTP

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

## 運行說明

### 系統需求

- **Bun**: 版本 1.0.0 或更高
- **Node.js**: 版本 18.0.0 或更高（如果使用 Node.js 運行）
- **TypeScript**: 版本 5.0 或更高

### 安裝依賴

```bash
bun install
```

### 運行開發服務器

```bash
bun run dev
```

服務器將在 `http://localhost:3000`（或您指定的端口）啟動，並在文件更改時自動重載。

### 運行生產環境

```bash
bun start
```

### 構建項目

```bash
bun run build
```

編譯後的文件將輸出到 `dist/` 目錄。

### 測試 API

#### 使用 curl 發送請求

```bash
# 發送電子郵件
curl -X POST http://localhost:3000/messages \
  -H "Content-Type: application/json" \
  -d '{
    "type": "email",
    "payload": {
      "to": "test@example.com",
      "subject": "Hello",
      "body": "World"
    }
  }'

# 發送 SMS
curl -X POST http://localhost:3000/messages \
  -H "Content-Type: application/json" \
  -d '{
    "type": "sms",
    "payload": {
      "to": "+1234567890",
      "message": "Hello World"
    }
  }'
```

---

## 提交

**請 fork 此儲存庫，待實作完畢後發 Pull Request (PR)。**

請提供：

- GitHub 儲存庫連結（確保它是公開的或可訪問的）
- 清晰的項目運行說明（包括 Node.js/Bun 版本要求以及其他相關的必要資訊）
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
