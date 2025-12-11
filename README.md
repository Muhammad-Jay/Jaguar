# JAGUAR: Local Development Orchestrator

**Jaguar** is a self-hosted, offline-first development platform designed to streamline and automate project lifecycles. It transforms complex provisioning and build scripts into a deterministic, visual node-based workflow, executed entirely on the user's local operating system.

---

## Core Objectives

1.  **Offline Capability:** Operates entirely locally, utilizing a lightweight, self-contained AI model and local file access.
2.  **Workflow Visualization:** Provides a Blazor-based interface for designing project structure and build processes via a connectable node graph.
3.  **CLI Orchestration:** Provides a powerful command-line interface for managing the platform's lifecycle (startup, status, execution) and triggering workflow events.
4.  **Local Mastery:** Enables secure, direct interaction with the user's file system for instantaneous project generation and modification.

---

## Architecture Overview

The platform is designed around a decoupled, four-component architecture to ensure scalability, stability, and clean separation of concerns. 

| Component | Type | Responsibility |
| :--- | :--- | :--- |
| **`Jaguar.Cli`** | Console Application | The primary entry point. Responsible for launching, monitoring, and controlling the **Backend** and **WebUI** processes. |
| **`Jaguar.Backend`** | ASP.NET Core Web API | The execution server. Exposes secure, local API endpoints for File System I/O, Template Management, and interfacing with the **Core** logic. |
| **`Jaguar.WebUI`** | Blazor Server Application | The user interface. Renders the visual node-based workflow editor. Communicates exclusively with the **Backend** via `HttpClient`. |
| **`Jaguar.Core`** | C# Class Library | The shared intelligence layer. Contains all non-web logic, including the Node Flow Solver, Local AI Model wrappers, and critical domain models. |

---

## Getting Started

### Prerequisites

* .NET 8.0 SDK or newer
* Git (for cloning)

### Initial Setup and Launch

1.  **Clone the Repository:**
    ```bash
    git clone [Your Repository URL]
    cd Jaguar
    ```

2.  **Build Solution:**
    ```bash
    dotnet build JaguarSolution.sln
    ```

3.  **Run the Platform:**
    The CLI will launch the necessary services and open the WebUI in your default browser.
    ```bash
    dotnet run --project Jaguar.Cli run
    ```

---

## Command Line Interface (CLI)

The **`Jaguar.Cli`** provides high-level control over the platform:

| Command | Function |
| :--- | :--- |
| **`jaguar run`** | Starts the `Backend` API and `WebUI` services and opens the browser. |
| **`jaguar stop`** | Gracefully shuts down all active Jaguar processes. |
| **`jaguar status`** | Reports the current operational status and ports of the running services. |
| **`jaguar init`** | Initializes a new project directory, prompting for a template. |
| **`jaguar flow execute`** | Executes the workflow defined in the current project's manifest file (`jaguar.json`). |

---

This revision is professional, clearly defines the architecture, and uses direct language appropriate for sophisticated developer tooling.

Do you have any further refinements or specific sections you'd like to add to this professional README?

