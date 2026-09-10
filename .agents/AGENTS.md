# Normas de Desarrollo - AlymSoft-GO-WebService

- **Aislamiento Estricto de Tablas y Objetos (Exclusividad Go):**
  - Solo se interactúa con tablas y SPs pertenecientes a AlymSoft-Go (sufijo `Go` en tablas como `tblEmpresasGo`, `tblSucursalesGo`, `tblUsuariosGo`, `tblProductosGo`, `tblPedidosGo`, etc., y prefijo `spr_AlymSoftGo_` en SPs).
  - **PROHIBIDO TOCAR TABLAS SIN SUFIJO `Go`:** Si una tabla no termina en `Go` (como `tblEmpresas`, `tblUsuarios`, `tblPlanes`), pertenece al core de AgendaService y NO se debe tocar ni modificar bajo ninguna circunstancia. Si es `tblEmpresas` y no `tblEmpresasGo`, NO SE TOCA.
- **DTOs y Parámetros en Archivos Separados:** Cada DTO y Request/Params debe residir en su propio archivo individual (una clase por archivo) dentro de su subcarpeta modular (`DTOs/Client/`, `Params/Client/`, etc.). Prohibido agrupar múltiples DTOs en archivos monolíticos.
- **DataAccess Estándar:** No alterar las firmas genéricas base de `IDataAccess` o `DataAccess`.
