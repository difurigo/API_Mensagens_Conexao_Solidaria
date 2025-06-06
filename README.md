# 📡 API - Conexão Solidária (Mensagens de Emergência)

**Conexão Solidária** é uma plataforma de comunicação offline que utiliza redes mesh com Bluetooth Low Energy (BLE) para permitir a troca de mensagens em cenários de desastre, mesmo sem internet ou rede móvel.

Cada celular com o app instalado age como um nó na rede, retransmitindo mensagens entre dispositivos próximos até que uma conexão com a internet seja encontrada para sincronização com a central.  
Essa abordagem resiliente mantém a comunicação comunitária ativa mesmo sob blackout total.

---

## 🗂️ Estrutura de Entidades (Diagrama ER 1:N)

```
Usuario
-------
- Id (string) PK
- Nome (string)
- Email (string)

Mensagem
--------
- Id (GUID) PK
- UUID (string)
- Titulo (string)
- Conteudo (string)
- Prioridade (string)
- Localizacao (string)
- DataEnvio (DateTime)
- TTL (int)
- Status (string)
- UsuarioId (string) FK → Usuario.Id
```

---

## 🚀 Tecnologias Utilizadas

- ✅ ASP.NET Core 8.0
- ✅ Entity Framework Core 9 (com Migrations)
- ✅ Banco de Dados Oracle (Oracle.EntityFrameworkCore)
- ✅ Swagger (via Swashbuckle)
- ✅ Visual Studio 2022 ou Terminal com .NET SDK 9.0+

---

## 🛠 Como Executar o Projeto Localmente

### 1. Clonar o Repositório
```bash
git clone https://github.com/difurigo/API_Mensagens_Conexao_Solidaria.git
cd api_gs_mensagens_conexao_solidaria
```

### 2. Restaurar Dependências
```bash
dotnet restore
```

### 3. Aplicar as Migrations no Banco Oracle
> ⚠️ Certifique-se de que o `connection string` está correto no `appsettings.json`.

```bash
dotnet ef database update
```

### 4. Rodar a API
```bash
dotnet run
```

Após isso, acesse a documentação interativa:
```
http://localhost:<PORTA>/swagger
```

---

## 🧪 Endpoints e Exemplos

### 📌 Criar Usuário
**POST /api/Usuario**
```json
{
  "id": "1",
  "nome": "Maria da Silva",
  "email": "maria@email.com"
}
```

---

### 📨 Enviar Mensagem
**POST /api/Mensagem**
```json
{
  "titulo": "Alerta de enchente",
  "conteudo": "Nível do rio subiu rapidamente",
  "prioridade": "Alta",
  "localizacao": "Rua das Águas, 123",
  "ttl": 5,
  "status": "Pendente",
  "usuarioId": "1"
}
```

---

### 🔍 Listar Mensagens de um Usuário
**GET /api/Mensagem/usuario/{usuarioId}**

---

### ✏️ Atualizar Mensagem
**PUT /api/Mensagem/{uuid}**
```json
{
  "titulo": "Atualização",
  "conteudo": "Chuva intensa chegando",
  "prioridade": "Alta",
  "localizacao": "Rua Central, 999",
  "status": "Pendente",
  "usuarioId": "1"
}
```

---

### ❌ Remover Mensagem por UUID
**DELETE /api/Mensagem/{uuid}**

---

### ❌ Remover Todas as Mensagens de um Usuário
**DELETE /api/Mensagem/usuario/{usuarioId}**

---

## 🧾 Consulta Direta via Oracle SQL

```sql
SELECT * FROM MENSAGENS;
SELECT * FROM USUARIOS;
```

---

## 👨‍💻 Autores

- **Diego Furigo** – RM: 558755  
- **Melissa Pereira** – RM: 555656  
- **Lu Vieira** – RM: 558935  
