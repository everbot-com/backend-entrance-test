package processor

import "errors"

var ErrUnknownMessageType = errors.New("unknown message type")

type MessageHandler interface {
	Type() string
	Handle(payload map[string]any) (*HandlerResult, error)
}

type HandlerResult struct {
	Message string `json:"message"`
	Data    any    `json:"data"`
}

type MessageProcessor struct {
	handlers map[string]MessageHandler
}

func NewMessageProcessor() *MessageProcessor {
	return &MessageProcessor{handlers: make(map[string]MessageHandler)}
}

func (m *MessageProcessor) Register(handler MessageHandler) {
	m.handlers[handler.Type()] = handler
}

func (m *MessageProcessor) Process(messageType string, payload map[string]any) (*HandlerResult, error) {
	h, ok := m.handlers[messageType]
	if !ok {
		return nil, ErrUnknownMessageType
	}

	return h.Handle(payload)
}
