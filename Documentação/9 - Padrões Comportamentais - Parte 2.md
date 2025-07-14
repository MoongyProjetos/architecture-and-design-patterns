# 🧑‍🏫 Aula 9 – Padrões Comportamentais (Parte 2)

📅 Data: 09/07/2025
⏱ Duração: 2h

🎯 **Objetivo:** Compreender e aplicar os padrões comportamentais:

* **Chain of Responsibility**
* **State**
* **Visitor**
* **Interpreter**
  No contexto de **sistemas de seguradora**.

---

## 🗂️ Estrutura da Aula

| Etapa                   | Tempo | Atividade                                              |
| ----------------------- | ----- | ------------------------------------------------------ |
| Abertura                | 10min | Recapitulação da Aula 8 + Introdução aos novos padrões |
| Chain of Responsibility | 25min | Conceito + Exemplo + Exercício em pares                |
| State                   | 25min | Conceito + Exemplo + Exercício orientado               |
| Intervalo               | 5min  | Pausa rápida                                           |
| Visitor                 | 25min | Conceito + Exemplo + Atividade guiada + Discussão      |
| Interpreter             | 20min | Conceito + Exemplo + Mini-desafio em grupos            |
| Encerramento            | 10min | Resumo + Dicas + Orientações para próxima aula         |

---

## 🔄 Chain of Responsibility, State, Visitor e Interpreter

**(Padrões Comportamentais – Parte 2)**

### 🧠 O que são padrões comportamentais?

Padrões comportamentais lidam com **a comunicação entre objetos**, determinando **quem faz o quê, quando e como**, de forma **flexível e desacoplada**.
Eles são fundamentais para evitar código rígido e fortemente dependente, favorecendo manutenção e extensibilidade.

---

### 📌 Quando aplicar padrões comportamentais?

Você deve considerar aplicar **Chain of Responsibility**, **State**, **Visitor** ou **Interpreter** quando:

1. 🧭 **Quer distribuir responsabilidades entre vários objetos sem acoplamento direto**
   → Use **Chain of Responsibility** quando múltiplos objetos podem tratar uma mesma solicitação.

2. 🔄 **Deseja que objetos mudem seu comportamento dependendo de seu estado interno**
   → Use **State** quando o objeto precisa se comportar de formas diferentes em diferentes "modos".

3. 🧳 **Quer adicionar operações a objetos sem modificar suas classes**
   → Use **Visitor** para aplicar operações variadas a objetos complexos sem tocar na estrutura deles.

4. 🧮 **Precisa interpretar regras ou linguagens específicas (DSLs)**
   → Use **Interpreter** para montar interpretadores simples com gramática própria.

---

## 🧪 Visão Geral Aplicada ao Domínio de uma Seguradora

| Padrão                         | Aplicação prática no sistema de uma seguradora                                                                                   |
| ------------------------------ | -------------------------------------------------------------------------------------------------------------------------------- |
| 🔗 **Chain of Responsibility** | Aprovação escalonada de sinistros: Atendente → Analista → Gerente, onde cada um trata o que está sob sua alçada.                 |
| 🔄 **State**                   | Estados de uma apólice: Em Análise, Emitida, Cancelada, Expirada — o comportamento muda conforme o status atual.                 |
| 🧭 **Visitor**                 | Relatórios ou exportações para diferentes tipos de seguro (auto, vida, residencial), sem alterar as classes dos seguros.         |
| 🧮 **Interpreter**             | Regras de aceitação de propostas personalizadas como: `"idade > 25 AND temSeguroAnterior = true"` — interpretadas dinamicamente. |

---

## 🛠️ Breve visão técnica dos padrões de hoje

| Padrão                     | Propósito                                                               | Benefício chave                           |
| -------------------------- | ----------------------------------------------------------------------- | ----------------------------------------- |
| 🔗 Chain of Responsibility | Passa uma solicitação por uma cadeia de objetos até que algum a trate   | Desacoplamento entre remetente e receptor |
| 🔄 State                   | Altera o comportamento de um objeto com base em seu estado              | Elimina estruturas condicionais complexas |
| 🧭 Visitor                 | Permite adicionar operações sem mudar as classes dos objetos            | Mantém a lógica separada das estruturas   |
| 🧮 Interpreter             | Define uma gramática e avalia expressões baseadas em regras específicas | Permite criar linguagens e DSLs simples   |

---

## 💡 Quando aplicar cada um

### 🔗 **Chain of Responsibility**

**Quando?**

* Quando múltiplos objetos podem lidar com uma requisição, e você quer que a requisição passe por eles até alguém tratá-la.

**Na seguradora:**

* Sinistros com valores diferentes são aprovados por diferentes níveis: atendente, analista, gerente.

---

### 🔄 **State**

**Quando?**

* Quando o comportamento de um objeto depende do seu estado, e você quer evitar `if-else` ou `switch-case` complexos.

**Na seguradora:**

* Apólices mudam de estado e isso afeta o que pode ou não ser feito com elas (ex: só pode pagar se estiver emitida).

---

### 🧭 **Visitor**

**Quando?**

* Quando há uma hierarquia de objetos e você precisa realizar diferentes operações sobre eles sem alterar suas classes.

**Na seguradora:**

* Relatórios distintos para seguros diferentes (ex: seguro de carro, seguro de vida), usando um visitante para gerar o conteúdo.

---

### 🧮 **Interpreter**

**Quando?**

* Quando você precisa interpretar expressões ou linguagens específicas, especialmente regras de negócio configuráveis.

**Na seguradora:**

* Regras definidas por analistas para aceitação de propostas, como `"idade > 30 AND temSeguro = true"`, são interpretadas dinamicamente.

---

## ✅ Resumo final

| Padrão                     | Use quando...                                                                              |
| -------------------------- | ------------------------------------------------------------------------------------------ |
| 🔗 Chain of Responsibility | Vários objetos podem tentar tratar a mesma solicitação                                     |
| 🔄 State                   | Um objeto deve mudar de comportamento baseado em seu estado interno                        |
| 🧭 Visitor                 | Você quer aplicar novas operações a uma estrutura de objetos complexa sem alterá-los       |
| 🧮 Interpreter             | Você precisa interpretar regras ou expressões customizadas (ex: DSLs) em tempo de execução |

---

## 🏢 Domínio: Sistema de uma Seguradora

Trabalharemos com exemplos reais como:

* Processamento de **sinistros**
* Avaliação de **riscos**
* **Emissão de apólices**
* **Geração de relatórios** de seguros

---

## 🔗 Chain of Responsibility – Aprovação de Sinistro

🎯 *Permite que uma solicitação percorra uma cadeia de manipuladores até que alguém a trate.*

**Exemplo na seguradora:**
Sinistros de valores diferentes são tratados por Atendente, Analista ou Gerente.

### 💡 Diagrama Mermaid

```mermaid
classDiagram
class Sinistro {
  -Descricao : string
  -Valor : decimal
}
class Aprovador {
  +DefinirProximo(Aprovador)
  +Aprovar(Sinistro)
}
Aprovador <|-- Atendente
Aprovador <|-- Analista
Aprovador <|-- Gerente
```

### 💻 Código

```csharp
public class Sinistro {
    public string Descricao { get; set; }
    public decimal Valor { get; set; }
}
abstract class Aprovador {
    protected Aprovador Proximo;
    public void DefinirProximo(Aprovador proximo) => Proximo = proximo;
    public abstract void Aprovar(Sinistro sinistro);
}
class Atendente : Aprovador {
    public override void Aprovar(Sinistro s) {
        if (s.Valor < 5000) Console.WriteLine("Atendente aprovou");
        else Proximo?.Aprovar(s);
    }
}
```


### Exemplo completo

```csharp
using System;

public class Sinistro {
    public string Descricao { get; set; }
    public decimal Valor { get; set; }

    public Sinistro(string descricao, decimal valor) {
        Descricao = descricao;
        Valor = valor;
    }
}

// Classe base
abstract class Aprovador {
    protected Aprovador Proximo;
    public void DefinirProximo(Aprovador proximo) => Proximo = proximo;
    public abstract void Aprovar(Sinistro sinistro);
}

// Nível 1
class Atendente : Aprovador {
    public override void Aprovar(Sinistro s) {
        if (s.Valor < 5000)
            Console.WriteLine($"Atendente aprovou o sinistro: {s.Descricao} (Valor: {s.Valor:C})");
        else
            Proximo?.Aprovar(s);
    }
}

// Nível 2
class Gerente : Aprovador {
    public override void Aprovar(Sinistro s) {
        if (s.Valor < 15000)
            Console.WriteLine($"Gerente aprovou o sinistro: {s.Descricao} (Valor: {s.Valor:C})");
        else
            Proximo?.Aprovar(s);
    }
}

// Nível 3
class Diretor : Aprovador {
    public override void Aprovar(Sinistro s) {
        if (s.Valor < 150000)
            Console.WriteLine($"Diretor aprovou o sinistro: {s.Descricao} (Valor: {s.Valor:C})");
        else
            Console.WriteLine($"Sinistro de valor muito alto! Escalar para conselho: {s.Descricao} (Valor: {s.Valor:C})");
    }
}

// Programa de teste
class Program {
    static void Main(string[] args) {
        // Montando a cadeia de responsabilidade
        var atendente = new Atendente();
        var gerente = new Gerente();
        var diretor = new Diretor();

        atendente.DefinirProximo(gerente);
        gerente.DefinirProximo(diretor);

        // Casos de teste
        var sinistro1 = new Sinistro("Retrovisor quebrado", 1200);
        var sinistro2 = new Sinistro("Batida leve", 10000);
        var sinistro3 = new Sinistro("Perda total", 50000);
        var sinistro4 = new Sinistro("Incêndio total da frota", 500000);

        atendente.Aprovar(sinistro1);
        atendente.Aprovar(sinistro2);
        atendente.Aprovar(sinistro3);
        atendente.Aprovar(sinistro4);
    }
}
```

---

## 🔄 State – Ciclo de Vida da Apólice

🎯 *Permite que um objeto altere seu comportamento de acordo com seu estado interno.*

**Exemplo na seguradora:**
Uma apólice pode estar `Emitida`, `Cancelada`, `Expirada`, etc.

### 💡 Diagrama Mermaid

```mermaid
classDiagram
class Apolice {
  +DefinirEstado(IEstadoApolice)
  +Processar()
}
class IEstadoApolice {
  <<interface>>
  +Processar()
}
IEstadoApolice <|-- Emitida
IEstadoApolice <|-- Cancelada
```

### 💻 Código

```csharp
public interface IEstadoApolice {
    void Processar();
}
public class Emitida : IEstadoApolice {
    public void Processar() => Console.WriteLine("Apólice pode ser paga.");
}
public class Apolice {
    private IEstadoApolice _estado;
    public void DefinirEstado(IEstadoApolice estado) => _estado = estado;
    public void Processar() => _estado.Processar();
}
```

### Exemplo completo

```csharp
using System;

public interface IEstadoApolice {
    void Processar();
}

public class Emitida : IEstadoApolice {
    public void Processar() => Console.WriteLine("🔵 A apólice está EMITIDA e pode ser paga.");
}

public class Cancelada : IEstadoApolice {
    public void Processar() => Console.WriteLine("❌ A apólice está CANCELADA. Nenhuma ação permitida.");
}

public class EmAnalise : IEstadoApolice {
    public void Processar() => Console.WriteLine("🟡 A apólice está EM ANÁLISE. Aguardando validação.");
}

public class Expirada : IEstadoApolice {
    public void Processar() => Console.WriteLine("⚪ A apólice está EXPIRADA. Precisa ser renovada.");
}

public class Apolice {
    private IEstadoApolice _estado;

    public void DefinirEstado(IEstadoApolice estado) {
        _estado = estado;
        Console.WriteLine($"[Estado atualizado: {estado.GetType().Name}]");
    }

    public void Processar() {
        if (_estado == null)
            Console.WriteLine("⚠️ Nenhum estado definido para a apólice.");
        else
            _estado.Processar();
    }
}

class Program {
    static void Main(string[] args) {
        var apolice = new Apolice();

        // Apólice ainda sem estado
        apolice.Processar();

        // Estado: Em análise
        apolice.DefinirEstado(new EmAnalise());
        apolice.Processar();

        // Estado: Emitida
        apolice.DefinirEstado(new Emitida());
        apolice.Processar();

        // Estado: Cancelada
        apolice.DefinirEstado(new Cancelada());
        apolice.Processar();

        // Estado: Expirada
        apolice.DefinirEstado(new Expirada());
        apolice.Processar();
    }
}
```

---

## 🧭 Visitor – Relatórios de Seguros

🎯 *Permite adicionar novas operações a objetos sem alterar suas classes.*

**Exemplo na seguradora:**
Gerar relatórios distintos para tipos de seguro (Auto, Vida, etc).

### 💡 Diagrama Mermaid

```mermaid
classDiagram
class ISeguro {
  <<interface>>
  +Aceitar(IVisitor)
}
class SeguroAuto {
  +Aceitar(IVisitor)
  +Modelo : string
}
class SeguroVida {
  +Aceitar(IVisitor)
  +Beneficiario : string
}
class IVisitor {
  <<interface>>
  +Visitar(SeguroAuto)
  +Visitar(SeguroVida)
}
class RelatorioSimples {
  +Visitar(SeguroAuto)
  +Visitar(SeguroVida)
}
ISeguro <|-- SeguroAuto
ISeguro <|-- SeguroVida
IVisitor <|-- RelatorioSimples
```

### 💻 Código

```csharp
public interface ISeguro {
    void Aceitar(IVisitor visitor);
}
public class SeguroAuto : ISeguro {
    public string Modelo { get; set; } = "Sedan";
    public void Aceitar(IVisitor visitor) => visitor.Visitar(this);
}
public class RelatorioSimples : IVisitor {
    public void Visitar(SeguroAuto s) => Console.WriteLine($"Relatório: {s.Modelo}");
}
```

### Exemplo completo

```csharp
using System;

// Interface para os elementos que aceitam visitantes
public interface ISeguro {
    void Aceitar(IVisitor visitor);
}

// Seguro de automóvel
public class SeguroAuto : ISeguro {
    public string Modelo { get; set; } = "Sedan";
    public void Aceitar(IVisitor visitor) => visitor.Visitar(this);
}

// Seguro de vida (opcional — para mostrar múltiplos elementos)
public class SeguroVida : ISeguro {
    public string Beneficiario { get; set; } = "João";
    public void Aceitar(IVisitor visitor) => visitor.Visitar(this);
}

// Interface do visitante
public interface IVisitor {
    void Visitar(SeguroAuto seguro);
    void Visitar(SeguroVida seguro);
}

// Um visitante que gera relatórios simples
public class RelatorioSimples : IVisitor {
    public void Visitar(SeguroAuto s) =>
        Console.WriteLine($"🚗 Relatório do Seguro Auto: Modelo = {s.Modelo}");

    public void Visitar(SeguroVida s) =>
        Console.WriteLine($"🧬 Relatório do Seguro Vida: Beneficiário = {s.Beneficiario}");
}

// Programa principal para teste
class Program {
    static void Main(string[] args) {
        // Instanciando seguros
        ISeguro seguroAuto = new SeguroAuto { Modelo = "SUV" };
        ISeguro seguroVida = new SeguroVida { Beneficiario = "Maria" };

        // Criando o visitante
        IVisitor relatorio = new RelatorioSimples();

        // Aplicando o visitante
        seguroAuto.Aceitar(relatorio);
        seguroVida.Aceitar(relatorio);
    }
}

```

---

## 🧮 Interpreter – Regras de Aceitação

🎯 *Define uma linguagem e um interpretador para expressões específicas.*

**Exemplo na seguradora:**
Regras como: `idade > 25 AND temSeguroAnterior = true`

### 💡 Diagrama Mermaid

```mermaid
classDiagram
class Contexto {
  +Idade : int
  +TemSeguroAnterior : bool
}
class IExpressao {
  <<interface>>
  +Interpretar(Contexto)
}
class IdadeMaiorQue25
class PossuiSeguroAnterior
class E
IExpressao <|-- IdadeMaiorQue25
IExpressao <|-- PossuiSeguroAnterior
IExpressao <|-- E
```

### 💻 Código

```csharp
public interface IExpressao {
    bool Interpretar(Contexto contexto);
}
public class E : IExpressao {
    private IExpressao _esq, _dir;
    public E(IExpressao e1, IExpressao e2) { _esq = e1; _dir = e2; }
    public bool Interpretar(Contexto c) => _esq.Interpretar(c) && _dir.Interpretar(c);
}
```

### Exemplo completo

```csharp
using System;

// Contexto com os dados de entrada da regra
public class Contexto {
    public int Idade { get; set; }
    public bool TemSeguroAnterior { get; set; }
}

// Interface de expressão
public interface IExpressao {
    bool Interpretar(Contexto contexto);
}

// Expressão: idade > 25
public class IdadeMaiorQue25 : IExpressao {
    public bool Interpretar(Contexto contexto) => contexto.Idade > 25;
}

// Expressão: possui seguro anterior
public class PossuiSeguroAnterior : IExpressao {
    public bool Interpretar(Contexto contexto) => contexto.TemSeguroAnterior;
}

// Expressão composta: E lógico
public class E : IExpressao {
    private readonly IExpressao _esq, _dir;
    public E(IExpressao esquerda, IExpressao direita) {
        _esq = esquerda;
        _dir = direita;
    }

    public bool Interpretar(Contexto contexto) =>
        _esq.Interpretar(contexto) && _dir.Interpretar(contexto);
}

// Programa principal de teste
class Program {
    static void Main(string[] args) {
        // Criar a expressão: idade > 25 AND tem seguro anterior
        IExpressao regra = new E(new IdadeMaiorQue25(), new PossuiSeguroAnterior());

        // Teste 1
        var cliente1 = new Contexto { Idade = 30, TemSeguroAnterior = true };
        Console.WriteLine("Cliente 1 aprovado? " + regra.Interpretar(cliente1)); // true

        // Teste 2
        var cliente2 = new Contexto { Idade = 22, TemSeguroAnterior = true };
        Console.WriteLine("Cliente 2 aprovado? " + regra.Interpretar(cliente2)); // false

        // Teste 3
        var cliente3 = new Contexto { Idade = 28, TemSeguroAnterior = false };
        Console.WriteLine("Cliente 3 aprovado? " + regra.Interpretar(cliente3)); // false
    }
}
```

---

## ✅ Resumo Visual

| Padrão                     | Aplicação na Seguradora                                             |
| -------------------------- | ------------------------------------------------------------------- |
| 🔗 Chain of Responsibility | Aprovação escalonada de sinistros (atendente → analista → gerente)  |
| 🔄 State                   | Comportamento de apólice conforme estado (emitida, cancelada, etc.) |
| 🧭 Visitor                 | Geração de relatórios para tipos diferentes de seguro               |
| 🧮 Interpreter             | Regras configuráveis de aceitação de proposta                       |

---

## 📚 Dica para Próxima Aula

📝 **Exercício sugerido:** Escolha um padrão apresentado e implemente no seu próprio projeto.

📘 **Leitura recomendada:**

* *Design Patterns – GoF*
* Refactoring.guru
