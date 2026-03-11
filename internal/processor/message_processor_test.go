package processor

import (
	"errors"
	"testing"
)

type mockHandler struct {
	messageType string
}

func (m *mockHandler) Type() string {
	return m.messageType
}

func (m *mockHandler) Handle(payload map[string]any) (*HandlerResult, error) {
	return &HandlerResult{
		Message: "ok",
		Data:    payload,
	}, nil
}

func TestMessageProcessor_Process(t *testing.T) {
	mp := NewMessageProcessor()
	mp.Register(&mockHandler{messageType: "mock"})

	result, err := mp.Process("mock", map[string]any{"a": "b"})
	if err != nil {
		t.Fatalf("expected no error, got %v", err)
	}

	if result.Message != "ok" {
		t.Fatalf("expected message ok, got %s", result.Message)
	}
}

func TestMessageProcessor_UnknownType(t *testing.T) {
	mp := NewMessageProcessor()

	_, err := mp.Process("unknown", map[string]any{})
	if !errors.Is(err, ErrUnknownMessageType) {
		t.Fatalf("expected ErrUnknownMessageType, got %v", err)
	}
}
