package routes

import (
	"errors"
	"net/http"

	"github.com/gin-gonic/gin"

	"mps/internal/processor"
)

// MessageRequest defines the request payload for POST /messages.
// Type indicates the message kind (for example, email or sms), and Payload
// contains handler-specific fields.
type MessageRequest struct {
	Type    string         `json:"type" binding:"required"`
	Payload map[string]any `json:"payload" binding:"required"`
}

// MessageResponse is the unified response format for the messages API.
// Success indicates whether processing succeeded; Message is a human-readable
// description; Data contains optional result details.
type MessageResponse struct {
	Success bool   `json:"success"`
	Message string `json:"message"`
	Data    any    `json:"data,omitempty"`
}

// RegisterMessageRoutes registers message-related routes.
// It currently exposes POST /messages, validates request input, and delegates
// processing to MessageProcessor.
func RegisterMessageRoutes(r *gin.Engine, p *processor.MessageProcessor) {
	r.POST("/messages", func(c *gin.Context) {
		var req MessageRequest
		if err := c.ShouldBindJSON(&req); err != nil {
			c.JSON(http.StatusBadRequest, MessageResponse{
				Success: false,
				Message: "invalid request body",
			})
			return
		}

		result, err := p.Process(req.Type, req.Payload)
		if err != nil {
			if errors.Is(err, processor.ErrUnknownMessageType) {
				c.JSON(http.StatusNotFound, MessageResponse{
					Success: false,
					Message: "unknown message type",
				})
				return
			}

			c.JSON(http.StatusBadRequest, MessageResponse{
				Success: false,
				Message: err.Error(),
			})
			return
		}

		c.JSON(http.StatusOK, MessageResponse{
			Success: true,
			Message: result.Message,
			Data:    result.Data,
		})
	})
}
