(() => {
  const h1 = document.querySelector("h1");
  if (!h1) return;
  h1.style.outline = "3px dashed #888";
  h1.title = "Injected by Hello Edge";
})();