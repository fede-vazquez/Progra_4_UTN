# hook useEffect

```js
useEffect(()=>,[]) // Se puede tener más de uno en un mismo componente
```

Ejecutar Código Arbitrario

Un ejemplo de código arbitrario sería la llamada a una API

### Recibe 2 parámetros

1. callback, será el código que se va a hacer.
2. array, se denomina como array de dependencia/uso.

-   Cuando el array de dependencias está **vacío** se ejecuta **solo** cuando el componente **se crea**.

-   Cuando el callback **devuelve una closure**, esta closure se va a **ejecutar** cuando el componente se **desmonta**. (Si el array está vacío, este closure no se va a ejecutar)

-   Cuando se **modifica** una de las dependencias dentro del array de dependencias.

En cada caso se ejecuta luego del re-renderizado del componente que cambio su estado o que se haya creado el mismo.
