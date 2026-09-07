# NanoCore.Api.Internal

> _Internal-service Nano API application, pre-wired for Azure Managed Identity / Workload Identity._

> ⚠️ Remember to set the docker-compose project as the startup project before running the solution in Visual Studio.

***

## Table of Contents
* [Summary](#summary)
* [Managed Identity](#managed-identity)
* [Internal Service](#internal-service)

## Summary
This application is a Nano API set up for service-to-service use within the cluster, not for direct external traffic: no data provider, no storage, no eventing — just the
Nano API host, Kubernetes metrics, Docker/Kubernetes deployment, and CI/CD.

The application itself is intentionally minimal and does not expose custom HTTP endpoints or configure additional features beyond the boilerplate. Instead, it serves as a
baseline you build your actual application on top of.

> 📖 Learn more about **[Nano API Applications](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App.Api/README.md#nanoappapi)**.

## Managed Identity
Unlike a truly blank app, this template is pre-wired with an Azure user-assigned Managed Identity, federated to the pod via Kubernetes Workload Identity
(`.kubernetes/service-account.yaml`, and the `azure.workload.identity/use`/`serviceAccountName` wiring in `.kubernetes/deployment.yaml`). The `Managed Identity` step in
`.github/workflows/build-and-deploy.yml` creates the identity (if it doesn't already exist) and federates it to the pod's Kubernetes ServiceAccount — no Azure resource is
granted access to it yet.

This means the application is already prepared to securely access Azure resources (Storage, SQL, Key Vault, etc.) via passwordless Entra ID authentication the moment you add
one — add an `az role assignment create` step scoped to `$env:IDENTITY_PRINCIPAL_ID` for whatever resource you add, rather than wiring up identity from scratch.

> 📖 Learn more about **[Azure Workload Identity](https://azure.github.io/azure-workload-identity/docs/introduction.html)**.

## Internal Service
This template is set up for an application that other services call over the cluster-internal network, as opposed to a publicly-exposed Api reachable from outside the
cluster:

* No Kubernetes `HTTPRoute` — the Service is only reachable at its in-cluster DNS name (`%SERVICE_NAME%`), never routed through the shared Gateway.
* **`.kubernetes/service-monitor.yaml`** — Prometheus scraping of the `/metrics` endpoint is still enabled (via `App.Metrics` in `appsettings.json`), since internal
  services are just as worth monitoring as public ones.
* **`appsettings.json`** — the browser-facing `HttpPolicyHeaders` (CSP, HSTS, Referrer Policy, Frame Options, Robots, CORS) are left `null`, since there's no browser
  involved in service-to-service calls; `ForwardedHeaders` is kept, since the app still sits behind the cluster's proxy chain. No HTTPS is configured — internal traffic
  stays HTTP within the cluster network.

Authentication isn't configured — add `App.Authentication.Jwt` (or your own scheme) once you know how callers will authenticate.
