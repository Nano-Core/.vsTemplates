# NanoCore.Api.Public

> _Publicly-exposed Nano API application._

> ⚠️ Remember to set the docker-compose project as the startup project before running the solution in Visual Studio.

***

## Table of Contents
* [Summary](#summary)
* [Public Exposure](#public-exposure)

## Summary
This application is a Nano API set up to be the entry point for external traffic: no data provider, no storage, no eventing — just the Nano API host, hardened security
headers, Kubernetes ingress routing, Docker/Kubernetes deployment, and CI/CD.

The application itself is intentionally minimal and does not expose custom HTTP endpoints or configure additional features beyond the boilerplate. Instead, it serves as a
baseline you build your actual application on top of.

> 📖 Learn more about **[Nano API Applications](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App.Api/README.md#nanoappapi)**.

## Public Exposure
This template includes what's needed for an application that is reachable from outside the cluster, as opposed to an internal service other applications call over the
cluster-internal network:

* **`.kubernetes/httproute-443.yaml` / `httproute-80.yaml`** — routes external traffic from the cluster's shared Gateway to this application (port 80 redirects to 443).
  `Kubernetes Deploy` in the CI/CD workflow resolves the hostnames from your Azure DNS zones (`$env:AZURE_GROUP_DNS` + `$env:SUB_DOMAIN_NAME`) and the cluster's Gateway
  name at deploy time — set the `AZURE_RESOURCE_GROUP_DNS` and `SUB_DOMAIN_NAME` repository variables before your first deploy.
* **`.kubernetes/service-monitor.yaml`** — Prometheus scraping of the `/metrics` endpoint (enabled via `App.Metrics` in `appsettings.json`).
* **`appsettings.json`** — a hardened `HttpPolicyHeaders` baseline (CSP, HSTS, Referrer Policy, Frame Options, Robots, Forwarded Headers), `ResponseCache`, `ResponseCompression`,
  `Documentation` (Swagger), and `HealthCheck` enabled. `Cors.AllowedOrigins` is empty by default — set the `CORS_ALLOWED_ORIGIN_0` repository variable to the origin(s) that
  should be allowed to call this API from a browser.
* **`Add Availability Check`** — the CI/CD workflow provisions an Application Insights availability web test (and an alert rule) against `https://<sub-domain>.<dns-zone>/healthz`
  for each configured Azure DNS zone, using Log Analytics/Application Insights resolved from the `AZURE_RESOURCE_GROUP_LOGS` repository variable — set it before your first deploy.

Authentication isn't configured — add `App.Authentication.Jwt` (or your own scheme) once you know how callers will authenticate.
