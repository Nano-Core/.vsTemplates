# NanoCore.Console.Minimal

> _Minimal Nano Console application._

> ⚠️ Remember to set the docker-compose project as the startup project before running the solution in Visual Studio.

***

## Table of Contents
* [Summary](#summary)
* [Scheduled Job](#scheduled-job)

## Summary
This application represents the most minimal Nano Console application setup that is still production-ready to deploy: no data provider, no storage, no eventing — just the
Nano Console host, Docker/Kubernetes deployment, and CI/CD.

The application itself is intentionally minimal and does not implement any workers or configure additional features beyond the boilerplate. Instead, it serves as a baseline
you build your actual application on top of.

> 📖 Learn more about **[Nano Console Applications](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App.Console/README.md#nanoappconsole)**.

## Scheduled Job
Console applications run as a Kubernetes `CronJob` rather than a long-running `Deployment` — there's no `Service`, `HorizontalPodAutoscaler`, or HTTP port, since a
Console app doesn't serve traffic. Add your workers by implementing `IWorker`; every worker runs to completion once per job invocation, then the pod exits.

* **`.kubernetes/cronjob.yaml`** — set the schedule via the `KUBERNETES_CRONJOB_SCHEDULE` repository variable in `.github/workflows/build-and-deploy.yml` (defaults to
  hourly, `"0 * * * *"`) before your first deploy.

> 📖 Learn more about **[Console Workers](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App.Console/README.md#console-workers)**.
