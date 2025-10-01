const log = (m) => (document.getElementById("log").textContent += m + "\n");

document.getElementById("inject").addEventListener("click", async () => {
  const [tab] = await chrome.tabs.query({ active: true, currentWindow: true });
  if (!tab?.id) return;
  await chrome.scripting.executeScript({
    target: { tabId: tab.id },
    func: () => alert("Hello from popup via scripting API!")
  });
  log("Injected greeting into active tab.");
});

document.getElementById("save").addEventListener("click", async () => {
  const when = new Date().toISOString();
  await chrome.storage.sync.set({ lastClicked: when });
  log("Saved: " + when);
});
