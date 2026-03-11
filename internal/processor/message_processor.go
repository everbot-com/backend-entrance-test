package processor

import "errors"

// ErrUnknownMessageType indicates that no handler is registered
// for the requested message type.
var ErrUnknownMessageType = errors.New("unknown message type")

// MessageHandler defines the contract for message handlers.
// Each message type should implement Type and Handle so it can be
// registered and dispatched by MessageProcessor.
type MessageHandler interface {
	// Type returns the message type key handled by this implementation.
	Type() string
	// Handle executes the business logic and returns a normalized result.
	Handle(payload map[string]any) (*HandlerResult, error)
}

// HandlerResult is the standard result structure returned by handlers.
type HandlerResult struct {
	Message string `json:"message"`
	Data    any    `json:"data"`
}

// MessageProcessor dispatches requests to the corresponding MessageHandler
// based on message type.
type MessageProcessor struct {
	handlers map[string]MessageHandler
}

// NewMessageProcessor creates an empty MessageProcessor instance.
func NewMessageProcessor() *MessageProcessor {
	return &MessageProcessor{handlers: make(map[string]MessageHandler)}
}

// Register registers a MessageHandler.
// If a duplicate type is registered, the latest handler overwrites the previous one.
func (m *MessageProcessor) Register(handler MessageHandler) {
	m.handlers[handler.Type()] = handler
}

// Process finds the handler by messageType and executes Handle.
// It returns ErrUnknownMessageType when the type has not been registered.
func (m *MessageProcessor) Process(messageType string, payload map[string]any) (*HandlerResult, error) {
	h, ok := m.handlers[messageType]
	if !ok {
		return nil, ErrUnknownMessageType
	}

	return h.Handle(payload)
}
