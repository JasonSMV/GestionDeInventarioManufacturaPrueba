# Instrucciones

El proyecto usa .NET Core 8 y SQLite con migraciones para facilitar el desarrollo. Además, cuenta con una clase Seed que llena la base de datos con datos por defecto cuando se corre por primera vez.

### Tecnologías Usadas:
- **Backend**: .NET Core 8
- **Frontend**: Angular 18
- **Base de Datos**: SQLite
- **Autenticación JWT**: Para llamadas API seguras
---

## Configuración del Proyecto

### 1. Configuración del Backend

1. **Instalar .NET Core 8**:
    Tener **.NET Core 8** instalado.

2. **Correr el Backend**:

   ```bash
   dotnet run
   ```

   El backend se ejecutará en **http://localhost:5001**.

---

### 2. Configuración del Frontend

1. **Navegar a la carpeta Client**:

   ```bash
   cd Client
   ```

2. **Instalar dependencias de Node**:

   Tener **Node.js 22.12.0** y **npm** instalados. Instala las dependencias:

   ```bash
   npm install
   ```

3. **Instalar Angular CLI 18**:

   ```bash
   npm install -g @angular/cli@18
   ```

4. **Correr el Frontend**:

   ```bash
   ng serve
   ```

   El frontend estará disponible en **http://localhost:4200**.

---

## Autenticación y Token JWT

1. **Obtener el Token JWT**:
   Use el endpoint **`/cuenta/login`** con las siguientes credenciales:

   - **Usuario**: `andres.rodriguez@test.com`
   - **Contraseña**: `Pa$$w0rd`

2. **Use el Token JWT**:
   Incluye el token en el encabezado **Authorization** para hacer llamadas a la API:

   ```http
   Authorization: Bearer <Tu-Token-JWT>
   ```

---

## Requisitos

- **Node.js**: Versión 22.12.0
- **Angular CLI**: Versión 18

---