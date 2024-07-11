# Git Authentication Setup Guide

This guide provides steps to set up authentication for your Git repository using a personal access token in the remote URL.

## Step 1: Generating a Personal Access Token (PAT) on GitHub

Before proceeding, ensure you have a Personal Access Token from GitHub. If you don't have one, follow these steps:

1. **Log in to GitHub**: Go to [github.com](https://github.com) and sign in.
2. **Access Settings**: Click on your profile picture in the top right corner and select "Settings".
3. **Developer Settings**: In the settings menu, find and click on "Developer settings".
4. **Personal Access Tokens**: Navigate to "Personal access tokens" and click on "Generate new token".
5. **Token Settings**: Give your token a descriptive name, set the expiration as needed, and select the appropriate scopes.
6. **Generate Token**: Click "Generate token" at the bottom.

Remember to copy your new personal access token. You won’t be able to see it again!

## Step 2: Configuring Your Local Repository

Now, you'll configure your local repository to use this token for authentication.

1. **Open Terminal**: Launch your command line or terminal.
2. **Navigate to Your Repository**: Use `cd` to navigate to your local Git repository.

    ``` path
    cd path/to/your/repository
    ```

3. **Set New Remote URL**: Use the `git remote set-url` command to set the new URL, which includes your personal access token.

    ``` command
    git remote set-url origin git remote set-url origin https://PAT@github.com/username/repo.git
    ```

   Replace `PAT` with your personal access token, `username` with your GitHub username, and `repo.git` with your repository name.

## Step 3: Verifying the Configuration

After setting the new remote URL, it's a good practice to verify the configuration.

1. **Check Remote URL**: Execute the following command to check the configured remote URL.

    ``` command
    git remote -v
    ```

2. **Ensure the URL is Updated**: The output should show the new URL with your token included.

You are now ready to use Git with your repository authenticated through your personal access token!

У git-повідомленнях комітів прийнято використовувати певні ключові слова для опису типу змін. Ось список поширених термінів:

1. **feat**: Додавання нової функціональності або можливості.
   - Приклад: `feat: додати авторизацію користувача`

2. **fix**: Виправлення помилки.
   - Приклад: `fix: виправити помилку відображення`

3. **docs**: Зміни в документації.
   - Приклад: `docs: оновити README`

4. **style**: Зміни, які не впливають на сенс коду (наприклад, форматування, пропуски, коми і т.д.).
   - Приклад: `style: форматування коду`

5. **refactor**: Зміни коду, які не виправляють помилки і не додають нових функцій, а тільки покращують внутрішню структуру коду.
   - Приклад: `refactor: оптимізація функції`

6. **perf**: Зміни, спрямовані на покращення продуктивності.
   - Приклад: `perf: оптимізація алгоритму`

7. **test**: Додавання або виправлення тестів.
   - Приклад: `test: додати юніт-тести для компонента`

8. **build**: Зміни, що впливають на збірку проєкту або зовнішні залежності (наприклад, gulp, broccoli, npm).
   - Приклад: `build: оновити конфігурацію webpack`

9. **ci**: Зміни, пов'язані з налаштуваннями CI (не впливають на код проєкту).
   - Приклад: `ci: налаштувати GitHub Actions`

10. **chore**: Рутинні завдання, які не впливають на код (наприклад, оновлення залежностей).
    - Приклад: `chore: оновити залежності`

11. **revert**: Відкат до попереднього коміту.
    - Приклад: `revert: відкотити commit 12345`

Використання цих ключових слів допомагає структурувати історію комітів і робить її більш читабельною для всієї команди.