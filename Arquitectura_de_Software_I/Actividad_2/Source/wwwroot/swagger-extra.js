
window.addEventListener("load", () => {
  // Esperar hasta que Swagger UI esté disponible
  const waitForSwaggerUI = setInterval(() => {
    const uiRoot = document.querySelector(".swagger-ui");
    if (!uiRoot) return; // Aún no ha cargado

    clearInterval(waitForSwaggerUI); // Swagger UI ya cargó

    addParticipants();

    const select = document.querySelector("#select");
    if (select) {
      select.addEventListener("change", () => {
        setTimeout(() => {
          addParticipants();
        }, 1000);
      });
    }
  }, 500);
});



const addParticipants = () => {

  // Intentar obtener el objeto Swagger UI (creado globalmente)
  const spec = window?.ui?.specSelectors?.info?.() ?? null;

  // Si no existe, intentar obtenerlo directamente desde el JSON cargado
  const rawSpec = window.ui?.spec()?.toJS?.() ?? null;

  if (!spec && !rawSpec) return; // Esperar más


  try {

    const info = rawSpec?.info ?? spec?.toJS();
    const contact = info?.contact;

    if (!contact || !contact["x-integrantes"]) return;

    const integrantes = contact["x-integrantes"];
    const container = document.querySelector(".info__contact");
    if (!container || container.querySelector(".integrantes-list")) return;

    const div = document.createElement("div");
    div.className = "integrantes-list";
    div.innerHTML = `
        <h4 style="margin-top: 10px;">Integrantes</h4>
        <ul style="margin-left: 15px;">
          ${integrantes.map(i => `<li>${i}</li>`).join("")}
        </ul>
      `;

    container.appendChild(div);
  } catch (error) {
    console.error("Error mostrando integrantes:", error);
  }
}