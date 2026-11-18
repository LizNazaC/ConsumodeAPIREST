# ConsumodeAPIREST
 
Aplicación **.NET MAUI** que consume una API REST pública (JSONPlaceholder), intercambia datos en formato JSON y muestra la información siguiendo el patrón **MVVM**.
 
**Unidad 6 – Consumo de servicios REST**

 
## Objetivo
 
Construir una app que consuma la API pública `https://jsonplaceholder.typicode.com/users`, deserialice la respuesta con `System.Text.Json` y la muestre en una interfaz MVVM, con llamadas asíncronas, indicador de carga y manejo de errores.
 
## Funcionalidades
 
| Función | Descripción |
|---|---|
| **Lista (GET)** | Consulta `GET /users`, deserializa el JSON y lo muestra en un `CollectionView`. |
| **Actualizar lista** | `RefreshView`: se actualiza deslizando hacia abajo. |
| **Detalle (GET por Id)** | Al seleccionar un usuario se navega a otra página enviando el `Id` como parámetro y se consulta `GET /users/{id}`. |
| **Nuevo usuario (POST)** | Formulario que envía un usuario con `POST /users` y muestra el `Id` devuelto por la API. |
| **Asincronía y errores** | Todas las llamadas usan `async/await`, con `ActivityIndicator` mientras cargan y `try/catch` con mensaje al usuario. |
 
## Capturas de pantalla
<img width="1429" height="746" alt="image" src="https://github.com/user-attachments/assets/11e688a0-0109-41f1-8d57-c3fc4d743e8c" />
<img width="343" height="221" alt="image" src="https://github.com/user-attachments/assets/bb773e2e-f16e-4884-a69d-2b693b47c950" />
<img width="1411" height="464" alt="image" src="https://github.com/user-attachments/assets/46aa4cf2-313c-478f-a9a5-f586468b7584" />
