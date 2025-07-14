### 🧑‍🏫 **Plano de Aula – Sessão 9: Padrões Comportamentais (Parte 2)**

📅 Data: 09/07/2025
⏱ Duração: 2 horas
🎯 **Objetivo Geral:** Apresentar e aplicar os padrões comportamentais **Chain of Responsibility**, **State**, **Visitor** e **Interpreter**, destacando seus usos e diferenças.

---

## 🔸 Estrutura da Aula

### **1. Abertura (10 min)**

* 📌 **Recapitulação rápida da Sessão 8** (Observer, Strategy, Template Method, Command, Mediator)
* 🧠 **Conexão com os novos padrões:**
  *“Hoje veremos padrões que tratam de fluxos de decisão, mudanças de comportamento em tempo de execução, adição de responsabilidades sem modificar a estrutura da classe.”*

---

### **2. Chain of Responsibility (25 min)**

📖 **Definição:** Permite passar uma solicitação por uma cadeia de manipuladores até que algum a trate.

🧩 **Exemplo real:** Suporte técnico: usuário → atendente nível 1 → nível 2 → especialista.

🧪 **Código em C# (simplificado):**

```csharp
abstract class Handler {
    protected Handler next;
    public void SetNext(Handler next) => this.next = next;
    public abstract void Handle(string request);
}

class SuporteNivel1 : Handler {
    public override void Handle(string request) {
        if (request == "senha") Console.WriteLine("Nível 1 resolve.");
        else next?.Handle(request);
    }
}
```

🎯 **Exercício rápido (em pares):**

* Criar uma cadeia com 3 níveis de suporte e tratar as palavras: `"senha"`, `"rede"`, `"servidor"`.

---

### **3. State (25 min)**

📖 **Definição:** Permite que um objeto altere seu comportamento quando seu estado interno muda.

🧩 **Exemplo real:** Impressora (pronta, imprimindo, sem papel).

🧪 **Código em C#:**

```csharp
interface IEstado {
    void Acao();
}

class EstadoLigado : IEstado {
    public void Acao() => Console.WriteLine("Luz está ligada.");
}

class Luz {
    private IEstado estado;
    public void SetEstado(IEstado novoEstado) => estado = novoEstado;
    public void Executar() => estado.Acao();
}
```

🎯 **Exercício orientado:**

* Modelar um semáforo com os estados: Verde, Amarelo, Vermelho.

---

### **4. Intervalo (5 min)**

---

### **5. Visitor (25 min)**

📖 **Definição:** Permite adicionar operações a objetos sem alterar suas classes.

🧩 **Exemplo real:** Impressão de diferentes documentos (PDF, Word, Excel), com operações diferentes (imprimir, exportar, etc.)

🧪 **Código em C#:**

```csharp
interface IVisitor {
    void Visit(DocumentoPDF doc);
}

interface IElemento {
    void Accept(IVisitor visitor);
}

class DocumentoPDF : IElemento {
    public void Accept(IVisitor visitor) => visitor.Visit(this);
}
```

🎯 **Atividade guiada:**

* Criar 2 elementos (PDF e Word) e um visitante que imprime o tipo de cada um.

🗣️ **Discussão:** Quando usar Visitor em vez de herança?

---

### **6. Interpreter (20 min)**

📖 **Definição:** Usado para interpretar linguagens específicas (DSLs).

🧩 **Exemplo real:** Calculadora com expressões simples (ex: `1 + 2`).

🧪 **Código simples em C#:**

```csharp
interface IExpressao {
    int Interpretar();
}

class Numero : IExpressao {
    private int valor;
    public Numero(int valor) => this.valor = valor;
    public int Interpretar() => valor;
}

class Soma : IExpressao {
    private IExpressao esquerda, direita;
    public Soma(IExpressao e, IExpressao d) { esquerda = e; direita = d; }
    public int Interpretar() => esquerda.Interpretar() + direita.Interpretar();
}
```

🎯 **Mini-desafio (em grupos):**

* Implementar subtração ou multiplicação com o mesmo padrão.

---

### **7. Encerramento e Discussão (10 min)**

✅ **Resumo rápido:**

| Padrão                  | Aplicação típica                           |
| ----------------------- | ------------------------------------------ |
| Chain of Responsibility | Encaminhamento de requisições              |
| State                   | Mudança de comportamento baseada em estado |
| Visitor                 | Novas operações sem alterar estruturas     |
| Interpreter             | Construção de DSLs ou interpretadores      |

📝 **Dica de estudo:** Implementar 1 padrão em um projeto próprio e trazer na próxima aula.

📚 **Indicação extra:**

* *Design Patterns: Elements of Reusable Object-Oriented Software* (GoF)
* Refactoring.Guru – ótimos diagramas e exemplos interativos


 Vamos adaptar os **padrões comportamentais** para o **domínio de uma seguradora**, usando exemplos práticos e plausíveis do cotidiano desse setor.

---

## 🏢 **Caso de Uso: Sistema de uma Seguradora**

Vamos imaginar que estamos construindo o sistema de uma seguradora que lida com:

* Processamento de **sinistros**
* Avaliação de **risco**
* **Emissão de apólices**
* **Regulamentação** de diferentes tipos de seguro

---

## 🔗 **1. Chain of Responsibility — Fluxo de Aprovação de Sinistro**

**📌 Problema no domínio:** Um pedido de sinistro (ex: colisão de carro) pode precisar passar por diferentes níveis de validação (atendente → analista → gerente).

**✅ Aplicação:**

```plaintext
Solicitação de Sinistro
      ↓
Atendente verifica documentos
      ↓
Analista avalia cobertura e riscos
      ↓
Gerente aprova valores altos
```

**💡 Código em termos do domínio:**

```csharp
abstract class Aprovador {
    protected Aprovador proximo;
    public void SetProximo(Aprovador p) => proximo = p;
    public abstract void Aprovar(Sinistro sinistro);
}

class Atendente : Aprovador {
    public override void Aprovar(Sinistro sinistro) {
        if (sinistro.Valor < 5000) Console.WriteLine("Atendente aprovou.");
        else proximo?.Aprovar(sinistro);
    }
}
```

---

## 🔄 **2. State — Estado da Apólice de Seguro**

**📌 Problema no domínio:** Uma apólice de seguro pode estar em diferentes estados: **Em análise**, **Emitida**, **Cancelada**, **Expirada**.

**✅ Aplicação:** O comportamento da apólice muda conforme seu estado. Ex: só é possível pagar uma apólice se ela estiver **emitida**.

**💡 Código conceitual:**

```csharp
interface IEstadoApolice {
    void Processar(Apolice apolice);
}

class Emitida : IEstadoApolice {
    public void Processar(Apolice a) => Console.WriteLine("A apólice pode ser paga.");
}

class Cancelada : IEstadoApolice {
    public void Processar(Apolice a) => Console.WriteLine("A apólice está cancelada. Nenhuma ação permitida.");
}
```

---

## 🧭 **3. Visitor — Relatórios sobre Seguros Diversos**

**📌 Problema no domínio:** A seguradora possui vários tipos de seguros (auto, vida, residencial) e precisa gerar **relatórios**, **estatísticas**, ou **exportações** sem modificar as classes principais.

**✅ Aplicação:** Criamos visitantes para gerar relatórios diferentes sem alterar as classes de seguro.

**💡 Código conceitual:**

```csharp
interface ISeguro {
    void Aceitar(IVisitor visitor);
}

class SeguroAuto : ISeguro {
    public void Aceitar(IVisitor visitor) => visitor.Visitar(this);
}

interface IVisitor {
    void Visitar(SeguroAuto seguro);
    void Visitar(SeguroVida seguro);
}

class RelatorioPDF : IVisitor {
    public void Visitar(SeguroAuto s) => Console.WriteLine("Gerando relatório PDF para seguro auto.");
}
```

---

## 🧮 **4. Interpreter — Linguagem de Regras de Cobertura**

**📌 Problema no domínio:** A seguradora permite que analistas definam regras personalizadas como:

```
"idade > 25 AND temSeguroAnterior = true"
```

**✅ Aplicação:** Implementar uma mini-linguagem para interpretar regras de aceitação de seguro.

**💡 Código conceitual:**

```csharp
interface IExpressao {
    bool Interpretar(Contexto c);
}

class MaiorQue25 : IExpressao {
    public bool Interpretar(Contexto c) => c.Idade > 25;
}

class TemSeguroAnterior : IExpressao {
    public bool Interpretar(Contexto c) => c.TemSeguro;
}

class E : IExpressao {
    private IExpressao esq, dir;
    public E(IExpressao e1, IExpressao e2) { esq = e1; dir = e2; }
    public bool Interpretar(Contexto c) => esq.Interpretar(c) && dir.Interpretar(c);
}
```

---

## 📋 Resumo Visual Adaptado à Seguradora:

| Padrão                     | Exemplo na Seguradora                                              |
| -------------------------- | ------------------------------------------------------------------ |
| 🔗 Chain of Responsibility | Aprovação escalonada de sinistros (atendente → analista → gerente) |
| 🔄 State                   | Estados de uma apólice (emitida, cancelada, expirada)              |
| 🧭 Visitor                 | Relatórios ou exportações de dados de vários tipos de seguro       |
| 🧮 Interpreter             | Regras de aceitação configuráveis para clientes e propostas        |

---

✅ Aqui estão os **exercícios práticos em C#** aplicando os padrões comportamentais ao contexto de uma **seguradora**, já com o **diagrama em MermaidJS** incluso no final para visualização da arquitetura.

Você pode agora:

* Executar os exemplos em um projeto console C#
* Usar o diagrama com ferramentas como [Mermaid Live Editor](https://mermaid.live) para visualizar
* Solicitar variações ou exercícios adicionais (ex: com interface gráfica ou base de dados)

Deseja que eu monte um **PDF de apostila**, ou **slides para apresentação** com base nesses exemplos?


// Exercícios Práticos em C# – Padrões Comportamentais aplicados à Seguradora

// -----------------------------
// 1. Chain of Responsibility
// -----------------------------
// Situação: Aprovação de sinistro escalonada conforme o valor.

public class Sinistro {
    public string Descricao { get; set; }
    public decimal Valor { get; set; }
}

public abstract class Aprovador {
    protected Aprovador Proximo;
    public void DefinirProximo(Aprovador proximo) => Proximo = proximo;
    public abstract void Aprovar(Sinistro sinistro);
}

public class Atendente : Aprovador {
    public override void Aprovar(Sinistro sinistro) {
        if (sinistro.Valor < 5000)
            Console.WriteLine("Atendente aprovou o sinistro: " + sinistro.Descricao);
        else
            Proximo?.Aprovar(sinistro);
    }
}

public class Analista : Aprovador {
    public override void Aprovar(Sinistro sinistro) {
        if (sinistro.Valor < 20000)
            Console.WriteLine("Analista aprovou o sinistro: " + sinistro.Descricao);
        else
            Proximo?.Aprovar(sinistro);
    }
}

public class Gerente : Aprovador {
    public override void Aprovar(Sinistro sinistro) {
        Console.WriteLine("Gerente aprovou o sinistro de alto valor: " + sinistro.Descricao);
    }
}

// -----------------------------
// 2. State
// -----------------------------
// Situação: Apólice muda de comportamento conforme estado (Emitida, Cancelada)

public interface IEstadoApolice {
    void Processar();
}

public class Emitida : IEstadoApolice {
    public void Processar() => Console.WriteLine("A apólice está emitida e pronta para pagamento.");
}

public class Cancelada : IEstadoApolice {
    public void Processar() => Console.WriteLine("A apólice está cancelada. Não é possível operar.");
}

public class Apolice {
    private IEstadoApolice _estado;
    public void DefinirEstado(IEstadoApolice estado) => _estado = estado;
    public void Processar() => _estado.Processar();
}

// -----------------------------
// 3. Visitor
// -----------------------------
// Situação: Geração de relatórios diferentes para seguros

public interface ISeguro {
    void Aceitar(IVisitor visitor);
}

public class SeguroAuto : ISeguro {
    public string Modelo { get; set; } = "Sedan";
    public void Aceitar(IVisitor visitor) => visitor.Visitar(this);
}

public class SeguroVida : ISeguro {
    public string Beneficiario { get; set; } = "João";
    public void Aceitar(IVisitor visitor) => visitor.Visitar(this);
}

public interface IVisitor {
    void Visitar(SeguroAuto s);
    void Visitar(SeguroVida s);
}

public class RelatorioSimples : IVisitor {
    public void Visitar(SeguroAuto s) => Console.WriteLine($"Relatório Auto: Modelo {s.Modelo}");
    public void Visitar(SeguroVida s) => Console.WriteLine($"Relatório Vida: Beneficiário {s.Beneficiario}");
}

// -----------------------------
// 4. Interpreter
// -----------------------------
// Situação: Regras de aceitação de seguro

public class Contexto {
    public int Idade { get; set; }
    public bool TemSeguroAnterior { get; set; }
}

public interface IExpressao {
    bool Interpretar(Contexto contexto);
}

public class IdadeMaiorQue25 : IExpressao {
    public bool Interpretar(Contexto contexto) => contexto.Idade > 25;
}

public class PossuiSeguroAnterior : IExpressao {
    public bool Interpretar(Contexto contexto) => contexto.TemSeguroAnterior;
}

public class E : IExpressao {
    private readonly IExpressao _esquerda, _direita;
    public E(IExpressao esquerda, IExpressao direita) {
        _esquerda = esquerda;
        _direita = direita;
    }
    public bool Interpretar(Contexto contexto) => _esquerda.Interpretar(contexto) && _direita.Interpretar(contexto);
}

