# NanoCore.Templates

[![Build and Deploy](https://github.com/Nano-Core/.vsTemplates/actions/workflows/build-and-deploy.yml/badge.svg)](https://github.com/Nano-Core/.vsTemplates/actions/workflows/build-and-deploy.yml)
[![NuGet](https://img.shields.io/nuget/dt/NanoCore.Templates.svg)](https://www.nuget.org/packages/NanoCore.Templates/)
[![NuGet](https://img.shields.io/nuget/v/NanoCore.Templates.svg)](https://www.nuget.org/packages/NanoCore.Templates/)

> _`dotnet new` project templates for [Nano.Library](https://github.com/Nano-Core/Nano.Library)-based applications._

***

## Table of Contents
* [Summary](#summary)
* [Install](#install)
* [Available Templates](#available-templates)
* [Usage](#usage)
* [What's Included](#whats-included)

## Summary
This package bundles the full set of [`dotnet new` project templates](https://learn.microsoft.com/en-us/dotnet/core/tools/custom-templates) for scaffolding new
[Nano.Library](https://github.com/Nano-Core/Nano.Library)-based applications, built from the [.vsTemplates](https://github.com/Nano-Core/.vsTemplates) repository. One install gets
every template at once.

Once installed, every template appears directly in **Visual Studio 2022's "Create a new project" dialog**, no separate VSIX required, since Visual Studio 17.x surfaces any installed
`dotnet new` template, and can be discovered from the CLI via `dotnet new search <keyword>`.

## Install
```powershell
dotnet new install NanoCore.Templates
```

## Available Templates

| Template         | Short Name                  | Description                                                                                          |
| ----------------- | ----------------------------- | -------------------------------------------------------------------------------------------------------- |
| Api Minimal       | `nanocore-api-minimal`        | The Nano Api host, Docker/Kubernetes deployment, and CI/CD - minimal configuration.                       |
| Api Public        | `nanocore-api-public`         | Pre-configured for a publicly-exposed Api - the entry point handling external traffic.                    |
| Api Internal      | `nanocore-api-internal`       | Pre-configured for an internal service - handling requests from other applications within the system.     |
| Web Minimal       | `nanocore-web-minimal`        | The Nano Web host (Razor/Blazor), pre-configured for a publicly-exposed application - the entry point handling external browser traffic. |
| Console Minimal   | `nanocore-console-minimal`    | The Nano Console host, Docker/Kubernetes CronJob deployment, and CI/CD - minimal configuration.            |

More templates are added to this same package over time. See **[Nano.App.Api](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App.Api/README.md#registration)**,
**[Nano.App.Web](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App.Web/README.md#registration)**, and
**[Nano.App.Console](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App.Console/README.md#registration)** for more on each application type.

## Usage
```powershell
dotnet new nanocore-api-minimal -n MyCompany.MyApi -o .\MyCompany.MyApi
```

`-n`/`--name` sets both the output folder name (via `-o`) and the generated solution/project/namespace name - every occurrence of the template's own name in file names,
folder names, and file contents is replaced with the value you pass.

To update an existing installation to the latest version:
```powershell
dotnet new update
```

## What's Included
* A minimal `NanoApiApplication`/`NanoWebApplication`/`NanoConsoleApplication` (`Program.cs`), configured with no additional features enabled.
* `Dockerfile` / `Dockerfile.Local` and `.docker/docker-compose.yml` for local development.
* `.github/workflows/build-and-deploy.yml` - builds, tests, builds & pushes the container image, then deploys to AKS.
* `AGENTS.md`, `.claude/skills/`, and `.github/copilot-instructions.md` + `.github/prompts/` - the same [AI agent reference, Claude Code skills, and Copilot instructions](https://github.com/Nano-Core/Nano.Library#-ai-agent-reference)
  Nano.Library ships, so an AI coding agent working in the generated repository already understands Nano's conventions from the first prompt.
* A test project using MSTest.

`nanocore-api-internal` additionally ships `.kubernetes/*.yaml` wired for Azure Managed Identity federated to Kubernetes Workload Identity, so the generated application is
ready to securely access an Azure resource (Storage, SQL, Key Vault, etc.) the moment you add one, without having to plumb identity from scratch - see its own
[README](../NanoCore.Api.Internal/README.md#managed-identity) for details.
