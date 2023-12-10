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
    ```
    cd path/to/your/repository
    ```
3. **Set New Remote URL**: Use the `git remote set-url` command to set the new URL, which includes your personal access token.
    ```
    git remote set-url origin git remote set-url origin https://PAT@github.com/username/repo.git
    ```
   Replace `PAT` with your personal access token, `username` with your GitHub username, and `repo.git` with your repository name.

## Step 3: Verifying the Configuration

After setting the new remote URL, it's a good practice to verify the configuration.

1. **Check Remote URL**: Execute the following command to check the configured remote URL.
    ```
    git remote -v
    ```
2. **Ensure the URL is Updated**: The output should show the new URL with your token included.

You are now ready to use Git with your repository authenticated through your personal access token!