# Buggy Jobs Backend

This is the **backend API** for the Buggy Jobs Job Posting System. Built with **ASP.NET Core Web API**, it provides endpoints to manage job postings.

---

## Features

- **Get All Jobs**: Retrieve all job postings.
- **Add Job**: Create a new job with validation.
- **Delete Job**: Remove a job by ID.
- **Validation**:
  - Title is required.
  - Closing date must be in the future.
- **In-Memory Storage**: Stores jobs in memory (for simplicity).

---

## Prerequisites

- .NET 6+ SDK
- Optional: Visual Studio or VS Code
- Backend runs on `http://localhost:5035` (default port)

---

