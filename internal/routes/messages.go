package routes

import (
	"errors"
	"net/http"

	"github.com/gin-gonic/gin"

	"mps/internal/processor"
)

type MessageRequest struct {
	Type    string         `json:"type" binding:"required"`
	Payload map[string]any `json:"payload" binding:"required"`
}

type MessageResponse struct {
	Success bool   `json:"success"`
	Message string `json:"message"`
	Data    any    `json:"data,omitempty"`
}

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
