## ✅ **Análise do `renamer.ps1`**

### 📜 **Código original**

```powershell
$Root = Get-Location

Get-ChildItem -Recurse -Directory, File | 
Sort-Object FullName -Descending | 
ForEach-Object {
    if ($_.Name -like "AccountEventsParser.*") {
        $newName = $_.Name -replace "^AccountEventsParser\.", "PartyEventsParser."
        Rename-Item -Path $_.FullName -NewName $newName
    }
}
```

---

## 🧠 **Explicação por partes**

### 🔹 `$Root = Get-Location`

* Armazena o diretório atual na variável `$Root`, mas **não está sendo usado** no restante do script.

> Pode ser removido se não houver planos de uso futuro.

---

### 🔹 `Get-ChildItem -Recurse -Directory, File`

* Lista **todos os arquivos e pastas** recursivamente a partir do diretório atual.

---

### 🔹 `Sort-Object FullName -Descending`

* Ordena os itens **do mais profundo para o mais superficial**.
* Isso evita erros ao renomear pastas antes de seus conteúdos.

---

### 🔹 `ForEach-Object { ... }`

* Para cada item listado:

  * Verifica se o nome **começa com `AccountEventsParser.`**.
  * Se sim, **substitui por `PartyEventsParser.`** no início do nome.
  * Aplica a renomeação via `Rename-Item`.

```powershell
if ($_.Name -like "AccountEventsParser.*") {
    $newName = $_.Name -replace "^AccountEventsParser\.", "PartyEventsParser."
    Rename-Item -Path $_.FullName -NewName $newName
}
```

---

## 🛡️ **Segurança e boas práticas**

| Boa prática              | Situação atual                 |
| ------------------------ | ------------------------------ |
| Backup antes de renomear | ❌ Não implementado             |
| Simulação com `-WhatIf`  | ❌ Não usado                    |
| Uso de logs              | ❌ Não há log de mudanças       |
| Tratamento de erro       | ❌ Não há try/catch             |
| Reversão                 | ❌ Não há mecanismo de rollback |

---

## 🛠️ **Sugestão de versão segura**

```powershell
Get-ChildItem -Recurse -Directory, File |
Sort-Object FullName -Descending |
ForEach-Object {
    if ($_.Name -like "AccountEventsParser.*") {
        $newName = $_.Name -replace "^AccountEventsParser\.", "PartyEventsParser."
        Write-Host "Renomeando '$($_.FullName)' para '$newName'" -ForegroundColor Cyan
        Rename-Item -Path $_.FullName -NewName $newName -WhatIf  # Remova -WhatIf para aplicar
    }
}
```

* `-WhatIf` impede que as renomeações aconteçam de fato (simulação).
* `Write-Host` mostra claramente o que seria feito.

---

## 🧾 **Resumo da função do script**

| Ação                        | Resultado                                     |
| --------------------------- | --------------------------------------------- |
| Renomeia pastas e arquivos  | ✅ Que começam com `AccountEventsParser.`      |
| Faz de forma recursiva      | ✅ Inclui subdiretórios                        |
| Evita conflitos ao renomear | ✅ Ordenando por profundidade                  |
| Substituição aplicada       | `AccountEventsParser.* → PartyEventsParser.*` |

