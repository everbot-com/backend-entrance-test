package handlers

import "testing"

func TestEmailHandler_Handle(t *testing.T) {
	h := NewEmailHandler()

	_, err := h.Handle(map[string]any{
		"to":      "test@example.com",
		"subject": "hello",
		"body":    "world",
	})
	if err != nil {
		t.Fatalf("expected no error, got %v", err)
	}
}

func TestSMSHandler_Handle(t *testing.T) {
	h := NewSMSHandler()

	_, err := h.Handle(map[string]any{
		"to":      "+123456789",
		"message": "hello",
	})
	if err != nil {
		t.Fatalf("expected no error, got %v", err)
	}
}

func TestSMSHandler_InvalidPayload(t *testing.T) {
	h := NewSMSHandler()

	_, err := h.Handle(map[string]any{
		"to": "+123456789",
	})
	if err == nil {
		t.Fatalf("expected error for invalid payload")
	}
}
