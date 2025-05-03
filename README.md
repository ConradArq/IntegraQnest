# IntegraQnest 🧠✨
*A Blazor WebAssembly (hosted) application showcasing AI integration, single sign-on (SSO), secure messaging, and resilient microservice patterns. Built with a hybrid UI using React and TypeScript alongside Blazor.*

## 🔍 Overview
**IntegraQnest** is a modular and scalable application built with modern .NET technologies to demonstrate:
- Local AI reasoning (RAG-style flow using compiled Sentence Transformers)
- Face recognition with webcam input
- OAuth & SSO authentication with external identity providers
- Slack-based smart notifications
- Resilient messaging via Azure Service Bus + background processing
- Payment gateway integration (mocked)
- Deep profiling, observability, and fault-tolerance techniques

⚠️ *This project is a work-in-progress — I’m actively building it as a showcase of my software architecture and integration skills.*

---

## 🧱 Features

| Category | Features |
|---------|----------|
| 🧠 AI | Context-aware chatbot using local embeddings (compiled transformer model) |
| 🎥 Vision | Face detection with webcam + identity matching |
| 🔐 Auth | OAuth2 + SSO via my custom Authentication service |
| 📣 Integrations | Slack alerts (Polly retry), mocked CRM (HubSpot/Salesforce), Stripe/PayPal |
| 💬 Messaging | Azure Service Bus + Azure Function trigger for email processing |
| 🔍 Observability | Application Insights, dotnet-trace, Visual Studio Profiler, Polly Circuit Breaker |
| 🧪 Testing | `WebApplicationFactory<T>`, mocked services, CI-ready |
| 🌐 UI | Blazor WASM + Radzen + React/TS/Tailwind for interactive chat/vision panels |

---

## 🚀 Tech Stack

- **Frontend**: Blazor WebAssembly (hosted), Radzen UI, React + TypeScript + Tailwind
- **Backend**: ASP.NET Core API, gRPC, Azure Functions, Azure Service Bus
- **AI/NLP**: Sentence Transformers (compiled locally)
- **Face Recognition**: OpenCV/Dlib (local execution, no cloud)
- **Infra**: Docker Compose, GitHub Actions CI/CD
- **Observability**: Polly, Application Insights, PerfView, dotnet-trace

---

## 🛠️ Status

✅ Designed  
🚧 In development  
📌 Focused on modularity, extensibility, and integration best practices

---

## 📎 Why This Project?

I built this to demonstrate my capability with:
- Multi-service architecture using clean separation of concerns
- Cloud-native messaging and function processing
- AI integration without relying on paid APIs
- Profiling, testing, and resilience techniques

It also represents my passion for smart, scalable systems — and I’ll continue evolving it as I learn.

---

## 🙌 Want to Collaborate?

Open to ideas, feedback, and contributions — especially around:
- Self-hosted AI models in .NET
- gRPC patterns with Blazor clients
- Facial ID optimization

---

## License
This project is licensed under the [MIT License](LICENSE).