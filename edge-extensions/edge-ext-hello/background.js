chrome.runtime.onInstalled.addListener(() => {
  chrome.contextMenus.create({
    id: "sayHello",
    title: "Hello Edge: \"%s\"",
    contexts: ["selection"]
  });
});

chrome.contextMenus.onClicked.addListener(async (info, tab) => {
  if (info.menuItemId === "sayHello" && tab?.id) {
    const text = info.selectionText ?? "";
    await chrome.scripting.executeScript({
      target: { tabId: tab.id },
      func: (t) => alert(`Hello from Edge extension!\nSelection: ${t}`),
      args: [text]
    });
  }
});
