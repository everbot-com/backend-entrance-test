const express = require('express');
const app = express();
const PORT = process.env.PORT || 3000;

// Routes
const messageRoutes = require('./src/routes/messageRoutes');

// Middleware
const errorHandler = require('./src/middleware/errorHandler');

app.use(express.json());

// 基本頁面
app.get('/', (_, res) => {
  res.json({ message: '歡迎使用 Express API！' });
});

// health check API
app.get('/health', (_, res) => {
  res.json({ status: 'ok', timestamp: new Date().toISOString() });
});

// API Routes
app.use('/', messageRoutes);

// 錯誤處理 (放在所有路由之後)
app.use(errorHandler);

// 啟動伺服器
app.listen(PORT, () => {
  console.log(`伺服器正在執行於 http://localhost:${PORT}`);
});
