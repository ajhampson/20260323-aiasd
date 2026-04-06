---
name: evergreen-software-development
description: Repository-wide guidance for building maintainable, supportable, upgrade-friendly software
applyTo: "**/*"
version: "1.0.0"
owner: "Development Team"
reviewedDate: "2026-03-31"
nextReview: "2026-06-30"
---

# Evergreen Software Development Instructions

## Purpose

Build software that stays easy to run, upgrade, test, secure, and understand over time.

## Core Rules

1. Prefer supported platforms, SDKs, frameworks, and packages.
2. Prefer stable standards over vendor-specific or preview-only features unless the repository explicitly requires them.
3. Keep business logic independent from UI, transport, storage, and hosting concerns.
4. Optimize for safe change: small units, clear contracts, automated tests, and observable behavior.
5. Remove dead code, placeholders, and duplicated logic as part of normal maintenance.

## Architecture

- Separate domain logic from presentation and infrastructure.
- Keep modules cohesive and dependencies directional.
- Depend on abstractions at boundaries.
- Avoid coupling reusable logic to a single app type, operating system, or hosting model unless required.
- Design contracts for additive change first; treat breaking changes as explicit decisions.

## Dependencies

- Use packages that are actively maintained and compatible with the repository target frameworks.
- Prefer built-in platform features before adding new dependencies.
- Avoid deprecated, legacy, or abandoned libraries.
- Pin versions intentionally and update regularly.
- Consolidate package version management when the repository has multiple projects.
- Remove unused package references and transitive dependency bloat.

## Target Frameworks and Runtime

- Target currently supported .NET releases.
- Prefer cross-platform target frameworks for reusable libraries.
- Use OS-specific target frameworks only where platform APIs are required.
- Avoid unnecessary preview SDK or preview package dependencies in production paths.
- Keep build, test, and deployment workflows aligned with the chosen target frameworks.

## Code Design

- Prefer simple, explicit code over clever or highly coupled code.
- Keep public APIs small, predictable, and well-named.
- Minimize hidden state and side effects.
- Centralize parsing, formatting, validation, and error handling logic when reused.
- Replace magic strings and magic values with constants, options, enums, or resources where appropriate.
- Design for localization if user-facing text is part of the product surface.

## Data and Configuration

- Store configuration outside code when values vary by environment.
- Validate configuration at startup or at boundary entry points.
- Prefer structured configuration objects over scattered key lookups.
- Version persisted schemas and data contracts when they may evolve.
- Preserve backward compatibility for stored data and public integration points where practical.

## Testing

- Put test projects in the solution and keep them easy to discover and run.
- Test business logic independently from UI frameworks.
- Cover happy paths, boundary cases, failure paths, and regression scenarios.
- Prefer deterministic tests with no hidden environment assumptions.
- Add tests when fixing defects or changing behavior.
- Remove empty scaffold tests and obsolete test assets.

## Observability and Operations

- Emit actionable logs at boundaries, failures, and important state transitions.
- Prefer structured logging over concatenated text.
- Expose health, readiness, and diagnostic signals when applicable.
- Fail clearly and safely; avoid silent catch-and-ignore patterns.
- Ensure common maintenance tasks can run through automation.

## Security and Compliance

- Keep secrets out of source control.
- Use secure defaults and least privilege.
- Validate all external input.
- Track dependency vulnerabilities and remediate promptly.
- Prefer supported cryptography and authentication mechanisms.
- Document security-sensitive assumptions and operational prerequisites.

## Documentation and Change Management

- Document architectural decisions that affect long-term maintenance.
- Record non-obvious constraints, upgrade steps, and deprecation plans.
- Keep examples, scripts, and docs aligned with the current implementation.
- When introducing a temporary workaround, document exit criteria and owner.
- Prefer migration-friendly changes over one-time rewrites.

## Review Checklist

Before merging, verify:

- Supported targets and dependencies are used.
- Reusable logic is not trapped in UI or infrastructure layers.
- New code is covered by relevant tests.
- User-visible strings and configuration are maintainable.
- No deprecated packages, placeholder files, or dead code were introduced.
- The change improves or preserves upgradeability, portability, and operability.

## .NET Notes

For .NET repositories:

- Keep projects on current supported .NET versions.
- Prefer SDK-style projects and centralized build settings when helpful.
- Keep analyzers and test infrastructure current.
- Extract reusable logic into non-UI class libraries where possible.
- Use async, DI, logging, configuration, and options patterns consistently when the app model supports them.
