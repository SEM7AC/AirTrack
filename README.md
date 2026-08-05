# AirTrack

A flight school management system built with .NET 8 and Blazor Server. AirTrack centralizes aircraft tracking, maintenance squawk logging, personnel management, and flight scheduling into a single real-time web application backed by SQLite.

---

## Overview

AirTrack is designed for small flight school operations. It tracks a mixed fleet across four aircraft types using a Table-Per-Type inheritance model, maintains a live squawk log that drives aircraft operational state, and provides a day-view scheduler for booking flights against available aircraft, instructors, and students.

All data access flows through a scoped `DbHelper` service. There is no separate API layer — the Blazor Server component tree communicates directly with the database via EF Core.

---

## Features

- **Fleet management** — add, edit, and remove aircraft across four supported types; tail numbers are unique-constrained at the database level
- **Squawk tracking** — log maintenance defects, flag grounding squawks, and resolve with mechanic sign-off and resolution notes
- **Operational state** — aircraft status is computed in real time from open squawks and scheduled events
- **Scheduler** — day-view flight scheduler linked to aircraft, instructors, students, and mechanics; timestamps stored in UTC and displayed in Pacific time
- **Personnel management** — full CRUD for instructors (with student assignments), students, and mechanics
- **Reports** — dedicated reports section for fleet and maintenance visibility
- **Input sanitization** — custom `SanitizeInputMiddleware` applied globally across all requests

---

## Architecture

```
AirTrack/
├── AirTrack.Server/
│   ├── Components/
│   │   └── Pages/               # Blazor pages: Dashboard, Aircraft, Maintenance,
│   │                            #   Scheduler, Instructors, Students, Mechanics, Reports
│   ├── Data/
│   │   ├── AirTrackContext.cs   # EF Core DbContext, TPT configuration
│   │   └── DbHelper.cs          # Scoped data access service
│   ├── Middleware/
│   │   └── SanitizeInputMiddleware.cs
│   ├── Models/
│   │   ├── Aircraft/            # AircraftBase + CessnaSkyhawk, PiperArrow,
│   │   │                        #   PiperSeminole, RobinsonR44
│   │   ├── FormModel/           # FlightEventFormModel
│   │   ├── Maintenance/         # Squawk, RecurringAD
│   │   ├── People/              # Instructor, Student, Mechanic
│   │   └── Scheduler/           # FlightEvent
│   ├── Migrations/
│   ├── Utils/                   # TimeHelper (UTC ↔ Pacific conversion)
│   └── wwwroot/
└── AirTrack.Tests/
```

**Data model — Table-Per-Type inheritance:**

```
AircraftBase (AircraftBases table)
├── CessnaSkyhawk  (CessnaSkyhawks table)
├── PiperArrow     (PiperArrows table)
├── PiperSeminole  (PiperSeminoles table)
└── RobinsonR44    (RobinsonR44s table)
```

---

## Tech Stack

| Layer       | Technology                         |
|-------------|------------------------------------|
| Runtime     | .NET 8                             |
| UI          | Blazor Server (Interactive Server) |
| Database    | SQLite                             |
| ORM         | Entity Framework Core 8.0.6        |
| Data access | Scoped `DbHelper` service          |
| Middleware  | Custom input sanitization          |
| Security    | Antiforgery, HSTS (production)     |

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### 1. Clone the repository

```bash
git clone https://github.com/SEM7AC/AirTrack.git
cd AirTrack
```

### 2. Run the application

```bash
cd AirTrack.Server
dotnet run
```

The database file (`airtrack.db`) is created automatically on first run via `EnsureCreated`. No migrations need to be applied manually.

### 3. Run tests

```bash
dotnet test AirTrack.Tests/
```

---

## Core Modules

| Module      | Route            | Description                                                |
|-------------|------------------|------------------------------------------------------------|
| Dashboard   | `/`              | Fleet overview and operational status summary              |
| Aircraft    | `/aircraft`      | Fleet CRUD; per-type forms for each supported model        |
| Maintenance | `/maintenance`   | Squawk log per aircraft; grounding flag; mechanic sign-off |
| Scheduler   | `/scheduler`     | Day-view booking grid; links aircraft, instructor, student |
| Instructors | `/instructors`   | Instructor roster with student assignments                 |
| Students    | `/students`      | Student roster with assigned instructor                    |
| Mechanics   | `/mechanics`     | Mechanic roster                                            |
| Reports     | `/reports`       | Fleet and maintenance reporting                            |

---

## Supported Aircraft Types

| Type           | Table            |
|----------------|------------------|
| Cessna Skyhawk | `CessnaSkyhawks` |
| Piper Arrow    | `PiperArrows`    |
| Piper Seminole | `PiperSeminoles` |
| Robinson R44   | `RobinsonR44s`   |

All types inherit from `AircraftBase`. Tail numbers are unique across the entire fleet.
