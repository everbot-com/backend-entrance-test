package handlers

import (
	"errors"
	"fmt"
	"time"

	"mps/internal/processor"
)

// SMSHandler handles sms-type messages.
type SMSHandler struct{}

// NewSMSHandler creates a new SMSHandler instance.
func NewSMSHandler() *SMSHandler {
	return &SMSHandler{}
}

// Type returns the message type key for SMSHandler.
func (h *SMSHandler) Type() string {
	return "sms"
}

// Handle validates required sms payload fields and returns a mocked send result.
// Required fields are to and message.
func (h *SMSHandler) Handle(payload map[string]any) (*processor.HandlerResult, error) {
	to, ok := payload["to"].(string)
	if !ok || to == "" {
		return nil, errors.New("invalid sms payload: to is required")
	}

	message, ok := payload["message"].(string)
	if !ok || message == "" {
		return nil, errors.New("invalid sms payload: message is required")
	}

	_ = to
	_ = message

	return &processor.HandlerResult{
		Message: "SMS sent successfully",
		Data: map[string]any{
			"messageId": fmt.Sprintf("msg-%d", time.Now().UnixNano()),
			"status":    "sent",
		},
	}, nil
}
