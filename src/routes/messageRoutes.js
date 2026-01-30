const express = require('express');
const router = express.Router();
const messageController = require('../controllers/messageController');
const { validateMessage } = require('../middleware/validateRequest');

// POST /message
router.post('/message', validateMessage, messageController.handleMessage);

module.exports = router;
