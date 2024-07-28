# MyFinanceApp Solution

## Overview
The `MyFinanceApp` solution consists of three main projects:

1. **AppLibrary** - A class library containing shared logic and utilities.
2. **MyFinanceApp.client** - A JavaScript/TypeScript-based front-end project.
3. **MyFinanceApp.Server** - An ASP.NET Core back-end project.

## Project Details

### 1. AppLibrary
**Type:** Class Library

**Purpose:** This project contains shared code and business logic that can be reused by other projects in the solution, such as `MyFinanceApp.Server`.

### 2. MyFinanceApp.client
**Type:** JavaScript/TypeScript Project

**Project SDK:** `Microsoft.VisualStudio.JavaScript.Sdk`

**Details:**
- **StartupCommand:** `npm run dev` - Runs the development server.
- **JavaScriptTestFramework:** `Jest` - Used for testing.
- **ShouldRunBuildScript:** `false` - The build script in `package.json` will not run automatically on build.
- **BuildOutputFolder:** `dist` - Specifies the folder for production build outputs.

**Purpose:** This project is a front-end application built with a JavaScript framework (such as React, Angular, or Vue.js), using npm for package management and Jest for testing.

### 3. MyFinanceApp.Server
**Type:** ASP.NET Core Web Application

**Project SDK:** `Microsoft.NET.Sdk.Web`

**Details:**
- **TargetFramework:** `net8.0` - Targets .NET 8.0.
- **Nullable:** `enable` - Nullable reference types are enabled.
- **ImplicitUsings:** `enable` - Implicit using directives are enabled.
- **SpaRoot:** `../myfinanceapp.client` - Root directory of the SPA (Single Page Application) client project.
- **SpaProxyLaunchCommand:** `npm run dev` - Command to launch the SPA development server.
- **SpaProxyServerUrl:** `https://localhost:5173` - URL for the SPA development server.
- **PackageReference:** Includes `Microsoft.AspNetCore.SpaProxy` package.
- **ProjectReference:** References `AppLibrary` and `MyFinanceApp.client` projects.

**Purpose:** This project serves as the back-end server of the application. It is an ASP.NET Core web application that interacts with the front-end (`MyFinanceApp.client`) and utilizes the shared code from `AppLibrary`. The configuration suggests it's set up to work with a SPA, using `SpaProxy` to proxy requests to the SPA development server during development.

## Solution Summary
- **AppLibrary**: Contains shared logic and utilities.
- **MyFinanceApp.client**: A JavaScript/TypeScript-based front-end project.
- **MyFinanceApp.Server**: An ASP.NET Core back-end project, serving the front-end and utilizing shared code from `AppLibrary`.

This setup allows for a clear separation of concerns, with the front-end and back-end code being managed in separate projects, and shared logic being housed in the class library.

## Getting Started

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (for `MyFinanceApp.client`)

### Running the Solution

1. **Clone the repository:**
   ```bash
   git clone https://your-repo-url.git
   cd MyFinanceApp
