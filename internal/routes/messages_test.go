package routes

import (
	"bytes"
	"net/http"
	"net/http/httptest"
	"testing"

	"github.com/gin-gonic/gin"

	"mps/internal/handlers"
	"mps/internal/processor"
)

func setupRouter() *gin.Engine {
	gin.SetMode(gin.TestMode)
	r := gin.New()

	mp := processor.NewMessageProcessor()
	mp.Register(handlers.NewEmailHandler())
	mp.Register(handlers.NewSMSHandler())

	RegisterMessageRoutes(r, mp)
	return r
}

func TestPostMessages_EmailSuccess(t *testing.T) {
	r := setupRouter()

	body := []byte(`{"type":"email","payload":{"to":"test@example.com","subject":"Hello","body":"World"}}`)
	req, _ := http.NewRequest(http.MethodPost, "/messages", bytes.NewBuffer(body))
	req.Header.Set("Content-Type", "application/json")

	w := httptest.NewRecorder()
	r.ServeHTTP(w, req)

	if w.Code != http.StatusOK {
		t.Fatalf("expected 200, got %d", w.Code)
	}
}

func TestPostMessages_UnknownType(t *testing.T) {
	r := setupRouter()

	body := []byte(`{"type":"line","payload":{"text":"hello"}}`)
	req, _ := http.NewRequest(http.MethodPost, "/messages", bytes.NewBuffer(body))
	req.Header.Set("Content-Type", "application/json")

	w := httptest.NewRecorder()
	r.ServeHTTP(w, req)

	if w.Code != http.StatusNotFound {
		t.Fatalf("expected 404, got %d", w.Code)
	}
}

func TestPostMessages_InvalidBody(t *testing.T) {
	r := setupRouter()

	body := []byte(`{"payload":{}}`)
	req, _ := http.NewRequest(http.MethodPost, "/messages", bytes.NewBuffer(body))
	req.Header.Set("Content-Type", "application/json")

	w := httptest.NewRecorder()
	r.ServeHTTP(w, req)

	if w.Code != http.StatusBadRequest {
		t.Fatalf("expected 400, got %d", w.Code)
	}
}
