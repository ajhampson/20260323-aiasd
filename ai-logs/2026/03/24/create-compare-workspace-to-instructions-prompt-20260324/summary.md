# Session Summary: Compare Workspace To Instructions Prompt Creation

**Session ID**: create-compare-workspace-to-instructions-prompt-20260324
**Date**: 2026-03-24
**Operator**: johnmillerATcodemag-com
**Model**: openai/gpt-5.4@unknown
**Duration**: 00:08:00

## Objective

Create and save a reusable promptfile that compares the current workspace against the repository instruction files and reports significant implementation-to-instruction differences.

## Work Completed

### Primary Deliverables

1. **Comparison prompt** (`.github/prompts/compare-workspace-to-instructions.prompt.md`)
   - Added a review-oriented promptfile for instruction compliance analysis.
   - Required findings to separate implementation drift from instruction drift.
   - Scoped the review to concrete repository artifacts and significant mismatches only.

2. **Conversation log** (`ai-logs/2026/03/24/create-compare-workspace-to-instructions-prompt-20260324/conversation.md`)
   - Recorded the creation and save requests plus the resulting artifacts.

3. **Session summary** (`ai-logs/2026/03/24/create-compare-workspace-to-instructions-prompt-20260324/summary.md`)
   - Captured the objective, key decisions, and resumability context.

### Secondary Work

- Updated README.md so the new prompt artifact and its ai-log are discoverable.

## Key Decisions

### Focus On Material Drift

**Decision**: Restrict the prompt to significant differences rather than style-only commentary.
**Rationale**:

- Keeps the review useful for a small repository.
- Aligns the output with maintainability and compliance concerns rather than cosmetic nits.

### Report Instruction Defects Too

**Decision**: Treat malformed, contradictory, or stale instruction files as valid findings.
**Rationale**:

- The instruction set is part of the expected repository behavior.
- Comparison is incomplete if only implementation defects are reported.

## Artifacts Produced

| Artifact                                                                                      | Type       | Purpose                                          |
| --------------------------------------------------------------------------------------------- | ---------- | ------------------------------------------------ |
| `.github/prompts/compare-workspace-to-instructions.prompt.md`                                 | promptfile | Compare implementation against instruction files |
| `ai-logs/2026/03/24/create-compare-workspace-to-instructions-prompt-20260324/conversation.md` | log        | Preserve the prompt creation transcript          |
| `ai-logs/2026/03/24/create-compare-workspace-to-instructions-prompt-20260324/summary.md`      | summary    | Provide resumability context for the work burst  |

## Lessons Learned

1. **Instruction review needs two-way comparison**: drift can exist in the implementation or in the instruction files themselves.
2. **Prompt specificity improves signal**: requiring source-of-drift classification makes findings more actionable.
3. **Prompt artifacts need full traceability**: promptfiles follow the same provenance workflow as other AI-assisted outputs in this repository.

## Next Steps

### Immediate

- Run the new prompt against the repository.
- Confirm that the output prioritizes significant mismatches and ignores weak stylistic noise.

### Future Enhancements

- Add optional arguments later if consumers need scope restriction such as a target folder or severity threshold.

## Compliance Status

✅ Prompt artifact created with embedded provenance metadata
✅ Conversation log created in the required ai-logs path
✅ Summary file created for resumability
✅ README updated with artifact and log links

## Chat Metadata

```yaml
chat_id: create-compare-workspace-to-instructions-prompt-20260324
started: 2026-03-24T12:10:34.1982572-07:00
ended: 2026-03-24T12:10:34.1982572-07:00
total_duration: 00:08:00
operator: johnmillerATcodemag-com
model: openai/gpt-5.4@unknown
artifacts_count: 3
files_modified: 4
```

---

**Summary Version**: 1.0.0
**Created**: 2026-03-24T12:10:34.1982572-07:00
**Format**: Markdown
