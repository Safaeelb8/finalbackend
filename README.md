# TealHub Backend API

Built with ASP.NET Core .NET 10 · PostgreSQL · JWT Authentication

---

## Base URL

```
http://localhost:5212
```

---

## Authentication

All endpoints (except login) require a JWT token in the header:

```
Authorization: Bearer {your_token}
```

Get your token by calling the login endpoint first.

---

## Endpoints

### 🔑 Auth

#### Login
```
POST /api/auth/login
```
**Body:**
```json
{
  "email": "user@teal.com",
  "password": "yourpassword"
}
```
**Response:**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIs...",
  "fullName": "John Doe",
  "email": "user@teal.com",
  "role": "Admin"
}
```

#### Logout
```
POST /api/auth/logout
```

---

### 👥 Users (Admin only)

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/users` | Get all users |
| GET | `/api/users/{id}` | Get user by ID |
| POST | `/api/users` | Create user |
| PUT | `/api/users/{id}` | Update user |
| DELETE | `/api/users/{id}` | Delete user |
| PATCH | `/api/users/{id}/role` | Assign role |

**Create User Body:**
```json
{
  "fullName": "John Doe",
  "email": "john@teal.com",
  "password": "password123",
  "role": "Employee"
}
```

---

### 📄 Documents

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/documents` | Get all documents |
| GET | `/api/documents/{id}` | Get document by ID |
| GET | `/api/documents/search?keyword=` | Search documents |
| POST | `/api/documents` | Upload document |
| DELETE | `/api/documents/{id}` | Delete (Admin only) |

**Upload Document Body:**
```json
{
  "title": "HR Guide",
  "description": "Onboarding guide",
  "filePath": "/docs/hr-guide.pdf",
  "fileType": "pdf",
  "fileSize": 204800,
  "uploadedByUserId": "user-guid-here"
}
```

---

### 💬 Questions (Chatbot)

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/questions` | Submit a question |
| GET | `/api/questions/{id}` | Get question + response |
| GET | `/api/questions/history/{userId}` | Get user history |

**Submit Question Body:**
```json
{
  "content": "What is the leave policy?",
  "userId": "user-guid-here"
}
```

**Response:**
```json
{
  "id": "guid",
  "content": "What is the leave policy?",
  "askedAt": "2026-03-27T10:00:00Z",
  "userId": "user-guid-here",
  "responseContent": "The AI generated answer..."
}
```

---

### 📋 Logs (Admin only)

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/logs` | Get all logs |
| GET | `/api/logs/user/{userId}` | Get logs by user |
| GET | `/api/logs/export` | Export logs as CSV |

---

## Roles

| Role | Access |
|------|--------|
| `Admin` | Full access to everything |
| `Employee` | Questions, documents, own history |

---

## Error Responses

```json
{
  "message": "Invalid email or password"
}
```

| Status | Meaning |
|--------|---------|
| 200 | Success |
| 201 | Created |
| 401 | Not authenticated |
| 403 | Not authorized (wrong role) |
| 404 | Not found |
| 500 | Server error |

---

## Data Types

- All **IDs** are GUIDs: `"3fa85f64-5717-4562-b3fc-2c963f66afa6"`
- All **dates** are UTC: `"2026-03-27T10:00:00Z"`
- **Token expires** after 60 minutes

---

## Quick Test with Postman

1. `POST /api/auth/login` → copy the token
2. Add header `Authorization: Bearer {token}` to all other requests
3. Test any endpoint

---

## Swagger UI

Full interactive API documentation available at:
```
http://localhost:5212/swagger
```
