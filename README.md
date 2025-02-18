# API Gestor de Tareas

Este es un proyecto de API para un gestor de tareas, desarrollado con **.NET 8**. El propósito de esta API es permitir la creación, actualización, eliminación y consulta de tareas, y puede ser utilizada por un frontend para interactuar con los datos.

## Requisitos

- **.NET 8 SDK**
- **Visual Studio 2022** o superior

## Instalación

Sigue estos pasos para configurar e instalar el proyecto en tu entorno local:

### 1. Clonar el repositorio

Abre la terminal y ejecuta el siguiente comando para clonar el repositorio:


git clone https://github.com/tu_usuario/nombre_del_repositorio.git

**Instalar dependencias**

Una vez que el repositorio esté clonado, abre la carpeta del proyecto en Visual Studio o ejecuta el siguiente comando en la terminal desde la raíz del proyecto:


dotnet restore


**Verificar configuración de puertos**

Asegúrate de que los puertos en el archivo Program.cs estén configurados correctamente para que la API y el frontend puedan comunicarse.

Abre el archivo Program.cs y busca la sección donde se configuran los puertos. Verifica que los puertos que uses sean los correctos y estén disponibles.

Asegúrate de que el puerto configurado aquí coincida con el puerto que se utilizará en el frontend para las peticiones API.

**Abrir el proyecto en Visual Studio**

Abre Visual Studio.
Selecciona Abrir un proyecto o solución y navega hasta la carpeta donde has clonado el proyecto.
Selecciona el archivo ApiGestorTareas.csproj y haz clic en Abrir.

**Ejecutar la API**
En Visual Studio, selecciona la configuración Debug o Release en la barra de herramientas.
Haz clic en el botón Iniciar (o presiona F5) para ejecutar la API.
