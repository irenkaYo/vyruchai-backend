# Vyruchai — Backend

A simple service for managing requests and assigning masters to them. Built with .NET 9.

## What it does

- Accepts requests (cleaning, delivery, tech repair)
- Finds a suitable master for each request
- Tracks request status

## Request types

| Type | How cost is calculated |
|---|---|
| `Cleaning` | area × 8 per m² |
| `Delivery` | free if order total ≥ 50, otherwise +20 delivery fee |
| `TechRepair` | base price 100; +20% if needed in a week, +50% if needed in an hour |

## Request statuses

- `Created` — just submitted
- `InWork` — a master has been assigned
- `Done` — completed
- `Canceled` — no suitable master was found

## Masters

All masters implement the `IMaster` interface. Each master can be free or busy, and can only take requests they're able to handle.

Master types: `TechMaster`, `DeliveryMaster`, `Cleaner`.

## Central service

`CentralService` stores the list of requests and masters. When a new request comes in, it looks for a free master who can handle it. If no one is available, the request is canceled.

It works only with abstractions — it doesn't know about specific request or master types.
