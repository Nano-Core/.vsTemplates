# NanoCore.Templates
[![Build and Deploy](https://github.com/Nano-Core/.vsTemplates/actions/workflows/build-and-deploy.yml/badge.svg)](https://github.com/Nano-Core/.vsTemplates/actions/workflows/build-and-deploy.yml)
[![NuGet](https://img.shields.io/nuget/dt/NanoCore.Templates.svg)](https://www.nuget.org/packages/NanoCore.Templates/)
[![NuGet](https://img.shields.io/nuget/v/NanoCore.Templates.svg)](https://www.nuget.org/packages/NanoCore.Templates/)

> _`dotnet new` project templates for [Nano.Library](https://github.com/Nano-Core/Nano.Library)-based applications, distributed as a single NuGet package._

***

## Table of Contents
&nbsp;&nbsp;&nbsp;&nbsp;📌 **[Summary](#summary)**  
&nbsp;&nbsp;&nbsp;&nbsp;📦 **[Available Templates](#available-templates)**  
&nbsp;&nbsp;&nbsp;&nbsp;⚖️ **[Licenses](#licenses)**  

## Summary
This repository is a collection of [`dotnet new` project templates](https://learn.microsoft.com/en-us/dotnet/core/tools/custom-templates) for scaffolding new Nano-based applications.
All templates are bundled into one `NanoCore.Templates` NuGet package, built from the `NanoCore.Templates.sln` solution's single `NanoCore.Templates/NanoCore.Templates.csproj` project.
Installing the package installs the full set at once.

```powershell
dotnet new install NanoCore.Templates
```

Once installed, every template appears directly in **Visual Studio 2022's "Create a new project" dialog**, no separate VSIX required, since Visual Studio 17.x surfaces any installed
`dotnet new` template, and can be discovered from the CLI via `dotnet new search <keyword>`.

## Available Templates

| Template          | Short Name                    | Description                                                                                              |
| ----------------- | ----------------------------- | -------------------------------------------------------------------------------------------------------- |
| Api Minimal       | `nanocore-api-minimal`        | The Nano Api host, Docker/Kubernetes deployment, and CI/CD - minimal configuration.                      |
| Api Public        | `nanocore-api-public`         | Pre-configured for a publicly-exposed Api - the entry point handling external traffic.                   |
| Api Internal      | `nanocore-api-internal`       | Pre-configured for an internal service - handling requests from other applications within the system.    |
| Web Minimal       | `nanocore-web-minimal`        | The Nano Web host (Razor/Blazor), pre-configured for a publicly-exposed application - the entry point handling external browser traffic. |
| Console Minimal   | `nanocore-console-minimal`    | The Nano Console host, Docker/Kubernetes CronJob deployment, and CI/CD - minimal configuration.          |

```powershell
dotnet new nanocore-api-minimal -n MyCompany.MyApi -o .\MyCompany.MyApi
```

More templates will be added to this same package over time. See **[Nano.App.Api](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App.Api/README.md#registration)**,
**[Nano.App.Web](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App.Web/README.md#registration)**, and
**[Nano.App.Console](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App.Console/README.md#registration)** for more on each application type.

> 🤖 Once scaffolded, hand it to your AI coding assistant (Claude Code, Copilot, etc.) and just describe what you need next: add a logging or data provider, define your first
> entity, wire up an eventing subscription. The generated repository already ships `AGENTS.md`, Claude Code skills, and Copilot instructions, so the assistant knows Nano's
> conventions from the first prompt.

## Licenses
This repository is licensed under the [MIT License](LICENSE).