# Sistema de Registro de Colaboradores - Konecta

## Descripción
Este proyecto es la solución a la prueba práctica de **Desarrollador II** para la compañía **Konecta**.  
El sistema permite registrar y consultar colaboradores mediante un servicio web creado en .NET Framework 4.7 y consumido desde una aplicación web.

---

## Funcionalidades principales

### 1. Registrar Colaborador
- Permite registrar los siguientes datos:
  - Número de identificación
  - Nombres
  - Apellidos
  - Dirección
  - Email
  - Teléfono
  - Salario
  - Área
  - Sexo
  - Fecha de ingreso
- El registro se realiza a través del método del servicio web: `RegistrarColaborador`.
- Incluye validaciones de campos y manejo de errores.

### 2. Consultar Colaborador
- Permite consultar colaboradores existentes por **Número de Identificación**.
- Muestra:
  - Nombres
  - Apellidos
  - Salario
  - Área
- La consulta se realiza mediante el método del servicio web: `ConsultarColaboradorPorIdentificacion`.

---

## Requisitos técnicos
- **.NET Framework 4.7**
- **C#** para el backend
- **SQL Server**:
  - Base de datos relacional y normalizada
  - Script DDL para creación de tablas
- Frontend web para CRUD y consumo de servicios web
- Manejo de errores y validaciones de campos

---

## Estructura del proyecto
- `Capa.Web`: Aplicación web que consume el servicio web y permite el CRUD de colaboradores.
- `Capa.API`: Servicio web que expone los métodos `RegistrarColaborador` y `ConsultarColaboradorPorIdentificacion`.
- `Capa.Core`: Lógica de negocio y entidades.
- `Capa.Infrastructure`: Acceso a base de datos y manejo de SQL Server.

---

## Instalación y uso
1. Clonar el repositorio:  
   ```bash
   git clone https://github.com/siulserrotam/Prueba-Konecta.git
﻿# Prueba-Konecta


