## 🧠 Aula: Arquiteturas Assíncronas e Event-Driven

📅 **Data**: 21/07/2025
⏱️ **Duração**: 2 horas
🎯 **Público-alvo**: Desenvolvedores, arquitetos de software, estudantes avançados
📌 **Objetivo**: Entender os conceitos, padrões e práticas de arquiteturas baseadas em eventos e assíncronas, com foco em escalabilidade e resiliência.

---

## 📋 Estrutura da Aula

### 1. Abertura e Contextualização (10 min)

**Objetivo:** Situar os alunos no tema da aula e motivar o aprendizado.
**Conteúdo:**

* Diferença entre arquiteturas síncronas e assíncronas
* Cenários onde arquiteturas event-driven são ideais (ex: e-commerce, IoT, microserviços)

**Atividade:**

* Pergunta disparadora: "Você já trabalhou com sistemas onde a comunicação entre serviços era feita via mensagens ou eventos? Como foi a experiência?"

---

### 2. Event-Driven Architecture (30 min)

**Objetivo:** Entender os componentes principais e as formas de modelar uma arquitetura orientada a eventos.
**Conteúdo:**

* O que é EDA (Event-Driven Architecture)
* Componentes: Producers, Consumers, Event Bus/Broker, Event Store
* Tipos de eventos: Evento de fato, comando, evento de integração
* Modelos de comunicação: Pub/Sub, Event Sourcing, CQRS

**Exemplo prático:**

* Diagrama de um sistema de pedidos com produtor (serviço de pedidos), consumidor (serviço de estoque), e broker (Kafka ou RabbitMQ)

**Atividade:**

* Em grupos, desenhar uma arquitetura simples de EDA com base em um caso dado (ex: sistema de reservas de voos)

---

### 3. Patterns para Sistemas Distribuídos (30 min)

**Objetivo:** Explorar padrões arquiteturais que ajudam a lidar com sistemas distribuídos e assíncronos.
**Conteúdo:**

* Message Broker (ex: Kafka, RabbitMQ, SQS)
* Message Queue vs Event Stream
* Retry, Dead Letter Queue (DLQ)
* Idempotência
* Saga Pattern (orquestração vs coreografia)
* Circuit Breaker e Bulkhead
* Eventual Consistency

**Demonstração rápida (opcional):**

* Exemplo de fluxo Saga com 3 microserviços usando coreografia

**Atividade:**

* Debate orientado: "Quando faz mais sentido usar orquestração e quando usar coreografia?"

---

### 4. Escalabilidade e Resiliência (30 min)

**Objetivo:** Analisar como arquiteturas assíncronas contribuem para a escalabilidade e resiliência dos sistemas.
**Conteúdo:**

* Horizontal scalability e desacoplamento
* Backpressure e gerenciamento de fila
* Auto-scaling com base em consumo de mensagens
* Failover e tolerância a falhas
* Observabilidade: tracing distribuído e logs centralizados

**Estudo de caso:**

* Como o Netflix usa EDA para escalar e se manter resiliente (breve explicação ou vídeo curto)

**Atividade:**

* Desafio relâmpago: "Quais estratégias você adotaria para garantir resiliência num sistema bancário orientado a eventos?"

---

### 5. Encerramento e Discussão (20 min)

**Objetivo:** Fixar os conceitos, tirar dúvidas e encorajar aprofundamento.
**Atividades:**

* Quiz rápido (Kahoot ou similar) com perguntas sobre os tópicos abordados
* Espaço para perguntas
* Sugestão de leitura e ferramentas:

  * Kafka, RabbitMQ, NATS
  * “Designing Event-Driven Systems” - Ben Stopford
  * "The Art of Scalability"
  * "Microservices Patterns" - Chris Richardson

---

## 🧰 Recursos e Materiais Sugeridos

* Slides com diagramas e fluxos de eventos
* Ferramentas: draw\.io ou Miro para desenhos em grupo
* Ambiente com docker-compose para Kafka ou RabbitMQ, se quiser demo prática
* Link para Playground online de sistemas de filas/eventos (como [Confluent Cloud demos](https://developer.confluent.io/))

---


Perfeito! Vamos ajustar os exemplos e atividades da sua aula de 2h sobre **Arquiteturas Assíncronas e Event-Driven** para o **contexto de uma seguradora**, que é um ótimo cenário para esse tipo de arquitetura (processos longos, múltiplos serviços, orquestrações, integração com terceiros, etc.).

---

## 📋 Estrutura da Aula (Adaptada para Seguradora)

### 1. Abertura e Contextualização (10 min)

**Contexto:**
Introduza os desafios de sistemas de seguros:

* Processos assíncronos por natureza (cotação, emissão, sinistro, análise de risco, antifraude, etc.)
* Integração com legados e terceiros (SUSEP, Detran, Corretores, Assinatura Digital)

**Pergunta disparadora:**
*"Quais etapas de um processo de seguro (auto, saúde, residencial) você acredita que poderiam ser executadas de forma assíncrona ou por eventos?"*

---

### 2. Event-Driven Architecture (30 min)

**Exemplo aplicado:**
📦 *Processo de cotação e emissão de apólice de seguro auto*

* Produtor: Portal Web → envia pedido de cotação
* Broker: Kafka (cotação.request)
* Consumidores:

  * Módulo de cálculo de prêmio
  * Módulo de análise de perfil
  * Módulo de antifraude
* Event Bus publica `cotacao.gerada` → dispara outros consumidores (ex: envio de proposta para cliente)

**Atividade em grupo:**
🛠️ *Desenhar arquitetura orientada a eventos para a emissão de um seguro de vida ou residencial*, com:

* Eventos relevantes (ex: `proposta.recebida`, `validacao.sucesso`, `assinatura.finalizada`)
* Serviços consumidores e produtores

---

### 3. Patterns para Sistemas Distribuídos (30 min)

**Aplicações típicas na seguradora:**

* **Message Broker:** Kafka entre módulos (ex: antifraude, precificação, assinatura)
* **Idempotência:** Evitar múltiplas análises de risco em duplicidade
* **Retry & DLQ:** Integração com Detran pode falhar, mas reprocessar mais tarde
* **Saga Pattern:**

  * *Exemplo:* Cancelamento de apólice

    * Passo 1: Registrar cancelamento
    * Passo 2: Notificar contabilidade
    * Passo 3: Estornar comissão do corretor
    * Usar coreografia: cada etapa escuta um evento anterior

**Atividade:**
⚖️ *Debate orientado:* "Se um cliente inicia uma proposta de seguro, mas não conclui a assinatura digital, como lidamos com esse processo assíncrono? Usamos orquestração ou coreografia?"

---

### 4. Escalabilidade e Resiliência (30 min)

**Exemplos aplicados à seguradora:**

* **Escalabilidade:**

  * Fluxos como *campanhas de cotação em massa* podem sobrecarregar serviços → usar filas/eventos com auto-scaling
* **Resiliência:**

  * Se o sistema de assinatura digital ficar offline, eventos ficam na fila (retentiva) e são processados quando o serviço volta
  * Retry + DLQ para envio de SMS ou email
* **Observabilidade:**

  * Correlacionar evento `sinistro.avisado` com `vistoria.concluida` e `indenizacao.paga` via tracing

**Estudo de caso sugerido:**
🧪 *"Como uma seguradora pode usar arquitetura event-driven para processar sinistros de forma escalável e resiliente?"*

---

### 5. Encerramento e Discussão (20 min)

**Quiz e Discussão:**

* "Qual o papel de um broker em uma arquitetura orientada a eventos?"
* "Quando um fluxo assíncrono pode prejudicar a experiência do usuário?"
* "Qual a diferença entre evento de fato e comando?"

**Indicações específicas para Seguradoras:**

* “Enterprise Integration Patterns” – Gregor Hohpe
* “Event-Driven Microservices” – Chris Richardson
* Ferramentas:

  * Kafka + Kafka Streams
  * AWS SNS/SQS (para integração com serviços legados)
  * Temporal (para workflows de sinistro ou emissão)

---
