# Jaguar: AI-Powered Development Orchestrator

Jaguar is a development platform designed to streamline and automate project lifecycles using AI. It transforms complex development tasks into a deterministic, visual node-based workflow, executed on the user's local operating system.

---

## Core Objectives

1.  **AI-Powered Orchestration:** Utilizes a Large Language Model (LLM) to interpret user prompts and generate structured project plans.
2.  **Visual Workflow Editor:** Provides a desktop application with a visual, node-based canvas for designing and visualizing project workflows.
3.  **Local-First Execution:** Operates primarily on the local machine, allowing direct and secure interaction with the file system.
4.  **Multi-faceted Interaction:** Offers multiple interfaces for interacting with the platform, including a desktop GUI, a command-line interface (CLI), and a web API.

---

## Architecture Overview

The platform is designed with a decoupled, multi-component architecture to ensure a clean separation of concerns.

| Component | Type | Responsibility |
| :--- | :--- | :--- |
| **`Jaguar.Desktop`** | Avalonia UI Application | The primary user interface. It provides the visual node-based workflow editor and interacts with the core logic. |
| **`Jaguar.Core`** | C# Class Library | The shared intelligence layer. It contains the core logic, including the `Orchestrator`, domain models, and business rules. |
| **`Jaguar.LLM`** | C# Class Library | Handles all interactions with the Large Language Model (Google's Gemini Pro) to provide the AI capabilities. |
| **`Jaguar.Api`** | ASP.NET Core Web API | Exposes Jaguar's functionality over HTTP, allowing for remote or programmatic interaction with the platform. |
| **`Jaguar.Cli`** | .NET Console Application | Provides a command-line interface for scripting and automating interactions with the Jaguar platform. |

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

2.  **Build the Solution:**
    ```bash
    dotnet build JaguarSolution.sln
    ```

3.  **Run the Desktop Application:**
    The primary way to use Jaguar is through the desktop application.
    ```bash
    dotnet run --project Jaguar.Desktop
    ```

---

## Command Line Interface (CLI)

The **`Jaguar.Cli`** provides high-level control over the platform:

| Command | Function |
| :--- | :--- |
| **`jaguar run`** | Starts the necessary background services for the Jaguar platform. |
| **`jaguar status`** | Reports the current operational status of the running services. |
| **`jaguar init`** | Initializes a new project directory, prompting for a template. |
| **`jaguar flow execute`** | Executes the workflow defined in the current project's manifest file (`jaguar.json`). |