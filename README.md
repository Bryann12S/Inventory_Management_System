# Inventory Management System

Este es un proyecto de prueba técnica para un Sistema de Gestión de Inventario. La solución cuenta con una arquitectura limpia separada en dos proyectos:
- **Backend**: API REST desarrollada en ASP.NET Core (.NET 9.0) con Entity Framework Core (SQLite).
- **Frontend**: Aplicación SPA desarrollada en Blazor WebAssembly (.NET 9.0).

## 🚀 Tecnologías Utilizadas

- **.NET 9.0**
- **ASP.NET Core Web API**
- **Blazor WebAssembly**
- **Entity Framework Core (SQLite)**: Base de datos ligera y auto-contenida, elegida deliberadamente para facilitar la revisión de la prueba sin requerir la configuración de servidores de bases de datos externos.
- **JWT (JSON Web Tokens)**: Para autenticación y autorización segura.
- **ASP.NET Core Identity**: Sistema robusto para la gestión de usuarios y credenciales.
- **Swagger/OpenAPI**: Para la exploración y prueba de los endpoints de la API.

## 🛠️ Requisitos Previos

Para clonar, compilar y ejecutar este proyecto, únicamente necesitas:
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) instalado en tu equipo.
- (Opcional pero recomendado) Visual Studio 2022, Visual Studio Code o JetBrains Rider.

## ⚙️ Instrucciones para Levantar el Proyecto

El proyecto está diseñado para funcionar "out-of-the-box" (listo para usar). **No es necesario ejecutar comandos manuales de migración ni scripts de SQL**. El servidor del backend inicializa, crea el archivo físico `inventory.db` y monta todo el esquema de tablas automáticamente al arrancar.

### Opción 1: Usando la Terminal (Recomendado para revisión rápida)

Debes ejecutar el backend y el frontend en dos terminales separadas.

**1. Levantar el Backend (API)**
Abre una terminal en la raíz del proyecto y ejecuta:
```bash
cd backend
dotnet run
```
* La API estará escuchando en: `http://localhost:5296`
* Puedes ver y probar los endpoints en Swagger: `http://localhost:5296/swagger` (si está habilitado para desarrollo).

**2. Levantar el Frontend (Blazor WebAssembly)**
Abre una **nueva** terminal en la raíz del proyecto y ejecuta:
```bash
cd frontend
dotnet run
```
* La interfaz de usuario estará disponible en: `http://localhost:5279`

### Opción 2: Usando Visual Studio 2022

1. Abre el archivo `InventoryManagement.slnx` con Visual Studio.
2. Haz clic derecho en la Solución (en el Explorador de Soluciones) y selecciona **Configurar proyectos de inicio...** (Configure Startup Projects).
3. Selecciona **Proyectos de inicio múltiples** (Multiple startup projects).
4. Cambia la acción de ambos proyectos (`backend` y `frontend`) a **Iniciar** (Start).
5. Presiona **F5** para compilar y lanzar ambos proyectos simultáneamente.

## 🔑 Consideraciones para el Evaluador

- **Base de Datos SQLite**: No es necesario correr scripts de SQL ni modificar cadenas de conexión (Connection Strings). El proyecto genera/utiliza el archivo `inventory.db` directamente en la carpeta del backend.
- **Conexión Frontend - Backend**: El frontend está preconfigurado (`Program.cs` y `launchSettings.json`) para apuntar al puerto `5296` del backend. Si cambias el puerto de ejecución del backend, asegúrate de actualizar la URL en el `Program.cs` del frontend.
- **Autenticación (JWT)**: Si el sistema requiere login, puedes registrar un usuario nuevo a través del frontend o usar las credenciales de prueba (si aplica, ¡añadir credenciales aquí si tienes unas por defecto!).
