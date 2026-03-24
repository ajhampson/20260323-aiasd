# Session Summary: Evergreen Review Prompt Creation

**Session ID**: create-evergreen-review-prompt-20260324
**Date**: 2026-03-24
**Operator**: johnmillerATcodemag-com
**Model**: openai/gpt-5.4@unknown
**Duration**: 00:10:00

## Objective

Create a reusable prompt file that inspects the current repository and reports code or structure that is not evergreen according to the repository's evergreen software development principles.

## Work Completed

### Primary Deliverables

1. **Evergreen review prompt** (`.github/prompts/review-evergreen-code.prompt.md`)
   - Added a task-oriented promptfile for code review.
   - Anchored the review to `.github/instructions/evergreen-software-development.instructions.md`.
   - Required findings to be severity-based, evidence-based, and tied to a concrete evergreen principle.

2. **Conversation log** (`ai-logs/2026/03/24/create-evergreen-review-prompt-20260324/conversation.md`)
   - Recorded the initiating prompt, context, and produced artifacts.

3. **Session summary** (`ai-logs/2026/03/24/create-evergreen-review-prompt-20260324/summary.md`)
   - Captured the objective, decisions, and resumability context for future work.

### Secondary Work

- Reused the existing draft content in `slides/review-evergreen-code-v1.txt` as the basis for the final prompt.
- Confirmed the repository README already included links for the evergreen review prompt and its logs.

## Key Decisions

### Use Evergreen Principles As The Baseline

**Decision**: Make the prompt explicitly read and evaluate against `.github/instructions/evergreen-software-development.instructions.md`.
**Rationale**:

- Keeps review results aligned with the repo's own maintainability policy.
- Avoids generic review output detached from local standards.
- Makes future prompt output easier to defend during review.

### Keep The Prompt Review-Only

**Decision**: Instruct the prompt to report findings first and avoid changing files.
**Rationale**:

- Matches the repository's code review expectations.
- Prevents the prompt from drifting into unsolicited refactoring.
- Preserves a clean separation between diagnosis and remediation.

### Prefer Strong Findings Over Many Findings

**Decision**: Require concrete, evidence-based findings with file references and remediation guidance.
**Rationale**:

- Improves signal-to-noise ratio.
- Produces output that is actionable for a small codebase.
- Reduces weak style-only comments that do not affect long-term maintainability.

## Artifacts Produced

| Artifact                                                                     | Type       | Purpose                                              |
| ---------------------------------------------------------------------------- | ---------- | ---------------------------------------------------- |
| `.github/prompts/review-evergreen-code.prompt.md`                            | promptfile | Review the repo for non-evergreen code and structure |
| `ai-logs/2026/03/24/create-evergreen-review-prompt-20260324/conversation.md` | log        | Preserve the chat transcript for prompt creation     |
| `ai-logs/2026/03/24/create-evergreen-review-prompt-20260324/summary.md`      | summary    | Provide resumability context for later edits         |

## Lessons Learned

1. **Draft reuse reduces drift**: The draft in `slides/review-evergreen-code-v1.txt` already matched the needed output and was safer to promote than rewriting from scratch.
2. **Prompt quality improves with explicit review constraints**: Calling out severity, file references, and principle mapping strengthens the resulting review.
3. **Traceability matters for prompt artifacts too**: Promptfiles need the same provenance scaffolding as other AI-assisted repository artifacts.

## Next Steps

### Immediate

- Invoke the new prompt against the current repository.
- Check whether the findings emphasize maintainability risks over formatting commentary.

### Future Enhancements

- Add optional arguments if later reviews need scope restriction, such as a target folder or severity floor.
- Tune the output format if future consumers want a stricter machine-readable report.

## Compliance Status

✅ Prompt artifact created with embedded provenance metadata
✅ Conversation log created in the required `ai-logs` path
✅ Summary file created for resumability
✅ README links already present in workspace

## Chat Metadata

```yaml
chat_id: create-evergreen-review-prompt-20260324
started: 2026-03-24T10:20:00Z
ended: 2026-03-24T10:30:00Z
total_duration: 00:10:00
operator: johnmillerATcodemag-com
model: openai/gpt-5.4@unknown
artifacts_count: 3
files_modified: 3
```

---

**Summary Version**: 1.0.0
**Created**: 2026-03-24T10:30:00Z
**Format**: Markdown# Session Summary: Evergreen Review Prompt Creation

**Session ID**: create-evergreen-review-prompt-20260324
**Date**: 2026-03-24
**Operator**: johnmillerATcodemag-com
**Model**: openai/gpt-5.4@unknown
**Duration**: 00:10:00

## Objective

Create a reusable prompt file that inspects this repository for code and project decisions that are not evergreen, using the repository's evergreen software development principles as the review baseline.

## Work Completed

### Primary Deliverables

1. **Evergreen Review Prompt** (`.github/prompts/review-evergreen-code.prompt.md`)
   - Added a prompt file dedicated to reviewing the repository for non-evergreen code.
   - Defined concrete evergreen criteria, workflow steps, and review output expectations.
   - Required findings to include severity, file locations, principle mapping, and remediation direction.

2. **Conversation Log** (`ai-logs/2026/03/24/create-evergreen-review-prompt-20260324/conversation.md`)
   - Captured the request, constraints, and resulting artifact summary.

3. **Session Summary** (`ai-logs/2026/03/24/create-evergreen-review-prompt-20260324/summary.md`)
   - Recorded the objective, deliverables, and resumability context.

### Secondary Work

- Updated README.md so the new prompt file and log artifacts are discoverable.

## Key Decisions

### Prompt Placement

**Decision**: Place the new file in `.github/prompts/` instead of `.github/prompts/meta/`.
**Rationale**:

- The prompt performs a review directly rather than generating another prompt or instruction file.
- Keeping it at the main prompt level makes discovery simpler for future use.

### Review Focus

**Decision**: Bias the prompt toward concrete maintainability and evolution risks instead of generic style complaints.
**Rationale**:

- The evergreen instruction file emphasizes durability, adaptability, and long-term maintainability.
- A shorter list of defensible findings is more useful than a long list of subjective nits.

## Artifacts Produced

| Artifact                                                                     | Type   | Purpose                                         |
| ---------------------------------------------------------------------------- | ------ | ----------------------------------------------- |
| `.github/prompts/review-evergreen-code.prompt.md`                            | prompt | Review the repository for non-evergreen code    |
| `ai-logs/2026/03/24/create-evergreen-review-prompt-20260324/conversation.md` | log    | Store the chat transcript for provenance        |
| `ai-logs/2026/03/24/create-evergreen-review-prompt-20260324/summary.md`      | log    | Provide resumability context for the work burst |

## Lessons Learned

1. **Prompt placement matters**: operational review prompts belong under `.github/prompts/`, while meta-prompts belong under `.github/prompts/meta/`.
2. **Evergreen reviews need a hard bar**: requiring severity, file locations, and principle mapping prevents vague findings.
3. **Traceability remains part of prompt work**: prompt files in this repository are treated as AI-assisted artifacts with full provenance.

## Next Steps

### Immediate

- Run the new prompt against the current repository to generate an evergreen review report.

### Future Enhancements

- Extend the prompt later if the repository grows into additional layers such as services, tests, or deployment infrastructure.

## Compliance Status

✅ Conversation log created
✅ Summary created
✅ README updated with artifact link
✅ Prompt includes provenance metadata

## Chat Metadata

```yaml
chat_id: create-evergreen-review-prompt-20260324
started: 2026-03-24T10:20:00Z
ended: 2026-03-24T10:30:00Z
total_duration: 00:10:00
operator: johnmillerATcodemag-com
model: openai/gpt-5.4@unknown
artifacts_count: 3
files_modified: 4
```

---

**Summary Version**: 1.0.0
**Created**: 2026-03-24T10:30:00Z
**Format**: Markdown
