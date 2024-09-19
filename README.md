# CRUD - Wayni - Quispe Andia Jeremy Joel 

## Descripción del Proyecto
Este proyecto es una aplicación web ASP.NET Core que implementa un sistema CRUD (Crear, Leer, Actualizar, Eliminar) para gestionar usuarios. La aplicación interactúa con una base de datos MySQL y tiene validaciones para nombres, apellidos y DNI.

## Instalación y Configuración
### Requisitos
- Rider como IDE.
- .NET 6 SDK.
- MySQL.

### Pasos para ejecutar el proyecto
1. Clona el repositorio:
   ```bash
   git clone https://github.com/Jemisas/crudWayni_QuispeAndia.git
2. Abre el proyecto en Rider.
3. Configura la cadena de conexión en el archivo appsettings.json:
   
```c#
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;user=root;password=tu_contraseña;database=crud_db"
  }
}
```

5. Listo prueba todas las funcionalidades

### Validaciones tomadas en cuenta

- Nombre y Apellido: Solo permiten letras.
- DNI: Debe ser un número de exactamente 8 dígitos y único.

### Evidencias

**Vista principal:**

![image](https://github.com/user-attachments/assets/97413995-e6e7-4b88-9002-7621c3db7a3d)

**Vista Crear Nuevo Usuario:**

![image](https://github.com/user-attachments/assets/ba6f2930-aef6-4e9e-bb9b-86ed8ed28d8c)

**Vista Editar Usuario:**

![image](https://github.com/user-attachments/assets/dae29cd7-1c9d-4e15-8704-a743f0551950)

**Vista Detalle Usuarios y Eliminar Usuario:**

![image](https://github.com/user-attachments/assets/107a6447-9875-4c56-8e4d-f0678942f269)

**Video explicativo de la funcionalidad del proyecto:**

Link: [Ver Enlace](https://youtu.be/4M_Y_xSDEHk)




