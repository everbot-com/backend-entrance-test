package handlers

import (
	"errors"
	"fmt"
	"time"

	"mps/internal/processor"
)

// EmailHandler handles email-type messages.
type EmailHandler struct{}

// NewEmailHandler creates a new EmailHandler instance.
func NewEmailHandler() *EmailHandler {
	return &EmailHandler{}
}

// Type returns the message type key for EmailHandler.
func (h *EmailHandler) Type() string {
	return "email"
}

// Handle validates required email payload fields and returns a mocked send result.
// Required fields are to, subject, and body.
func (h *EmailHandler) Handle(payload map[string]any) (*processor.HandlerResult, error) {
	to, ok := payload["to"].(string)
	if !ok || to == "" {
		return nil, errors.New("invalid email payload: to is required")
	}

	subject, ok := payload["subject"].(string)
	if !ok || subject == "" {
		return nil, errors.New("invalid email payload: subject is required")
	}

	body, ok := payload["body"].(string)
	if !ok || body == "" {
		return nil, errors.New("invalid email payload: body is required")
	}

	_ = to
	_ = subject
	_ = body

	return &processor.HandlerResult{
		Message: "Email sent successfully",
		Data: map[string]any{
			"messageId": fmt.Sprintf("msg-%d", time.Now().UnixNano()),
			"status":    "sent",
		},
	}, nil
}
