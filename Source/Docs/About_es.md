# RipeConsole

RipeConsole es una aplicación de consola diseñada para ejecutar múltiples herramientas relacionadas con el procesamiento de archivos, especialmente orientadas a juegos de PopCap. El sistema permite operar en distintos modos de ejecución, adaptándose tanto a usuarios interactivos como a automatización mediante scripts.

---

## Descripción General

El programa funciona como un **launcher de acciones** donde cada funcionalidad está encapsulada en una estructura independiente (`ToolAction`). Estas acciones pueden ser ejecutadas mediante menús interactivos o directamente desde la línea de comandos.

El diseño prioriza:

* Reutilización de lógica mediante una librería externa (`RipeLib`)
* Separación entre interfaz de usuario y ejecución de acciones
* Flexibilidad para añadir nuevas funcionalidades sin modificar el núcleo del programa

---

## Modos de Ejecución

### 1. Modo Interactivo

Es el modo por defecto cuando no se especifican argumentos válidos de CLI.

* Se muestran categorías de funciones
* El usuario selecciona una categoría
* Luego selecciona una acción dentro de dicha categoría
* Se ejecuta la acción elegida

---

### 2. Modo Drag & Drop

Se activa al pasar un archivo o carpeta como argumento.

* Detecta si el argumento es archivo o directorio
* Filtra automáticamente las acciones disponibles según el tipo
* Muestra un menú simplificado sin categorías
* Permite ejecutar acciones directamente sobre el recurso

---

### 3. Modo CLI (Command Line Interface)

Permite ejecutar acciones directamente sin interacción.

#### Sintaxis:

```bash
program.exe <input> [output] @<id>
```

#### Ejemplo:

```bash
program.exe "C:\archivo.txt" "C:\salida.txt" @3
```

#### Reglas:

* `<input>`: Ruta de entrada (archivo o carpeta)
* `[output]`: Ruta de salida (opcional, depende de la acción)
* `@<id>`: Identificador de la acción a ejecutar (obligatorio para CLI)

#### Notas:

* El prefijo `@` elimina ambigüedad con rutas numéricas
* Argumentos adicionales pueden ser requeridos según la acción

---

## Arquitectura

### ToolAction

Representa una acción ejecutable del sistema.

Contiene:

* Nombre de la acción
* Método de ejecución
* Filtros para archivos o carpetas
* Configuración de compatibilidad

---

### MenuCategory

Agrupa acciones bajo una categoría.

* Contiene una lista de IDs de acciones
* Se utiliza únicamente en modo interactivo

---

### BaseMenu

Gestiona la lógica de navegación y selección.

* Soporta menús con o sin categorías
* Retorna siempre una acción (`ToolAction`)
* Evita estructuras rígidas como `switch`

---

### Program

Punto de entrada de la aplicación.

Responsabilidades:

* Detectar modo de ejecución
* Configurar consola
* Mostrar interfaz inicial
* Ejecutar acciones seleccionadas
* Manejar errores y logs

---

### RipeLib

Librería externa que contiene:

* Definición de acciones
* Sistema de menús
* Utilidades compartidas

Permite reutilizar la lógica en otros proyectos.

---

## Flujo de Ejecución

1. Se reciben los argumentos (`args`)
2. Se determina si es modo CLI (`IsCliMode`)
3. Se configura la consola (`SetupConsole`)
4. Se muestra pantalla de bienvenida (si aplica)
5. Se obtiene la acción a ejecutar (`Menu.Display`)
6. Se ejecuta la acción
7. Se guardan logs y finaliza el programa

---

## Manejo de Errores

* Todas las ejecuciones están encapsuladas en bloques `try-catch`
* Los errores se muestran al usuario mediante `ConsoleWriter`
* Se registra información en logs mediante `TraceLogger`

---

## Características Clave

* Soporte híbrido: interactivo + automatizado
* Arquitectura extensible
* Reutilización mediante DLL
* Filtrado inteligente de acciones
* Sistema de logging integrado

---

## Consideraciones

* El sistema asume que el usuario conoce los IDs de las acciones en modo CLI
* Algunas acciones pueden requerir argumentos adicionales
* El comportamiento puede variar según el tipo de entrada (archivo o carpeta)

---

## Ejemplo de Uso Completo

### Interactivo:

```bash
program.exe
```

### Drag & Drop:

```bash
program.exe "C:\archivo.dat"
```

### CLI:

```bash
program.exe "C:\archivo.dat" "C:\salida.dat" @2
```

---

## Extensibilidad

Para añadir nuevas funcionalidades:

1. Crear una nueva instancia de `ToolAction`
2. Definir su lógica de ejecución
3. Registrar la acción en el sistema de menú
4. (Opcional) Asignarla a una categoría

No es necesario modificar la lógica central del programa.

---

## Autor

Desarrollado por FranZ (CyberKnightFran)