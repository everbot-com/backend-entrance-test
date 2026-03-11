package main

import (
	"log"
	"mps/internal/handlers"
	"mps/internal/processor"
	"mps/internal/routes"

	"github.com/gin-gonic/gin"
)

func main() {
	r := gin.Default()

	mp := processor.NewMessageProcessor()
	mp.Register(handlers.NewEmailHandler())

	routes.RegisterMessageRoutes(r, mp)

	if err := r.Run(":8080"); err != nil {
		log.Fatalf("failed to start server: %v", err)
	}
}
