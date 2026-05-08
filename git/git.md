# Git — auth & commit conventions

## Authenticate with a Personal Access Token

GitHub no longer accepts password auth on HTTPS. Use a Personal Access Token (PAT) embedded in the remote URL.

### 1. Generate a PAT on GitHub

1. Sign in to [github.com](https://github.com).
2. **Settings → Developer settings → Personal access tokens** → *Generate new token*.
3. Give it a name, set an expiration, pick scopes (`repo` is enough for pushing to a private repo).
4. Click *Generate token* and **copy it immediately** — GitHub won't show it again.

### 2. Point your local clone at the PAT URL

```bash
cd path/to/your/repository
git remote set-url origin https://<PAT>@github.com/<username>/<repo>.git
```

Replace `<PAT>`, `<username>`, and `<repo>` with your values.

> Be careful where you paste this — the token is now in `.git/config`. Don't push that file or share it. For a safer alternative, use the [Git credential manager](https://github.com/git-ecosystem/git-credential-manager) or `gh auth login`.

### 3. Verify

```bash
git remote -v
```

You should see the new URL (with the token) for both `fetch` and `push`. Try `git pull` to confirm it works.

## Conventional Commits — prefix glossary

Each commit message starts with a type that describes the change. This makes history scannable and lets tools like [Commitizen](https://commitizen-tools.github.io/commitizen/) generate changelogs automatically.

| Prefix     | Meaning                                                  | Example                                |
| ---------- | -------------------------------------------------------- | -------------------------------------- |
| `feat`     | A new user-visible feature                               | `feat: add user authentication`        |
| `fix`      | A bug fix                                                | `fix: correct rendering glitch`        |
| `docs`     | Documentation only                                       | `docs: update README`                  |
| `style`    | Formatting / whitespace; no logic change                 | `style: reformat with prettier`        |
| `refactor` | Code change that neither fixes a bug nor adds a feature  | `refactor: extract helper function`    |
| `perf`     | Performance improvement                                  | `perf: cache repeated query`           |
| `test`     | Add or fix tests                                         | `test: add unit tests for component`   |
| `build`    | Build system or external dependency change               | `build: bump webpack to v5`            |
| `ci`       | CI configuration change                                  | `ci: configure GitHub Actions`         |
| `chore`    | Routine maintenance                                      | `chore: update dependencies`           |
| `revert`   | Revert a previous commit                                 | `revert: revert commit 12345`          |
