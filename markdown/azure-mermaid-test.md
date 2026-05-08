# Mermaid in Azure DevOps wiki

Azure DevOps wiki uses a slightly different fence for Mermaid blocks: triple-colon (`:::`) instead of triple-backtick.

## Gantt example

```
::: mermaid
gantt
    title A Gantt chart
    dateFormat YYYY-MM-DD
    excludes 2022-03-16,2022-03-18,2022-03-19
    section Section

    A task          :a1, 2022-03-07, 7d
    Another task    :after a1 , 5d
:::
```

## Inline image

```markdown
![my favourite text](img/test.img "hover over")
```

## Sample folder tree

```
├── src
│   ├── controller
│   │   ├── **/*.css
│   ├── views
│   ├── model
│   ├── index.js
├── public
│   ├── css
│   │   ├── **/*.css
│   ├── images
│   ├── js
│   ├── index.html
├── dist (or build)
├── node_modules
├── package.json
├── package-lock.json
└── .gitignore
```
