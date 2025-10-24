# Trabajo K8S (CI/CD)

El trabajo involucra la creación de microservicios individualmente desplegables, utilizando contenedores `Docker`, un orquestador de contenedores como `Kubernetes` y herramientas como `Helm` para la gestión de paquetes y configuraciones.

## Criterios

- Trabaje con un microservicio básico.
- Diseñar los contenedores Docker para el microservicio incluyendo la configuración necesaria.
- Despliegue con Helm: Crear charts de Helm el microservicio, especificando los valores y configuraciones necesarias.
- Utilizar valores por defecto y overrides para personalizar las configuraciones según el entorno.

## Automatización con Pipelines

Cree los pipelines necesarios para desplegar el aplicativo en el momento de detectar un commit sobre la rama que configure, Configurando pipelines de CI/CD para automatizar el proceso de construcción y despliegue del microservicio.

## Implementación de ArgoCD

- Desplegar ArgoCD en el clúster de Kubernetes.
- Configurar repositorios Git como fuentes de definición de la aplicación.
- Definir aplicación en ArgoCD para el microservicio, utilizando los charts de Helm.

---

# Solucion

[Repositorio de Codigo Fuente](./Source)
[Repositorio de Manifiestos Helm](https://github.com/robin930310/MAS-Arquitectura_Sofware_K8s)

## Integración Continua

![alt](./Diagramas/CI.drawio.svg)

## Despliegue Continuo

![alt](./Diagramas/CD.drawio.svg)
