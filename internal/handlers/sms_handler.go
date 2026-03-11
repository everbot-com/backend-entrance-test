package handlers

import (
	"errors"
	"fmt"
	"time"

	"mps/internal/processor"
)

type SMSHandler struct{}

func NewSMSHandler() *SMSHandler {
	return &SMSHandler{}
}

func (h *SMSHandler) Type() string {
	return "sms"
}

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
