# CLAUDE.md

Project-level instructions for Claude Code when working in this repo.

## Language

- Communicate with the user in Ukrainian only.
- Everything else — code, comments, commit messages, PR titles/descriptions,
  docs, branch names — in English.

## Code style

- No comments in code by default — neither `//` nor XML-doc `///`.
- Exceptions: the user explicitly asks for a comment on something, or it's
  genuine public-API documentation (e.g. XML doc comments on a controller's
  endpoints).

## Git

- Never `git commit` or `git push` on your own initiative — only when the
  user explicitly tells you to (e.g. "закоміть", "заливай", "push").
  This applies even mid-task; finishing a task's code doesn't imply
  permission to commit it.

## Task workflow ("ЗАДАЧА")

When the user's message starts with **ЗАДАЧА**, treat what follows as a new
task to implement. Follow this flow:

1. **Branch first.** Create a new branch off `main`, named in English to
   reflect the task's purpose (e.g. `feature/pity-counter`,
   `fix/banner-parsing`). Never commit task work directly to `main`.
2. **Clarify before coding.** If anything about the task is ambiguous or
   underspecified, ask clarifying questions until the intent is fully
   understood — don't guess on anything that would change the approach.
3. **Summarize before/as you start.** Always give a short summary (in
   Ukrainian) of what you're about to do and why — how it fits into the
   project's overall purpose/goals — before diving into implementation.
4. **Persist reusable rules here.** If the user gives a standing rule or
   preference during a task (not just one-off instructions), add it to this
   file so it carries over across machines/sessions instead of being repeated.
